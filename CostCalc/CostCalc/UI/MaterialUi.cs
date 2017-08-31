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

        }
    }
}
