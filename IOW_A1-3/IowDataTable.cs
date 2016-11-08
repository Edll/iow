using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IowLibrary;
using System.Data;

namespace IOW_A1_3 {
    public class IowDataTable {
        private const String columnNameNumber = "Number";
        private const String columnNameProduct = "ProductId";
        private const String columnNameSoftware = "Software Version";
        private const String columnNameSerial = "Serial Number";
        private const String columnNameHandler = "Handler";

        public static DataTable GetResultsTable(Dictionary<int, Device> devices) {

            List<string> columnNames = new List<string>();

            columnNames.Add(columnNameNumber);
            columnNames.Add(columnNameProduct);
            columnNames.Add(columnNameSoftware);
            columnNames.Add(columnNameSerial);
            columnNames.Add(columnNameHandler);

            DataTable dataTable = new DataTable();

            List<Device> devicesList = new List<Device>();
            if (devices != null) {
                foreach (KeyValuePair<int, Device> deviceEntry in devices) {
                    Device device = deviceEntry.Value;
                    devicesList.Add(device);
                }


                for (int i = 0; i < columnNames.Count; i++) {

                    string name = columnNames[i];
                    dataTable.Columns.Add(name);

                    // add number of needed rows
                    while (dataTable.Rows.Count < devices.Count) {
                        dataTable.Rows.Add();
                    }

                    switch (name) {
                        case columnNameNumber:
                        foreach (Device device in devicesList) {
                            for (int iRow = 0; iRow < devices.Count; iRow++) {
                                dataTable.Rows[iRow][i] = device.DeviceNumber;
                            }
                        }
                        break;
                        case columnNameProduct:
                        foreach (Device device in devicesList) {
                            for (int iRow = 0; iRow < devices.Count; iRow++) {
                                dataTable.Rows[iRow][i] = device.ProductId;
                            }
                        }
                        break;
                        case columnNameSoftware:
                        foreach (Device device in devicesList) {
                            for (int iRow = 0; iRow < devices.Count; iRow++) {
                                dataTable.Rows[iRow][i] = device.SoftwareVersion;
                            }
                        }
                        break;
                        case columnNameSerial:
                        foreach (Device device in devicesList) {
                            for (int iRow = 0; iRow < devices.Count; iRow++) {
                                dataTable.Rows[iRow][i] = device.SoftwareVersion;
                            }
                        }
                        break;
                        case columnNameHandler:
                        foreach (Device device in devicesList) {
                            for (int iRow = 0; iRow < devices.Count; iRow++) {
                                dataTable.Rows[iRow][i] = device.Handler;
                            }
                        }
                        break;
                    }
                }
            }
            return dataTable;
        }
    }
}
