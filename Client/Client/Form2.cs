using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        int index = 0;
        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.A)
            {
                index++;
            }
            if(index==5)
            {
                this.Close();
            }
            else
            {
                e.Handled = true;
            }
          
        }
    }
}
