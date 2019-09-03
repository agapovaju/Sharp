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
    public partial class FormRemoveRelation : Form
    {
        int containerId = new int();
        int elementId = new int();
        string cType = Variables.containerType;
        string cName = Variables.containerName;
        string eType = Variables.elementType;
        string tbl = Variables.table;

        public FormRemoveRelation()
        {
            InitializeComponent();
        }

        private void FormRemoveRelation_Load(object sender, EventArgs e)
        {
            List<string> elements = ClassDBRequests.getRelation(Variables.containerName, "Files", "Details", "Det_Files");
            foreach (string element in elements)
            {
                checkedListBox1.Items.Add(element);
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count != 0)
            {
                containerId = ClassDBRequests.getId(cName, cType);
                foreach (string element in checkedListBox1.CheckedItems)
                {
                    elementId = ClassDBRequests.getId(element, eType);
                    ClassDBRequests.removeRelation(containerId, elementId, tbl);
                }
                Variables.needRefresh = true;
                this.Close();
            }
            else
            {
                Variables.needRefresh = false;
                MessageBox.Show("Не выбраны связи для удаления", "Внимание!");                
            }
        }
    }
}
