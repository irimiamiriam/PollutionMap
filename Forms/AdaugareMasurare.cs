using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PollutionMap.Forms
{
    public partial class AdaugareMasurare : Form
    {
        public int val = 0;
        public AdaugareMasurare()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            val= Convert.ToInt32(textBox1.Text);
            this.Close();
        }
    }
}
