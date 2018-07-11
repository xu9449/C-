using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO.Ports;

namespace Finisar.User_Controls {
    public partial class PowerMeter : UserControl {

        SerialPort Serial_Comm;

        public PowerMeter( ) {
            InitializeComponent( );
        }

        public bool Init_PowerMeter( ) {
            Serial_Comm = new SerialPort( );
            Serial_Comm.BaudRate = 19200;
            Serial_Comm.DataBits = 8;
            Serial_Comm.PortName = @"COM3";
            Serial_Comm.StopBits = StopBits.One;
            Serial_Comm.Parity = 0;
            Serial_Comm.ReadTimeout = 100;
            Serial_Comm.Open( );
            return Serial_Comm.IsOpen;
        }

        public void MeasurePower( ) {
            if( Serial_Comm != null ) {
                Thread.Sleep( 200 );
                PowerMeterMeasurement( );
                Thread.Sleep( 100 );
                PowerMeterMeasurement( );
                lblPowerReading.Text = PowerMeterReading;
            }
        }
        public string PowerMeterReading { get; set; }
        public double PowerOffSet {
            get { return double.Parse( txtPowerOffset_0.Text ); }
            set {
                txtPowerOffset_0.Text = value.ToString( );
                Validate( );
            }
        }
        public double PowerActualValue { get; set; }

        public void PowerMeterMeasurement( ) {
            if( Serial_Comm == null || Serial_Comm.IsOpen == false )
                return;
            Serial_Comm.WriteLine( "v" );
            Thread.Sleep( 100 );
            string reading = Serial_Comm.ReadLine( );
            if( reading.Contains( "L" ) )
                reading = "NaN";
            else
                reading = Convert.ToDouble( reading ).ToString( );
            //double powerReading = Convert.ToDouble( Serial_Comm.ReadLine( ) );
            PowerMeterReading = reading;
            lblActualPower.Text = GetActualPowerValue( ).ToString( "0.00" );
        }

        public double GetActualPowerValue( ) {
            PowerActualValue = double.Parse( PowerMeterReading ) + PowerOffSet;
            return PowerActualValue;
        }

        private void btnSetOffset_Click( object sender, EventArgs e ) {

        }
    }
}
