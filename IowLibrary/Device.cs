using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using IOW.DllWapper;

namespace IowLibrary {
    public delegate void DeviceStatusEventHandler(Device device);

    public class Device {
        public event DeviceStatusEventHandler DeviceClose;
        public event DeviceStatusEventHandler DeviceError;
        public event DeviceStatusEventHandler IoReadError;

        private int? handler;
        private int deviceNumber;
        private int? productId;
        private String serial;
        private String softwareVersion;
        private List<Port> ports;
        private int reportSize;
        private int ioReportSize;

        public Device(int? handler) {
            this.Handler = handler;

            initDevice();
        }

        public int? Handler {
            get { return handler; }
            set { handler = value; }
        }

        public int DeviceNumber {
            get { return deviceNumber; }
            set { deviceNumber = value; }
        }

        public int? ProductId {
            get { return getDeviceProductId(); }
            set { productId = value; }
        }

        public String Serial {
            get { return serial; }
            set { serial = value; }
        }

        public String SoftwareVersion {
            get { return softwareVersion; }
            set { softwareVersion = value; }
        }

        public List<Port> Ports {
            get { return ports; }
            set { ports = value; }
        }

        public int ReportSize {
            get { return reportSize; }
            set { reportSize = value; }
        }

        public int IoReportsSize {
            get { return ioReportSize; }
            set { ioReportSize = value; }
        }


        private void initDevice() {
            getDeviceProductId();
            getDeviceSerial();
            getSoftwareVersion();
            initPorts();
        }

        private int? getDeviceProductId() {
            if (productId == null) {
                productId = IowKit.GetProductId(Handler);
                if (productId == null) {
                    deviceErrorEvent();
                }
            }
            switch (productId) {
                case Defines.IOWKIT_PID_IOW24:
                reportSize = Defines.IOWKIT_REPORT_SIZE;
                ioReportSize = Defines.IOWKIT24_IO_REPORT_SIZE;
                break;
                default:
                reportSize = Defines.IOWKIT_SPECIAL_REPORT_SIZE;
                ioReportSize = Defines.IOWKIT_SPECIAL_REPORT_SIZE;
                break;
            }

            return productId;
        }

        private String getDeviceSerial() {
            if (serial == null) {
                serial = IowKit.GetProductSerial(Handler);
            }
            return serial;
        }

        private String getSoftwareVersion() {
            if (softwareVersion == null) {
                softwareVersion = IowKit.GetProductSoftwareVersion(Handler);
            }
            return softwareVersion;
        }

        private void initPorts() {
            if(ports == null) {
                ports = new List<Port>();
            }
            for (int i = 0; i < 2; i++) {
                Port port = new Port(i, this);
                port.Error += Port_Error;
                ports.Add(port);
            }
        }

        private void Port_Error(Port port) {
            System.Console.WriteLine("Error in Port: " + port.PortNumber);
        }

        public void IO(int pipeNum) {

            byte[] data = new byte[IoReportsSize];
            // Read in data
            Console.WriteLine("ReadIn");
            int? readByts = IowKit.Read(Handler, 1, data, IoReportsSize);
            if (readByts == null) {
                ioErrorEvent();
            }
            if (readByts != IoReportsSize) {
                // TODO nicht alle bit eingelesen und nun?
                Console.WriteLine("not all read in!");
            }
            int count = 0;
            foreach (Byte dat in data) {
                Console.WriteLine("data " + count +": " + dat);
                count++;
            }
         
            // Write out ports
        }


        public void Close() {
            IowKit.closeDevice(this.Handler);
            deviceCloseEvent();
        }

        private void deviceCloseEvent( ) {
            if (DeviceClose != null) {
                DeviceClose(this);
            }
            System.Console.WriteLine("Device: " + Handler + " close");
        }

        private void deviceErrorEvent( ) {
            if (DeviceError != null) {
                Close();
                DeviceError(this);
            }
        }

        private void ioErrorEvent() {
            if(IoReadError != null) {
                IoReadError(this);
            }
        }
    }
}
