using CostCalc.DataHandlers;
using CostCalc.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CostCalc
{
    public partial class mainForm : Form
    {
        private string DataFolder = "Data";
        private MaterialHandler material;

        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Shown(object sender, EventArgs e)
        {
            this.material = MaterialHandler.Initialize(DataFolder);
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.material.Save();
        }

        private void materialDatabaseBtn_Click(object sender, EventArgs e)
        {
            MaterialUi ui = new MaterialUi(this.material);
            ui.ShowDialog();
        }
    }
}
