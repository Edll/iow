using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IowLibrary;
using System.Data;

namespace IoWarrior {
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

                // add number of needed rows
                while (dataTable.Rows.Count < devices.Count) {
                    dataTable.Rows.Add();
                }

                for (int i = 0; i < columnNames.Count; i++) {
             
                    string name = columnNames[i];
                    dataTable.Columns.Add(name);

                    int iRow;
                    switch (name) {
                        case columnNameNumber:
                        iRow = 0;
                        setDeviceValue(devicesList, dataTable, i);
                        break;
                        case columnNameProduct:
                        iRow = 0;
                        foreach (Device device in devicesList) {

                            dataTable.Rows[iRow][i] = device.ProductId;
                            iRow++;
                        }
                        break;
                        case columnNameSoftware:
                        iRow = 0;
                        foreach (Device device in devicesList) {

                            dataTable.Rows[iRow][i] = device.SoftwareVersion;
                            iRow++;
                        }
                        break;
                        case columnNameSerial:
                        iRow = 0;
                        foreach (Device device in devicesList) {

                            dataTable.Rows[iRow][i] = device.Serial;
                            iRow++;
                        }
                        break;

                        case columnNameHandler:
                        iRow = 0;
                        foreach (Device device in devicesList) {

                            dataTable.Rows[iRow][i] = device.Handler;
                            iRow++;
                        }
                        break;
                    }
                }
            }
            return dataTable;
        }

        private static void setDeviceValue(List<Device> devicesList, DataTable dataTable, int i)
        {
            int iRow = 0;
            foreach (Device device in devicesList)
            {
            
                dataTable.Rows[iRow][i] = device.DeviceNumber;
                iRow++;
            }
        }
    }
}
