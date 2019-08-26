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
        public FormDocumentList()
        {
            InitializeComponent();
        }

        private void FormDocumentList_Load(object sender, EventArgs e)
        {
            List<string> documents = ClassDBRequests.getNameElements("Files");
            foreach (string doc in documents)
            {
                listBoxDocuments.Items.Add(doc);
            }
        }
    }
}
