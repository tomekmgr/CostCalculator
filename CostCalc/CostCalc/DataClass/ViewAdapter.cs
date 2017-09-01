using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CostCalc.DataClass
{
    public class ViewAdapter : TreeNode
    {
        public Material Material { get; private set; }

        public ViewAdapter(Material m)
        {
            this.Material = m;
            this.Text = this.Material.Name;
        }
    }
}
