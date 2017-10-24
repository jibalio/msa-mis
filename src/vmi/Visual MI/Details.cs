using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visual_MI {
    public partial class Details : Form {
        bool isEdit = false;
        public Main z;
        public int id;
        TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
        String name, desig, sss, tin, emer, rel, add, num;

        private void Details_Load(object sender, EventArgs e) {

        }

        private void button2_Click(object sender, EventArgs e) {
            
        }

        private void ttDesig_TextChanged(object sender, EventArgs e) {
            
        }

        private void ttDesig_Leave(object sender, EventArgs e) {
            if (ttDesig.Text.ToString() == "L") ttDesig.Text = "LADY GUARD";
            else if (ttDesig.Text.ToString() == "W") ttDesig.Text = "WATCHER";
            else if (ttDesig.Text.StartsWith("KEEP:")) {
                String k = ttDesig.Text.Substring(5, ttDesig.Text.Length-5);
                ttDesig.Text = k;
            }
            else ttDesig.Text = "SECURITY GUARD";
        }

        private void ttDesig_Enter(object sender, EventArgs e) {
            if (!(ttDesig.Text.StartsWith("SECURITY") || ttDesig.Text.StartsWith("WAT") || ttDesig.Text=="") ){
                ttDesig.Text = "KEEP:" + ttDesig.Text;
            }
        }

        private void ttEmer_TextChanged(object sender, EventArgs e) {
           
           
        }

        public Details(int a) {
            InitializeComponent();
            ttid.Text = a.ToString();
            id = a;
        }
        //name desig sss tin emer rel add #
        public Details(int a, String b, String c, String d, String e, String f, String g, String h, String i) {
            InitializeComponent();
            isEdit = true;
            ttid.Text = a.ToString();
            id = a;
            ttName.Text = b;
            ttDesig.Text = c;
            ttSSS.Text = d;
            ttTin.Text = e;
            ttEmer.Text = f;
            ttRel.Text = g;
            ttAdd.Text = h;
            ttNum.Text = i;
        }

        private void btnNext_Click(object sender, EventArgs e) {
                
                ListViewItem item = new ListViewItem(id.ToString());
                SaveToVars();
                NormalizeVars();
                item.SubItems.AddRange(new String[] {
                name, desig, sss, tin, emer, rel, add, num
                 });
                z.lv.Items.Add(item);


            


            if (!isEdit) {
                z.ttsa.Text = (id + 1).ToString();
                DialogResult v = MessageBox.Show("Saved. Make new ID?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                this.DialogResult = v;
                this.Close();
            } else {
                this.Close();
            }
          
           
            
        }

        private void NormalizeVars() {
            // Name
            emer = textInfo.ToTitleCase(emer);
            rel = textInfo.ToTitleCase(rel);
            add = textInfo.ToTitleCase(add);
        }

        private void button1_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.No;
        }


        private void SaveToVars() {
            name = ttName.Text.ToString();
            desig = ttDesig.Text.ToString();
            sss = ttSSS.Text.ToString();
            tin = ttTin.Text.ToString();
            emer = ttEmer.Text.ToString();
            rel = ttRel.Text.ToString();
            add = ttAdd.Text.ToString();
            num = ttNum.Text.ToString();
        }
    }
}
