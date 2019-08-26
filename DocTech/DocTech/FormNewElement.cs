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
            //if (this.Tag.ToString() == "forDetail")
            //{
            //    if ((textBoxNumber.Text != null) & (textBoxName.Text != null))
            //    {
            //        ClassDBRequests.newDetail(textBoxNumber.Text, textBoxName.Text);
            //        this.Close();
            //    }
            //}
            switch (this.Tag.ToString())
            {
                case "forDetail":
                    if ((textBoxNumber.Text != null) & (textBoxName.Text != null))
                    {
                        ClassDBRequests.newElement("Details", textBoxNumber.Text, textBoxName.Text);
                        this.Close();
                    }
                    break;
                case "forDevice":
                    if ((textBoxNumber.Text != null) & (textBoxName.Text != null))
                    {
                        ClassDBRequests.newElement("Devices", textBoxNumber.Text, textBoxName.Text);
                        this.Close();
                    }
                    break;
                case "forSystem":
                    if ((textBoxNumber.Text != null) & (textBoxName.Text != null))
                    {
                        ClassDBRequests.newElement("Systems", textBoxNumber.Text, textBoxName.Text);
                        this.Close();
                    }
                    break;
            }
            
        }

        private void FormNewDetail_Load(object sender, EventArgs e)
        {
            
        }
    }
}
