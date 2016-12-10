using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IowLibary;
using System.Data;

namespace IoWarrior {
    /// <summary>
    /// Model Class for the Device Table
    /// </summary>
    /// <author>M. Vervoorst junk@edlly.de</author>
    public class IowDataModelTable {
        private const string ColumnNameNumber = "Number";
        private const string ColumnNameProduct = "ProductId";
        private const string ColumnNameSoftware = "Software Version";
        private const string ColumnNameSerial = "Serial Number";
        private const string ColumnNameHandler = "Handler";

        /// <summary>
        /// Create a DataTable object for an Tabel form the given device list
        /// </summary>
        /// <param name="devices">List of divces</param>
        /// <returns>DataTabele object where every device is in own row</returns>
        public static DataTable GetResultsTable(Dictionary<int, Device> devices) {

            var columnNames = new List<string>
            {
                ColumnNameNumber,
                ColumnNameProduct,
                ColumnNameSoftware,
                ColumnNameSerial,
                ColumnNameHandler
            };


            var dataTable = new DataTable();

            if (devices == null) return dataTable;

            var devicesList = devices.Select(deviceEntry => deviceEntry.Value).ToList();

            // add number of needed rows
            while (dataTable.Rows.Count < devices.Count) {
                dataTable.Rows.Add();
            }

            for (var i = 0; i < columnNames.Count; i++) {
             
                var name = columnNames[i];
                dataTable.Columns.Add(name);

                int iRow;
                switch (name)
                {
                    case ColumnNameNumber:
                        iRow = 0;
                        SetDeviceValue(devicesList, dataTable, i);
                        break;
                    case ColumnNameProduct:
                        iRow = 0;
                        foreach (var device in devicesList)
                        {
                            dataTable.Rows[iRow][i] = device.ProductId;
                            iRow++;
                        }
                        break;
                    case ColumnNameSoftware:
                        iRow = 0;
                        foreach (var device in devicesList)
                        {
                            dataTable.Rows[iRow][i] = device.SoftwareVersion;
                            iRow++;
                        }
                        break;
                    case ColumnNameSerial:
                        iRow = 0;
                        foreach (var device in devicesList)
                        {
                            dataTable.Rows[iRow][i] = device.Serial;
                            iRow++;
                        }
                        break;
                    case ColumnNameHandler:
                        iRow = 0;
                        foreach (var device in devicesList)
                        {
                            dataTable.Rows[iRow][i] = device.Handler;
                            iRow++;
                        }
                        break;
                }
            }
            return dataTable;
        }

        private static void SetDeviceValue(IEnumerable<Device> devicesList, DataTable dataTable, int i)
        {
            var iRow = 0;
            foreach (var device in devicesList)
            {
            
                dataTable.Rows[iRow][i] = device.DeviceNumber;
                iRow++;
            }
        }
    }
}
