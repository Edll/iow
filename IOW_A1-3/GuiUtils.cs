using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IOW_A1_3 {
    class GuiUtils {
        public static void CheckboxListSetAllItems(object sender, CheckedListBox clb) {
            if (sender is CheckBox) {
                CheckBox cb = (CheckBox)sender;
                if (cb.Checked) {
                    for (int i = 0; i < clb.Items.Count; i++) {
                        CheckBocListSetChecked(clb, i, true);
                    }
                } else {
                    for (int i = 0; i < clb.Items.Count; i++) {
                        clb.SetSelected(i, true);
                        CheckBocListSetChecked(clb, i, false);
                        clb.SetSelected(i, false);
                    }
                }
            }
        }

        private static void CheckBocListSetChecked(CheckedListBox clb, int i, bool check) {
            clb.SetSelected(i, true);
            clb.SetItemChecked(i, check);
            clb.SetSelected(i, false);
        }
    }
}
