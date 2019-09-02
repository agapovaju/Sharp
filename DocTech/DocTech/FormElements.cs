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
    public partial class FormEDocumentList : Form
    {
        private string cType;
        private string eType;
        private string cName;
        private string rTable;

        public FormEDocumentList(string containerType, string containerName, string elementType, string table)
        {
            InitializeComponent();
            cType = containerType;
            eType = elementType;
            cName = containerName;
            rTable = table;
        }

        private void FormDocumentList_Load(object sender, EventArgs e)
        {
            string str = eType + "s";
            List<string> elements = ClassDBRequests.getNameElements(str);
            foreach (string element in elements)
            {
                checkedListBoxDocuments.Items.Add(element);
            }
        }

        private void checkedListBoxDocuments_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxCheckedFiles.Items.Clear();
            foreach (string file in checkedListBoxDocuments.CheckedItems)
            {
                listBoxCheckedFiles.Items.Add(file);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            foreach (string file in listBoxCheckedFiles.Items)
            {
                ClassDBRequests.newRelation(eType, cType, file, cName, rTable);
            }
            this.Close();
        }
    }
}