using CsvHelper;
using ListViewSorter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visual_MI {

    
    public partial class Main : Form {
        public string version = "1.4.0";
        public string title;
        public void changeTitle (string nt) {
            this.Text = nt + " - Visual MI " + version;
        }
        public bool HasNextID = true;
        private ListViewColumnSorter lvwColumnSorter;
        public Main() {
            InitializeComponent();


            lvwColumnSorter = new ListViewColumnSorter();
            this.lv.ListViewItemSorter = lvwColumnSorter;
            this.lv.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lv.AutoArrange = true;

            lvwColumnSorter._SortModifier = ListViewColumnSorter.SortModifiers.SortByText;
            this.Text = "Visual MI " +version;
        }

        private void Form1_Load(object sender, EventArgs e) {
            try {
                using (StreamReader readtext = new StreamReader("config")) {
                    string l = readtext.ReadLine();
                    ttsa.Text = l;
                }
            } catch { }
           
            
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            HasNextID = true;
            while (HasNextID) {
                try {
                    Details q = new Details(int.Parse(ttsa.Text.ToString()));
                    q.z = this;
                    DialogResult x = q.ShowDialog();
                    if (x == DialogResult.No) {
                        HasNextID = false;
                    }
                } catch (System.FormatException) {
                    MessageBox.Show("Invalid ID number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    HasNextID = false;
                }
            }
           
            

        }

        private void button1_Click(object sender, EventArgs e) {
            sfd.ShowDialog();
        }

        private void lv_DoubleClick(object sender, EventArgs e) {
            EditSelectedItem();
        }


        private void EditSelectedItem() {
            try {
                ListViewItem d = lv.SelectedItems[0];
                Details q = new Details(int.Parse(d.Text.ToString()),
                   d.SubItems[1].Text, d.SubItems[2].Text, d.SubItems[3].Text, d.SubItems[4].Text, d.SubItems[5].Text, d.SubItems[6].Text, d.SubItems[7].Text, d.SubItems[8].Text
                    );
                // Clone of Add
                q.z = this;
                DialogResult x = q.ShowDialog();
                lv.SelectedItems[0].Remove();
            } catch (Exception e) { }
            
        }

        private void listView1_ColumnClick(object sender,
                   System.Windows.Forms.ColumnClickEventArgs e) {
            ListView myListView = (ListView)sender;

            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn) {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending) {
                    lvwColumnSorter.Order = SortOrder.Descending;
                } else {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            } else {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            myListView.Sort();
        }

        private void btnOpenFolder_Click(object sender, EventArgs e) {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Magic Input IDS";
            Process.Start(@path);
        }

        public bool cbstatus;
        public string path;
        private void btnExport_Click(object sender, EventArgs e) {
            ConfirmExport ce = new ConfirmExport();
            ce.z = this;
            DialogResult x = ce.ShowDialog();
            if (x != DialogResult.Yes) {
                return;
            }
            using (StreamWriter uit = new StreamWriter(path + ".txt")) {
                foreach (ListViewItem i in lv.Items) {
                    uit.WriteLine(i.SubItems[0].Text + "   " + i.SubItems[1].Text);
                }
            }

            String header = "ID1;NAME1;DESIG1;SSS1;LIC1;TIN1;EMER1;ADD1;NUM1;"
                         + "ID2;NAME2;DESIG2;SSS2;LIC2;TIN2;EMER2;ADD2;NUM2;"
                         + "ID3;NAME3;DESIG3;SSS3;LIC3;TIN3;EMER3;ADD3;NUM3;"
                         + "ID4;NAME4;DESIG4;SSS4;LIC4;TIN4;EMER4;ADD4;NUM4";

            if (cbstatus) {
                using (StreamWriter writetext = new StreamWriter("config")) {
                    writetext.WriteLine(ttsa.Text);
                }
            }
            
                using (StreamWriter uit = new StreamWriter(path)) {

                    uit.Write(header);

                    int runCount = 1;
                    foreach (ListViewItem i in lv.Items) {
                        if (runCount == 1) {
                            uit.WriteLine();
                        } else
                            uit.Write(";");

                        MessageBox.Show(i.SubItems[0].Text);
                        uit.Write("\"{0}\";\"{1}\";\"{2}\";\"{3}\";\"{4}\";\"{5}\";\"{6}\";\"{7}\";\"{8}\"",
                            i.SubItems[0].Text,
                            i.SubItems[1].Text,
                            i.SubItems[2].Text,
                            i.SubItems[3].Text,
                            i.SubItems[3].Text,
                            i.SubItems[4].Text,
                            (i.SubItems[6].Text == "") ?
                                i.SubItems[5].Text :
                                i.SubItems[5].Text + " (" + i.SubItems[6].Text + ")",
                            i.SubItems[7].Text,
                            i.SubItems[8].Text
                            );
                        runCount++;
                        if (runCount == 5)
                            runCount = 1;
                    }


                }


                MessageBox.Show("Export Complete!", "Export to CSV", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            
        }

        private void lv_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Delete) {
                DialogResult x = MessageBox.Show("Are you sure you want to delete "+lv.SelectedItems[0].SubItems[1].Text.ToString()+"?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (x==DialogResult.Yes) {
                    DeletedSelectedItem();
                }
            }
        }

        private void DeletedSelectedItem() {
            foreach (ListViewItem eachItem in lv.SelectedItems) {
                lv.Items.Remove(eachItem);
                RefreshNumbering();
            }
        }

        private void RefreshNumbering() {
            try {
                int FirstItem = int.Parse(lv.Items[0].Text.ToString());
                foreach (ListViewItem lvi in lv.Items) {
                    lvi.Text = FirstItem.ToString();
                    FirstItem++;
                }
            } catch (Exception) { }
            
        }

        private void lv_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e) {

        }

        private void toolStripButton5_Click(object sender, EventArgs e) {
            try {
                DialogResult x = MessageBox.Show("Are you sure you want to delete " + lv.SelectedItems[0].SubItems[1].Text.ToString() + "?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (x == DialogResult.Yes) {
                    DeletedSelectedItem();
                }
            } catch (Exception) { }
            
        }

        private void toolStripButton4_Click(object sender, EventArgs e) {
            EditSelectedItem();
        }

        private void toolStripButton2_Click(object sender, EventArgs e) {
            ofd.ShowDialog();
            String OpenPath = ofd.FileName;
            ParseCSV(OpenPath);
            String[] Fname = OpenPath.Split('\\');
            changeTitle(Fname[Fname.Length - 1]);

        }

        private void ParseCSV(String path) {
            
            DataTable dt = CSVReadToDataTable(path);
            //dgv.DataSource = dt;
            FillListView(dt, lv);
         }


        public static void FillListView(DataTable src, ListView dst) {
            
            foreach (DataRow row in src.Rows) {
                ListViewItem lvi = new ListViewItem(row[0].ToString());
                for (int c = 1; c < 9; c++) {
                    if (c == 4) continue;
                    //Hotsopts: 6, 15, 24, 33;
                    string q = row[c].ToString();
                    if (c==6) {
                        if (q.Contains("(")) {
                            String emer = q.Split('(')[0].Trim();
                            String rel = q.Split('(')[1].Split(')')[0].Trim();
                       
                            lvi.SubItems.Add(emer);
                            lvi.SubItems.Add(rel);
                        } else {
                         
                            lvi.SubItems.Add(q);
                            lvi.SubItems.Add("");
                        }
                    } else lvi.SubItems.Add(q);


                    
                    
                }
                dst.Items.Add(lvi);

               lvi = new ListViewItem(row[9].ToString());
                for (int c = 10; c < 18; c++) {
                    if (c == 13) continue;
                    //Hotsopts: 6, 15, 24, 33;
                    string q = row[c].ToString();
                    if (c == 15) {
                        if (q.Contains("(")) {
                            String emer = q.Split('(')[0].Trim();
                            String rel = q.Split('(')[1].Split(')')[0].Trim();
                            //c++;
                            lvi.SubItems.Add(emer);
                            lvi.SubItems.Add(rel);
                        } else {
                            //c++;
                            lvi.SubItems.Add(q);
                            lvi.SubItems.Add("");
                        }
                    } else lvi.SubItems.Add(q);

                }
                dst.Items.Add(lvi);

                lvi = new ListViewItem(row[18].ToString());
                for (int c = 19; c < 27; c++) {
                    if (c == 22) continue;
                    //Hotsopts: 6, 15, 24, 33;
                    string q = row[c].ToString();
                    if (c == 24) {
                        if (q.Contains("(")) {
                            String emer = q.Split('(')[0].Trim();
                            String rel = q.Split('(')[1].Split(')')[0].Trim();
                            
                            lvi.SubItems.Add(emer);
                            lvi.SubItems.Add(rel);
                        } else {
                            
                            lvi.SubItems.Add(q);
                            lvi.SubItems.Add("");
                        }
                    } else lvi.SubItems.Add(q);

                }
                dst.Items.Add(lvi);

                lvi = new ListViewItem(row[27].ToString());
                for (int c = 28; c < 36; c++) {
                    if (c == 31) continue;
                    string q = row[c].ToString();
                    if (c == 33) {
                        if (q.Contains("(")) {
                            String emer = q.Split('(')[0].Trim();
                            String rel = q.Split('(')[1].Split(')')[0].Trim();
                       
                            lvi.SubItems.Add(emer);
                            lvi.SubItems.Add(rel);
                        } else {
                          
                            lvi.SubItems.Add(q);
                            lvi.SubItems.Add("");
                        }
                    } else lvi.SubItems.Add(q);

                }
                dst.Items.Add(lvi);
            }
        }

        /* BASE CODE, 4 ALL
        // Assuming you know the structure of the data table.
        public static void FillListView (DataTable src, ListView dst) {
            foreach (DataRow row in src.Rows) {
                ListViewItem lvi = new ListViewItem();
                for (int c=0; c<src.Columns.Count; c++) {
                    lvi.SubItems.Add(row[c].ToString());
                }
                dst.Items.Add(lvi);
            }
        }*/


        public static List<string> ReadInCSV(string absolutePath) {
            List<string> result = new List<string>();
            string value;
            using (TextReader fileReader = File.OpenText(absolutePath)) {
                var csv = new CsvReader(fileReader);
                csv.Configuration.Delimiter = ";";
                csv.Configuration.HasHeaderRecord = false;
                while (csv.Read()) {
                    for (int i = 0; csv.TryGetField<string>(i, out value); i++) {
                        result.Add(value);
                    }
                }
            }
            return result;
        }

        public static DataTable CSVReadToDataTable(string path) {
            DataTable dt = new DataTable();
            bool frun = true;
            using (TextReader fileReader = File.OpenText(path)) {
                var csv = new CsvReader(fileReader);
                csv.Configuration.Delimiter = ";";
                csv.Configuration.HasHeaderRecord = true;
                
                while (csv.Read()) {
                    /// Rename Fields:
                    if (frun) {
                        for (int c = 0; c < csv.FieldHeaders.Count(); c++) dt.Columns.Add(new DataColumn());
                        for (int d = 0; d < csv.FieldHeaders.Count(); d++) {
                            dt.Columns[d].ColumnName = csv.FieldHeaders[d];
                        }
                        frun = false;
                    }
                    var row = dt.NewRow();
                    foreach (DataColumn column in dt.Columns) {
                        row[column.ColumnName] = csv.GetField(column.DataType, column.ColumnName);
                        
                    }
                    dt.Rows.Add(row);
                }
            }

            return dt;
            
        }

        
    }
}
