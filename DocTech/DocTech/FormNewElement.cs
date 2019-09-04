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
    public partial class FormNewElement : Form
    {
        public FormNewElement()
        {
            InitializeComponent();
            
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if ((textBoxNumber.Text != "") & (textBoxName.Text != ""))
            {
                switch (this.Tag.ToString())
                {
                    case "forDetail":
                        ClassDBRequests.newElement("Details", textBoxNumber.Text, textBoxName.Text);
                        Variables.needRefresh = true;
                        this.Close();
                        break;
                    case "forDevice":
                        ClassDBRequests.newElement("Devices", textBoxNumber.Text, textBoxName.Text);
                        Variables.needRefresh = true;
                        this.Close();
                        break;
                    case "forSystem":
                        ClassDBRequests.newElement("Systems", textBoxNumber.Text, textBoxName.Text);
                        Variables.needRefresh = true;
                        this.Close();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Поля не заполнены","Внимание!");
            }
        }

        private void FormNewDetail_Load(object sender, EventArgs e)
        {
            Variables.needRefresh = false;
        }
    }
}
