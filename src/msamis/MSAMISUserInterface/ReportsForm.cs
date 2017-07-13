using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSAMISUserInterface {
    public partial class ReportsForm : Form {
        public MySqlConnection conn;

        public ReportsForm() {
            InitializeComponent();
            conn = SQLTools.conn;
        }
    }
}
