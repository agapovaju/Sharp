using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocTech
{
    public partial class FormRemovingElements : Form
    {
        private string tbl;
        public FormRemovingElements(string table)
        {
            InitializeComponent();
            tbl = table;
        }

        private void RemovingElements_Load(object sender, EventArgs e)
        {
            List<string> elements = ClassDBRequests.getNameElements(tbl);
            foreach (string element in elements)
            {
                checkedListBox1.Items.Add(element);
            }            
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            string elementType = "";
            switch (tbl)
            {
                case "Files":
                    elementType = "File";
                    break;
                case "Details":
                    elementType = "Detail";
                    break;
                case "Devices":
                    elementType = "Device";
                    break;
                case "Systems":
                    elementType = "System";
                    break;
            }
            if (checkedListBox1.CheckedItems.Count != 0)
            {
                foreach (string element in checkedListBox1.CheckedItems)
                {
                    ClassDBRequests.removeElement(element, elementType);
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Не выбраны элементы для удаления", "Внимание!");
            }
            
        }
    }
}
