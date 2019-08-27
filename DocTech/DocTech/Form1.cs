using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace DocTech
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //string[] files = System.IO.Directory.GetFiles(@"C:\petrolight\__НОВ КД", "4372*", System.IO.SearchOption.AllDirectories);
            //foreach (string file in files)
            //{
            //    listBox1.Items.Add(System.IO.Path.GetFileName(file));                
            //}
            //treeViewElements.ContextMenuStrip = contextMenuStrip1;
            //treeViewElements.ContextMenuStrip = contextMenuStripDetails;

            treeViewElements.NodeMouseClick += treeViewElements_NodeMouseClick;
        }

        private void treeViewElements_AfterSelect(object sender, TreeViewEventArgs e)
        {
            listBox1.Items.Clear();
            if (treeViewElements.SelectedNode.Tag.ToString() == "File")
            {
                List<string> elements = ClassDBRequests.getRelation(treeViewElements.SelectedNode.Text, "Details", "Files", "Det_Files");
                if (elements.Count() != 0)
                {
                    listBox1.Items.Add("Детали");
                    foreach (string element in elements)
                    {
                        listBox1.Items.Add(element);
                    }
                }

                elements = ClassDBRequests.getRelation(treeViewElements.SelectedNode.Text, "Devices", "Files", "Dev_Files");
                if (elements.Count() != 0)
                {
                    listBox1.Items.Add("Устройства");
                    foreach (string element in elements)
                    {
                        listBox1.Items.Add(element);
                    }
                }

                elements = ClassDBRequests.getRelation(treeViewElements.SelectedNode.Text, "Systems", "Files", "Sys_Files");
                if (elements.Count() != 0)
                {
                    listBox1.Items.Add("Системы");
                    foreach (string element in elements)
                    {
                        listBox1.Items.Add(element);
                    }
                }
            }
            else if (treeViewElements.SelectedNode.Tag.ToString() == "Detail")
            {
                List<string> elements = ClassDBRequests.getRelation(treeViewElements.SelectedNode.Text, "Files", "Details", "Det_Files");
                if (elements.Count() != 0)
                {
                    listBox1.Items.Add("Документы");
                    foreach (string element in elements)
                    {
                        listBox1.Items.Add(element);
                    }
                }

                elements = ClassDBRequests.getRelation(treeViewElements.SelectedNode.Text, "Devices", "Details", "Dev_Det");
                if (elements.Count() != 0)
                {
                    listBox1.Items.Add("Устройства");
                    foreach (string element in elements)
                    {
                        listBox1.Items.Add(element);
                    }
                }
            }
            else if (treeViewElements.SelectedNode.Tag.ToString() == "Device")
            {
                List<string> elements = ClassDBRequests.getRelation(treeViewElements.SelectedNode.Text, "Files", "Devices", "Dev_Files");
                if (elements.Count() != 0)
                {
                    listBox1.Items.Add("Документы");
                    foreach (string element in elements)
                    {
                        listBox1.Items.Add(element);
                    }
                }

                elements = ClassDBRequests.getRelation(treeViewElements.SelectedNode.Text, "Details", "Devices", "Dev_Det");
                if (elements.Count() != 0)
                {
                    listBox1.Items.Add("Детали");
                    foreach (string element in elements)
                    {
                        listBox1.Items.Add(element);
                    }
                }

                

                elements = ClassDBRequests.getRelation(treeViewElements.SelectedNode.Text, "Systems", "Devices", "Sys_Dev");
                if (elements.Count() != 0)
                {
                    listBox1.Items.Add("Системы");
                    foreach (string element in elements)
                    {
                        listBox1.Items.Add(element);
                    }
                }
            }
            else if (treeViewElements.SelectedNode.Tag.ToString() == "System")
            {
                List<string> elements = ClassDBRequests.getRelation(treeViewElements.SelectedNode.Text, "Files", "Systems", "Sys_Files");
                if (elements.Count() != 0)
                {
                    listBox1.Items.Add("Детали");
                    foreach (string element in elements)
                    {
                        listBox1.Items.Add(element);
                    }
                }

                elements = ClassDBRequests.getRelation(treeViewElements.SelectedNode.Text, "Devices", "Systems", "Sys_Dev");
                if (elements.Count() != 0)
                {
                    listBox1.Items.Add("Документы");
                    foreach (string element in elements)
                    {
                        listBox1.Items.Add(element);
                    }
                }                
            }
        }


        private void treeViewElements_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // Убедитесь, что это правая кнопка.
            if (e.Button != MouseButtons.Right) return;

            // Выберите этот узел.
            
            TreeNode node_here = treeViewElements.GetNodeAt(e.X, e.Y);
            
            treeViewElements.SelectedNode = node_here;

            // Посмотрим, есть ли у нас узел.
            if (node_here == null) return;
            //contextMenuStripFiles.Show(treeViewElements, new Point(e.X, e.Y));
            // Посмотрим, что это за объект и
            // отобразим соответствующее всплывающее меню.
            if (node_here.Tag is "Details")
                contextMenuStripDetails.Show(treeViewElements, new Point(e.X, e.Y));
            else if (node_here.Tag is "Devices")
                contextMenuStripDevices.Show(treeViewElements, new Point(e.X, e.Y));
            else if (node_here.Tag is "Systems")
                contextMenuStripSystems.Show(treeViewElements, new Point(e.X, e.Y));
            else if (node_here.Tag is "Documents")
                contextMenuStripFiles.Show(treeViewElements, new Point(e.X, e.Y));
            else if (node_here.Tag is "File")
                contextMenuStripFile.Show(treeViewElements, new Point(e.X, e.Y));
            else if (node_here.Tag is "Detail")
                contextMenuStripDetail.Show(treeViewElements, new Point(e.X, e.Y));
            else if (node_here.Tag is "Device")
                contextMenuStripDevice.Show(treeViewElements, new Point(e.X, e.Y));
            else if (node_here.Tag is "System")
                contextMenuStripSystem.Show(treeViewElements, new Point(e.X, e.Y));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Заполнение узла Документы
            TreeNode filesNode = new TreeNode();
            filesNode.Name = "allFiles";
            filesNode.Text = "Все документы";
            filesNode.Tag = "Documents";
            treeViewElements.Nodes.Add(filesNode);
            fillNodes("Files");            


            //Заполнение узла Детали
            TreeNode detailsNode = new TreeNode();
            detailsNode.Name = "allDetails";
            detailsNode.Text = "Детали";
            detailsNode.Tag = "Details";
            treeViewElements.Nodes.Add(detailsNode);
            fillNodes("Details");            


            //Заполнение узла Устройства
            TreeNode devicesNode = new TreeNode();
            devicesNode.Name = "allDevices";
            devicesNode.Text = "Устройства";
            devicesNode.Tag = "Devices";
            treeViewElements.Nodes.Add(devicesNode);
            fillNodes("Devices");            


            //Заполнение узла Системы
            TreeNode systemsNode = new TreeNode();
            systemsNode.Name = "allSystems";
            systemsNode.Text = "Системы";
            systemsNode.Tag = "Systems";
            treeViewElements.Nodes.Add(systemsNode);
            fillNodes("Systems");            
        }

        private void butAddDocToDet_Click(object sender, EventArgs e)
        {
            //string detName = treeViewElements.SelectedNode.Text;
            //Form formDocuments = new FormDocumentList();
            //formDocuments.Show();
        }

        
        //Добавление новой детали
        private void добавитьДетальToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form newFormElement = new FormNewElement();
            newFormElement.Tag = "forDetail";
            newFormElement.ShowDialog();
            treeViewElements.Nodes[1].Nodes.Clear();
            fillNodes("Details");           
        }

        //Добавление нового устройства
        private void добавитьУстройствоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form newFormElement = new FormNewElement();
            newFormElement.Tag = "forDevice";
            newFormElement.ShowDialog();
            treeViewElements.Nodes[2].Nodes.Clear();
            fillNodes("Devices");            
        }

        //Добавление новой системы
        private void добавитьСистемуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form newFormElement = new FormNewElement();
            newFormElement.Tag = "forSystem";
            newFormElement.ShowDialog();
            treeViewElements.Nodes[3].Nodes.Clear();
            fillNodes("Systems");
        }

        //Заполнение дочерних узлов (Файлы, Детали, Устройства, Системы)
        public void fillNodes(string table)
        {
            List<string> listElements = ClassDBRequests.getNameElements(table);
            
            foreach (string element in listElements)
            {
                TreeNode node = new TreeNode();
                node.Name = element.Split(' ')[0];
                node.Text = element;
                int nodeNumber;
                switch (table)
                {
                    case "Files":
                        node.Tag = "File";
                        nodeNumber = 0;
                        break;
                    case "Details":
                        node.Tag = "Detail";
                        nodeNumber = 1;
                        break;
                    case "Devices":
                        node.Tag = "Device";
                        nodeNumber = 2;
                        break;
                    case "Systems":
                        node.Tag = "System";
                        nodeNumber = 3;
                        break;
                    default:
                        nodeNumber = 100; //чтобы в случае херни не писало никуда
                        break;
                }                
                treeViewElements.Nodes[nodeNumber].Nodes.Add(node);
            }
        }

        private void добавитьДокументToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string fileName = openFileDialog1.FileName;
            ClassDBRequests.SaveFileToDatabase(fileName);
            fillNodes("Files");
        }
        
        //Добавить документ к детали
        private void документыToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //string detName = treeViewElements.SelectedNode.Text;
            Form formDocuments = new FormDocumentList(treeViewElements.SelectedNode.Tag.ToString(), treeViewElements.SelectedNode.Text, "File", "Det_Files");
            //formDocuments.Tag = treeViewElements.SelectedNode.Text;
            formDocuments.ShowDialog();
            List<string> elements = ClassDBRequests.getRelation(treeViewElements.SelectedNode.Text, "Files", "Details", "Det_Files");
            if (elements.Count() != 0)
            {
                listBox1.Items.Add("Документы");
                foreach (string element in elements)
                {
                    listBox1.Items.Add(element);
                }
            }

            elements = ClassDBRequests.getRelation(treeViewElements.SelectedNode.Text, "Devices", "Details", "Dev_Det");
            if (elements.Count() != 0)
            {
                listBox1.Items.Add("Устройства");
                foreach (string element in elements)
                {
                    listBox1.Items.Add(element);
                }
            }
        }

        //Добавить документ к устройству
        private void документыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formDocuments = new FormDocumentList(treeViewElements.SelectedNode.Tag.ToString(), treeViewElements.SelectedNode.Text, "File", "Dev_Files");
            //formDocuments.Tag = treeViewElements.SelectedNode.Text;
            formDocuments.ShowDialog();
            List<string> elements = ClassDBRequests.getRelation(treeViewElements.SelectedNode.Text, "Files", "Devices", "Dev_Files");
            if (elements.Count() != 0)
            {
                listBox1.Items.Add("Документы");
                foreach (string element in elements)
                {
                    listBox1.Items.Add(element);
                }
            }

            elements = ClassDBRequests.getRelation(treeViewElements.SelectedNode.Text, "Details", "Devices", "Dev_Det");
            if (elements.Count() != 0)
            {
                listBox1.Items.Add("Детали");
                foreach (string element in elements)
                {
                    listBox1.Items.Add(element);
                }
            }
        }

        //Добавить деталь к устройству
        private void детальToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formDocuments = new FormDocumentList(treeViewElements.SelectedNode.Tag.ToString(), treeViewElements.SelectedNode.Text, "Detail", "Dev_Det");
            //formDocuments.Tag = treeViewElements.SelectedNode.Text;
            formDocuments.ShowDialog();
        }
    }
}
