using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IowLibrary;
using System.Data;

namespace IOW_A1_3 {
    public class IowPortDataTable {
        private const String columnNameNumber = "port";

        public static DataTable GetResultsTable() {

            List<string> columnNames = new List<string>();

            columnNames.Add(columnNameNumber);

            DataTable dataTable = new DataTable();

            //List<Device> devicesList = new List<Device>();
            //if (devices != null) {
            //    foreach (KeyValuePair<int, Device> deviceEntry in devices) {
            //        Device device = deviceEntry.Value;
            //        devicesList.Add(device);
            //    }


            for (int i = 0; i < columnNames.Count; i++) {

                string name = columnNames[i];
                dataTable.Columns.Add(name);
               

                // add number of needed rows
                while (dataTable.Rows.Count < 1) {
                    dataTable.Rows.Add();
                }

                switch (name) {
                    case columnNameNumber:

                    for (int iRow = 0; iRow < 1; iRow++) {
                        dataTable.Rows[iRow][i] = true;
                    }

                    break;
                }
            }

            return dataTable;
        }
    }
}
