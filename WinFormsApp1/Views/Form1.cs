using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public ModelViews.Manager HumanManager { get; set; }
        public Form1()
        {
            InitializeComponent();
            HumanManager = new ModelViews.Manager();
            HumanManager.HumansListChanged += UpdateListBox;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(textBox1.Text))
            {
                HumanManager.AddHuman(textBox1.Text, "", 5);
            }
        }
        void UpdateListBox()
        {
            listBox1.Items.Clear();
            foreach (var human in HumanManager.GetHumansNames())
            {
                listBox1.Items.Add(human);
            }
        }
    }
}
