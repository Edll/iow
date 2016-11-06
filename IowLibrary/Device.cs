using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IowLibrary {
    public delegate void DeviceStatusEventHandler(Device device);

    public class Device {
        public event DeviceStatusEventHandler DeviceClose;
        public event DeviceStatusEventHandler DeviceError;

        private int? handler;
        private int deviceNumber;
        private int? productId;
        private String deviceSerial;
        private String softwareVersion;
        private List<Port> ports;

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

        public String DeviceSerial {
            get { return deviceSerial; }
            set { deviceSerial = value; }
        }
        
        public String SoftwareVersion {
            get { return softwareVersion; }
            set { softwareVersion = value; }
        }

        public List<Port> Ports {
            get { return ports; }
            set { ports = value; }
        }



        private void initDevice() {
            getDeviceProductId();
        }

        private int? getDeviceProductId() {
            if (productId == null) {
                productId = IowKit.GetProductId(Handler);
                if (productId == null) {
                    deviceErrorEvent(this);
                }
            }
            return productId;
        }



        public void Close() {
            IowKit.closeDevice(this.Handler);
            deviceCloseEvent(this);
        }

        private void deviceCloseEvent(Device device) {
            if (DeviceClose != null) {
                DeviceClose(this);
            }
        }

        private void deviceErrorEvent(Device device) {
            if (DeviceError != null) {
                Close();
                DeviceError(this);
            }
        }
    }
}
