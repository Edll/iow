using System.Windows.Forms;
using IowLibary;
using IowLibary.DllWapper;

namespace IoWarrior {
    /// <summary>
    /// Utils for the GUI
    /// </summary>
    /// <author>M. Vervoorst junk@edlly.de</author>
    public class GuiUtils {
        /// <summary>
        /// Checks all items in the given CheckedListBox Object
        /// </summary>
        /// <param name="sender">Sender item must be off type CheckBox</param>
        /// <param name="clb">CheckedListBox wich will be checked</param>
        public static void CheckboxListSetAllItems(object sender, CheckedListBox clb) {
            if (!(sender is CheckBox)) return;

            var cb = (CheckBox)sender;

            if (cb.Checked) {
                for (var i = 0; i < clb.Items.Count; i++) {
                    CheckBoxListSetChecked(clb, i, true);
                }
            } else {
                for (var i = 0; i < clb.Items.Count; i++) {
                    clb.SetSelected(i, true);
                    CheckBoxListSetChecked(clb, i, false);
                    clb.SetSelected(i, false);
                }
            }
        }

        /// <summary>
        /// Generates Items items the CheckedListBox objects
        /// </summary>
        /// <param name="clb">CheckedListBox object</param>
        /// <param name="enabel">if true items will be enabel</param>
        public static void CreatePortEntrys(CheckedListBox clb, bool enabel) {
            for (var i = 0; i < Defines.MaxBitNumber + 1; i++) {
                clb.Items.Add(i);
                clb.Enabled = enabel;
            }
        }

        private static void CheckBoxListSetChecked(CheckedListBox clb, int i, bool check) {
            clb.SetSelected(i, true);
            clb.SetItemChecked(i, check);
            clb.SetSelected(i, false);
        }
    }
}
