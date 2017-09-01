using CostCalc.DataClass;
using CostCalc.DataHandlers;
using System.Windows.Forms;

namespace CostCalc.UI
{
    public partial class MaterialUi : Form
    {
        private MaterialHandler materialHandler;

        public MaterialUi(MaterialHandler handler)
        {
            this.materialHandler = handler;
            InitializeComponent();
        }

        private void MaterialUi_Shown(object sender, System.EventArgs e)
        {
            this.treeView1.Nodes.Clear();
            foreach (Material m in this.materialHandler.Materials)
            {
                this.treeView1.Nodes.Add(new ViewAdapter(m));
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null && e.Node is ViewAdapter)
            {
                this.propertyGrid1.SelectedObject = ((ViewAdapter)e.Node).Material;
            }
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            var m = new Material() { Name = "New Material" };
            this.materialHandler.Materials.Add(m);
            this.treeView1.Nodes.Add(new ViewAdapter(m));
        }
    }
}
