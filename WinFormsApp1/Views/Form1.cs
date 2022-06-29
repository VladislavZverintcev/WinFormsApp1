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
            HumanManager.HumanNameChanged += RenameItem;
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem != null)
            {
                textBox2.Enabled = true;
                textBox2.Text = listBox1.SelectedItem as string;
            }
            else
            {
                textBox2.Enabled = false;
            }

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            HumanManager.RenameHuman(listBox1.SelectedItem as string, textBox2.Text);
        }
        private void RenameItem(string oldName, string newName)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if ((string)listBox1.Items[i] == oldName)
                {
                    listBox1.Items[listBox1.Items.IndexOf(listBox1.Items[i])] = newName;
                }
            }
        }
    }
}
