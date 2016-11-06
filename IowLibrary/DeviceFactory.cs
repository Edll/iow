﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOW.DllWapper;

namespace IowLibrary {
    public delegate void DeviceFactorEventHandler(String deviceError);

    public class DeviceFactory {
        public event DeviceFactorEventHandler DeviceError;

        private Dictionary<int, Device> devices;
        private int? deviceCounter = null;
        private readonly DeviceFactory instance;

        public DeviceFactory(DeviceFactorEventHandler DeviceError) {
            this.DeviceError += DeviceError;
            initFactory();

            if (instance == null) {
                instance = this;
            }
        }

        public Dictionary<int, Device> Devices {
            get {
                if(devices == null) {
                    initFactory();
                    if(devices == null) {
                        DeviceError("Es wurden keine Angeschlossenen Devices gefunden");
                    }
                }
                return devices; }
            set { devices = value; }
        }

        private void initFactory() {
            bool isOpen = openDevices();
            if (!isOpen) {
                return;
            }

            bool isCountDevices = countDevices();
            if (!isCountDevices) {
                return;
            }
            openAllAvailableDevices();
        }

        private void openAllAvailableDevices() {
            for (int? i = Defines.IOWKIT_START_NUMBERING; i <= deviceCounter; i++) {
                int? handler = IowKit.GetHandlerForDevice(i);
                if (handler == null && DeviceError != null) {
                    // TODO: close devices if there is no!
                    DeviceError("Das Device mit der Nummer: " + i + " konnte nicht geöffnet " +
                        "werden. Wurde es zwischendurch entfernt.");
                    continue;
                }
                AddDevice((int)handler, (int)i);
            }
        }

        private bool openDevices() {
            int? firstDeviceHandler = IowKit.OpenDevices();
            if (firstDeviceHandler == null) {
                DeviceError("Es wurde kein Device gefunden");
                return false;
            }
            return true;
        }

        private bool countDevices() {
            deviceCounter = IowKit.GetConnectDeviceCounter();
            if (deviceCounter == null && DeviceError != null) {
                DeviceError("Fehler beim öffnen der Devices. Wurden welche angeschlossen?");
                return false;
            }
            return true;
        }

        public void AddDevice(int handler, int deviceNumber) {
            if (devices == null) {
                devices = new Dictionary<int, Device>();
            }

            Device device = new Device(handler);
            device.DeviceNumber = deviceNumber;
            device.DeviceClose += Device_DeviceClose;
            devices.Add(handler, device);
        }

        public void RemoveDevice(int? handler) {
            Device device = null;

            devices.TryGetValue((int) handler, out device);

            if (device != null) {
                device.Close();
                removeDevice(handler);
            } else {
                DeviceError("Device mit dem Handler: " + handler + " konnte nicht enfernt werden.");
            }
        }

        public void RemoveAllDevices() {
            foreach (KeyValuePair<int, Device> deviceEntry in Devices) {
                Device device = deviceEntry.Value;
                device.Close();
            }
            devices.Clear();
        }

        private void removeDevice(int? handler) {
            System.Console.WriteLine("Device will be removed: " + handler);
            devices.Remove((int)handler);
        }

        public Device GetDevice(int handler) {
            Device device = null;

            devices.TryGetValue(handler, out device);

            if (device == null) {
                DeviceError("Device mit dem Handler: " + handler + " konnte nicht enfernt werden.");
            }
            return device;
        }

        public Device GetDeviceNumber(int deviceNumber) {
            if (deviceNumber < Defines.IOWKIT_START_NUMBERING) {
                throw new ArgumentException("Die angegebene Device Nummer ist zu klein");
            }
            if (devices != null) {
                foreach (KeyValuePair<int, Device> deviceEntry in devices) {
                    Device device = deviceEntry.Value;
                    if (device.DeviceNumber == deviceNumber) {
                        return device;
                    }
                }
            }
            DeviceError("Es wurde kein Device mit der Nummer: " + deviceNumber + " gefunden");
            return null;
        }

        public int GetNumberOfDevices() {
            return devices == null ? 0 : devices.Count; ;
        }

        private void Device_DeviceClose(Device device) {
            if (device != null && device.Handler != null) {
                this.removeDeviceAsCloseEvent(device);
            }
        }

        private void removeDeviceAsCloseEvent(Device device) {
            Device deviceFromFactroy = null;
            devices.TryGetValue((int)device.Handler, out deviceFromFactroy);
            if (deviceFromFactroy != null) {
                removeDevice(device.Handler);
            }
        }
    }
}
