using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visual_MI {
    public partial class ConfirmExport : Form {
        public ConfirmExport() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            if (ttperiod.Text=="") {
                MessageBox.Show("Enter a filename", "Save", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else {
                z.changeTitle(ttperiod.Text.ToString());
                z.path = ttpath.Text;
                if (cb.Checked) {
                    z.cbstatus = true;
                }
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
            
        }

        public Main z { get; set; }
        private void ttperiod_TextChanged(object sender, EventArgs e) {
            ttpath.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Magic Input IDS\\" + ttperiod.Text + ".csv";
        }

        private void ofd_FileOk(object sender, CancelEventArgs e) {

        }
    }
}
