using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Runtime.InteropServices;
using System.Diagnostics;
using OfficeOpenXml; //ExcelPackage

namespace QSFP28G_FR1_ResistanceTest

{
    public class ExcelDocument2007
    {
        private ExcelPackage XLPackage { get; set; }
        private ExcelPackage DesXLPackage { get; set; }
        private ExcelWorksheet ActiveXLworksheet = null;
        private ExcelWorkbook XLWorkbook = null;
        private const string NUMBER = "Number";
        private const string DESCRIPTION = "Description";
        private int activeSheetNo_ = 0;

        public int ActiveSheetNo
        {
            get { return activeSheetNo_; }
            set
            {
                if ((value < 0) || (value > XLWorkbook.Worksheets.Count))
                {
                    throw new Exception("Index exceeds number of worksheets,index should be start with 1");
                }
                else
                {
                    activeSheetNo_ = value;
                    ActiveXLworksheet = XLWorkbook.Worksheets[activeSheetNo_];
                }
            }
        }

        public string FileName
        {   get; 
            private set; 
        }

        public ExcelDocument2007()
        { 
        }

        public void Open(string filename, string templateFile)
        {
            XLPackage = new ExcelPackage(new FileInfo(filename), new FileInfo(templateFile));
            XLWorkbook = XLPackage.Workbook;
            ActiveSheetNo = 1;
            FileName = filename;
        }
        public void Open(string filename)
        {
            try
            {
                XLPackage = new ExcelPackage(new FileInfo(filename));
                XLWorkbook = XLPackage.Workbook;
                ActiveSheetNo = 1;
                FileName = filename;
            }
            catch (Exception ex)
            {
                if (ex.ToString().Contains("because it is being used by another process"))
                {
                    System.Windows.Forms.MessageBox.Show(string.Format("Excel file {0}is openned，please close it and try again",filename));
                }
                throw;
            }
        }
        public void SetSheet(string workSheetName)
        {
            ActiveXLworksheet = XLWorkbook.Worksheets[workSheetName];
        }
        public List<string> GetAllSheetNames()
        {
            List<string> names = new List<string>();
            foreach (ExcelWorksheet item in XLWorkbook.Worksheets)
            {
                names.Add(item.Name);
            }
            return names;
        }
        public int GetRowCount()
        {
            if (ActiveXLworksheet == null) return 0;
            return ActiveXLworksheet.Dimension.End.Row;
        }

        public int GetColumnCount()
        {
            if (ActiveXLworksheet == null) return 0;
            return ActiveXLworksheet.Dimension.End.Column;
        }

        public int GetCellCountInCol_NotEmpty(string columnName)
        {
            var query = (from cell in ActiveXLworksheet.Cells[string.Format("{0}:{0}", columnName)] where cell.Text != "" select cell);
            return query.Count<ExcelRangeBase>();
        }
        //copy column
        public void CopyColumn(ExcelDocument2007 excel2007, int startSourceRow, int stopSourceRow, int sourceCol, int startDesRow,int stopDesRow,int desCol)
        {
            for (int i = 0; i < (stopDesRow - startDesRow); i++)
            {
                string value = excel2007.ReadValue(startSourceRow + i, sourceCol);
                AddData(startDesRow + i,desCol,value);
            }
        }

        //copy row
        public void CopyRow(ExcelDocument2007 excel2007,  int startSourceCol, int stopSourceCol, int sourceRow, int startDesCol, int stopDesCol, int desRow)
        {
            for (int i = 0; i <=(stopDesCol - startDesCol); i++)
            {
                string value = excel2007.ReadValue(sourceRow, startSourceCol + i);
                AddData(desRow, startDesCol + i, value);
            }

        }

        public void AddData(int row, int col, object value)
        {
            if (value != null)
                ActiveXLworksheet.SetValue(row, col, value);
        }
        public void AddData(int row, int col, double value)
        {
            ActiveXLworksheet.SetValue(row, col, value);
        }
        public void AddData(int row, int col, string value)
        {
            if (value != null)
                ActiveXLworksheet.SetValue(row, col, value);
        }

        public string Formula(int row, int col)
        {
            return ActiveXLworksheet.Cells[row,col].Formula;
        }

        // Excel don't get scientific notation... help it! ("F13" is the limit for format)
        public void AddData(int row, int col, string value, string format)
        {
            double valD;
            if (double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out valD))
            {
                AddData(row, col, valD.ToString(format, CultureInfo.InvariantCulture));
            }
            else
            {
                AddData(row, col, value);
            }
        }

