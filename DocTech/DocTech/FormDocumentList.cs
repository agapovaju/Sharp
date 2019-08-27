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
    public partial class FormDocumentList : Form
    {
        private string cType;
        private string eType;
        private string cName;
        private string rTable;

        public FormDocumentList(string containerType, string containerName, string elementType, string table)
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
            List<string> documents = ClassDBRequests.getNameElements(str);
            foreach (string doc in documents)
            {
                checkedListBoxDocuments.Items.Add(doc);
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