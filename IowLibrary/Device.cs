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
        private String lastError;

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

        public string LastError {
            get { return lastError; }
            set { lastError = value; }
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
            if (ports == null) {
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
     
        public void SetReadTimeout(int timeout) {
            bool result = IowKit.Timeout(handler, timeout);
            if (!result) {
                Console.WriteLine("time was not set");
            }
        }

        public void InitPorts(int pipeNum) {
            byte[] write = new byte[IoReportsSize];

            write[0] = 0xff;
            write[1] = 0xff;
            write[2] = 0xff;
            int? writebyts = IowKit.Write(handler, pipeNum, write, IoReportsSize);
            if (writebyts != IoReportsSize) {
                writebyts = IowKit.Write(handler, pipeNum, write, IoReportsSize);
                if (writebyts != IoReportsSize) {
                    lastError = "could not write all Datas to InitDevice!";
                    deviceErrorEvent();
                }
            }
        }

        public void IO(int pipeNum) {


            //IowKit.Timeout(handler, 1);
            //int? ok = IowKit.Read(handler, 0, data, ioReportSize);
            //if (ok == null || ok != ioReportSize) {
            //    ok = IowKit.Read(handler, 0, data, ioReportSize);
            //    if (ok == null || ok != ioReportSize) {
            //        lastError = "could not read all data";
            //        deviceErrorEvent();
            //    }
            //}

            byte[] data = readDataIm(pipeNum); 

     
            //foreach(byte da in data){
            //    Console.WriteLine("data1 : " + da);
            //}
            writeDataToPort(data);
           
        }

        private byte[] readDataIm(int pipeNum) {
            byte[] data = new byte[IoReportsSize];
            bool ok = IowKit.ReadImm(handler, data);
            if (!ok) {
                data = readDataIm(pipeNum);
            }
            return data;
        }


        public void Close() {
            IowKit.closeDevice(this.Handler);
            deviceCloseEvent();
        }

        private void deviceCloseEvent() {
            if (DeviceClose != null) {
                DeviceClose(this);
            }
            Console.WriteLine("Device: " + Handler + " close");
        }

        private void writeDataToPort(byte[] data) {
            // da wir mit readImm arbeiten ist das result byte 0 das erste
            int i = 0;
            foreach(byte dataIn in data) {
               if((i+1) <= ports.Count) {
                    Port port = ports[i];
                    port.SetInputData(dataIn);
                }else {
                    break;
                }

                i++;
            }

        }

        private void deviceErrorEvent() {
            if (DeviceError != null) {
                Close();
                DeviceError(this);
            }
        }

        private void ioErrorEvent() {
            if (IoReadError != null) {
                IoReadError(this);
            }
        }
    }
}