        // Normalize the input string value with the normalizer factor and add to excel
        public void AddDataNorm(int row, int col, string value, double normalizer)
        {
            double valD;
            if (double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out valD))
            {
                AddData(row, col, (valD * normalizer).ToString(CultureInfo.InvariantCulture));
            }
            else
            {
                /*Maybe not necessary. Will leave it for now*/
                throw new ApplicationException("Tryparse failed @ AddDataNorm()");
            }
        }

        // Method that adds an IEnumerable of T in column 'col', starting at row 'startrow'
        public void AddColumnData<T>(int startrow, int col, IEnumerable<T> values)
        {
            int row = startrow;
            foreach (T item in values)
            {
                AddData(row, col, item.ToString());
                row++;
            }

        }

        // Method that adds an IEnumerable of T in row 'row', starting at column 'startcol'
        public void AddRowData<T>(int row, int startcol, IEnumerable<T> values)
        {
            int col = startcol;
            foreach (T item in values)
            {
                AddData(row, col, item.ToString());
                col++;
            }
        }

        public void AddRowData(int row, int startcol, List<double> rowValues, List<string> keyList, Dictionary<String, Dictionary<String, String>> channelDictionary)
        {
            List<double>.Enumerator rowValue = rowValues.GetEnumerator();
            int col = startcol;
            foreach (string key in keyList)
            {
                rowValue.MoveNext();
                String freq = key.Split(' ')[2];
                if (channelDictionary[DESCRIPTION].ContainsKey(freq))
                {
                    //prevent the 'scientific notation'-bug
                    AddData(row, col, rowValue.Current.ToString("F13", CultureInfo.InvariantCulture));
                    col++;
                }
            }
        }
        public void AddRowData(int row, int startcol, IEnumerable<XElement> dataNodes)
        {
            int col = startcol;

            foreach (XElement node in dataNodes)
            {
                AddData(row, col, node.Value.ToString());
                col++;
            }
        }

        public void AddRowData(int row, int startcol, IEnumerable<XElement> dataNodes, Dictionary<String, Dictionary<String, String>> channelDictionary, string keyNode, string valueNode)
        {
            int col = startcol;

            foreach (XElement node in dataNodes)
            {
                //if( channelDictionary.TryGetValue( node.Element( keyNode ).Value, out value ) && value != "" ) {
                String freq = node.Element(keyNode).Value.Split(' ')[2];
                if (channelDictionary[DESCRIPTION].ContainsKey(freq))
                {
                    AddData(row, col, node.XPathSelectElement(valueNode).Value, "F13");
                    col++;
                }
            }
        }
        public void AddRowDataNorm(int row, int startcol, IEnumerable<XElement> dataNodes, double normalizer)
        {
            int col = startcol;

            foreach (XElement node in dataNodes)
            {
                AddDataNorm(row, col, node.Value.ToString(), normalizer);
                col++;
            }
        }
        public void AddRowDataNorm(int row, int startcol, IEnumerable<XElement> dataNodes, Dictionary<String, Dictionary<String, String>> channelDictionary, string keyNode, string valueNode, double normalizer)
        {
            int col = startcol;
            foreach (XElement node in dataNodes)
            {
                String freq = node.Element(keyNode).Value.Split(' ')[2];
                if (channelDictionary[DESCRIPTION].ContainsKey(freq))
                {
                    //if( channelDictionary.TryGetValue( node.Element( keyNode ).Value, out value ) && value != "" ) {
                    AddDataNorm(row, col, node.XPathSelectElement(valueNode).Value, normalizer);
                    col++;
                }
            }
        }

        // Adds a row of preset data (channel # and frequency) to active Excel sheet. 
        public void AddRowPresetData(int chRow, int fqRow, int startcol, IEnumerable<XElement> dataNodes, Dictionary<String, Dictionary<String, String>> channelDictionary, string keyNode)
        {
            int col = startcol;
            foreach (XElement node in dataNodes)
            {
                String freq = node.Element(keyNode).Value.Split(' ')[2];
                if (channelDictionary[DESCRIPTION].ContainsKey(freq))
                {
                    AddData(chRow, col, channelDictionary[NUMBER][freq]);
                    AddData(fqRow, col, freq);
                    col++;
                }
            }
        }

        public void CreateSharedFormula(int sourceRow, int sourceCol, int targetRow, int targetCol)
        {
            //ActiveXLworksheet.CreateSharedFormula(ActiveXLworksheet.Cell(sourceRow, sourceCol), ActiveXLworksheet.Cell(targetRow, targetCol));
        }

        // Value needs to be removed in order for excel to re-calculate formulas at open document
        public void RemoveValue(int row, int col)
        {
            ActiveXLworksheet.SetValue(row, col, null);

        }
        public void RemoveValue(int startRow, int endRow, int startCol, int endCol)
        {
            for (int r = startRow; r <= endRow; r++)
                for (int c = startCol; c <= endCol; c++)
                    RemoveValue(r, c);
        }
        public string ReadValue(int row, int col)
        {
            if (ActiveXLworksheet == null)
                return "";
            if (row > GetRowCount() || col > GetColumnCount())
                return "";
            object res = ActiveXLworksheet.GetValue(row, col);
            if (res == null)
                return "";
            else
                return res.ToString();
        }

        public void Calculate()
        {
            XLWorkbook.Calculate();
        }

        public void Calculate(string sheetName)
        {
            SetSheet(sheetName);
            ActiveXLworksheet.Calculate();
        }

        public void Close()
        {
            try
            {
                if (XLPackage != null)
                {
                    XLPackage.Dispose();
                    XLPackage = null;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void SaveAndCleanUp()
        {
            try
            {
                if (XLPackage != null)
                {
                    XLPackage.Save();
                    XLPackage.Dispose();
                    XLPackage = null;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            Process[] deathList = Process.GetProcessesByName("excel");
            try
            {

                for (int i = 0; i < deathList.Length; i++)
                {
                    deathList[i].Close();
                    //deathList[i].Kill();
                }
            }
            catch (Exception ex)
            {
                throw new ExternalException("There was a problem killing the running excel processes, " + ex.Message, ex);
            }
        }

    }
}
