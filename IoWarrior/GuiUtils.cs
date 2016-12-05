using System.Windows.Forms;
using IowLibrary;

namespace IoWarrior {
   public class GuiUtils {
        public static void CheckboxListSetAllItems(object sender, CheckedListBox clb) {
            if (!(sender is CheckBox)) return;
            var cb = (CheckBox)sender;
            if (cb.Checked) {
                for (var i = 0; i < clb.Items.Count; i++) {
                    CheckBocListSetChecked(clb, i, true);
                }
            } else {
                for (var i = 0; i < clb.Items.Count; i++) {
                    clb.SetSelected(i, true);
                    CheckBocListSetChecked(clb, i, false);
                    clb.SetSelected(i, false);
                }
            }
        }

        private static void CheckBocListSetChecked(CheckedListBox clb, int i, bool check) {
            clb.SetSelected(i, true);
            clb.SetItemChecked(i, check);
            clb.SetSelected(i, false);
        }

        public static void CreatePortEntrys(CheckedListBox clb, bool enabel) {
            for (var i = 0; i < PortBit.MaxBitNumber + 1; i++) {
                clb.Items.Add(i);
                clb.Enabled = enabel;
            }
        }
    }
}
