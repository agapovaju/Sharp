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
using System.IO;


namespace DocTech
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            treeViewElements.NodeMouseClick += treeViewElements_NodeMouseClick;
        }

        private void treeViewElements_AfterSelect(object sender, TreeViewEventArgs e)
        {
            listBox1.Items.Clear();
            //Заполнение ListBox
            //Если выбран документ
            if ((treeViewElements.SelectedNode.Tag.ToString() == "File") || (treeViewElements.SelectedNode.Tag.ToString() == "FileR"))
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
            //Если выбрана деталь
            else if ((treeViewElements.SelectedNode.Tag.ToString() == "Detail") || (treeViewElements.SelectedNode.Tag.ToString() == "DetailR"))
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
            //Если выбрано устройство
            else if ((treeViewElements.SelectedNode.Tag.ToString() == "Device") || (treeViewElements.SelectedNode.Tag.ToString() == "DeviceR"))
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
            //Если выбрана система
            else if (treeViewElements.SelectedNode.Tag.ToString() == "System")
            {
                List<string> elements = ClassDBRequests.getRelation(treeViewElements.SelectedNode.Text, "Files", "Systems", "Sys_Files");
                if (elements.Count() != 0)
                {
                    listBox1.Items.Add("Документы");
                    foreach (string element in elements)
                    {
                        listBox1.Items.Add(element);
                    }
                }

                elements = ClassDBRequests.getRelation(treeViewElements.SelectedNode.Text, "Devices", "Systems", "Sys_Dev");
                if (elements.Count() != 0)
                {
                    listBox1.Items.Add("Устройства");
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
            this.MaximumSize = new System.Drawing.Size(1100, 900);
            this.MinimumSize = new System.Drawing.Size(1050,600);
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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
            if (Variables.needRefresh)
            {
                treeViewElements.Nodes[1].Nodes.Clear();
                fillNodes("Details");
            }            
        }

        //Добавление нового устройства
        private void добавитьУстройствоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form newFormElement = new FormNewElement();
            newFormElement.Tag = "forDevice";
            newFormElement.ShowDialog();
            if (Variables.needRefresh)
            {
                treeViewElements.Nodes[2].Nodes.Clear();
                fillNodes("Devices");
            }
        }

        //Добавление новой системы
        private void добавитьСистемуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form newFormElement = new FormNewElement();
            newFormElement.Tag = "forSystem";
            newFormElement.ShowDialog();
            if (Variables.needRefresh)
            {
                treeViewElements.Nodes[3].Nodes.Clear();
                fillNodes("Systems");
            }
        }

        //Заполнение дочерних узлов (Файлы, Детали, Устройства, Системы)
        public void fillNodes(string table)
        {
            List<string> listElements = ClassDBRequests.getNameElements(table);

            int nodeNumber = new int();
            string tag = "";
            switch (table)
            {
                case "Files":
                    tag = "File";
                    nodeNumber = 0;
                    break;
                case "Details":
                    tag = "Detail";
                    nodeNumber = 1;
                    break;
                case "Devices":
                    tag = "Device";
                    nodeNumber = 2;
                    break;
                case "Systems":
                    tag = "System";
                    nodeNumber = 3;
                    break;
            }
            foreach (string element in listElements)
            {
                TreeNode node = new TreeNode();
                node.Name = element.Split(' ')[0];
                node.Text = element;
                node.Tag = tag;
                treeViewElements.Nodes[nodeNumber].Nodes.Add(node);                
            }
            int count = 0;
            switch (table)
            {
                case "Details":
                    TreeNodeCollection detailCollection = treeViewElements.Nodes[1].Nodes;
                    count =  0;
                    foreach (TreeNode detail in detailCollection)
                    {
                        List<string> elements = ClassDBRequests.getRelation(detail.Text, "Files", "Details", "Det_Files");
                        foreach (string element in elements)
                        {
                            TreeNode doc = new TreeNode();
                            doc.Name = element.Split(' ')[0];
                            doc.Text = element;
                            doc.Tag = "FileR";
                            treeViewElements.Nodes[1].Nodes[count].Nodes.Add(doc);
                        }
                        count++;
                    }
                    break;
                case "Devices":
                    TreeNodeCollection deviceCollection = treeViewElements.Nodes[2].Nodes;
                    count = 0;
                    foreach (TreeNode device in deviceCollection)
                    {
                        List<string> elements = ClassDBRequests.getRelation(device.Text, "Details", "Devices", "Dev_Det");
                        foreach (string element in elements)
                        {
                            TreeNode el = new TreeNode();
                            el.Name = element.Split(' ')[0];
                            el.Text = element;
                            el.Tag = "DetailR";
                            treeViewElements.Nodes[2].Nodes[count].Nodes.Add(el);
                        }
                        count++;
                    }

                    count = 0;
                    foreach (TreeNode device in deviceCollection)
                    {
                        List<string> elements = ClassDBRequests.getRelation(device.Text, "Files", "Devices", "Dev_Files");
                        foreach (string element in elements)
                        {
                            TreeNode doc = new TreeNode();
                            doc.Name = element.Split(' ')[0];
                            doc.Text = element;
                            doc.Tag = "FileR";
                            treeViewElements.Nodes[2].Nodes[count].Nodes.Add(doc);
                        }
                        count++;
                    }

                    count = 0;
                    foreach (TreeNode device in deviceCollection)
                    {
                        TreeNodeCollection deviceNodes = treeViewElements.Nodes[2].Nodes[count].Nodes;
                        int countD = 0;
                        foreach (TreeNode node in deviceNodes)
                        {
                            if (node.Tag.ToString() == "DetailR")
                            {
                                List<string> elements = ClassDBRequests.getRelation(node.Text, "Files", "Details", "Det_Files");
                                foreach (string element in elements)
                                {
                                    TreeNode doc = new TreeNode();
                                    doc.Name = element.Split(' ')[0];
                                    doc.Text = element;
                                    doc.Tag = "FileR";
                                    treeViewElements.Nodes[2].Nodes[count].Nodes[countD].Nodes.Add(doc);
                                }
                            }
                            countD++;
                        }
                        count++;
                    }
                    break;
                case "Systems":
                    TreeNodeCollection systemsCollection = treeViewElements.Nodes[3].Nodes;
                    count = 0;
                    foreach (TreeNode system in systemsCollection)
                    {
                        List<string> elements = ClassDBRequests.getRelation(system.Text, "Devices", "Systems", "Sys_Dev");
                        foreach (string element in elements)
                        {
                            TreeNode el = new TreeNode();
                            el.Name = element.Split(' ')[0];
                            el.Text = element;
                            el.Tag = "DeviceR";
                            treeViewElements.Nodes[3].Nodes[count].Nodes.Add(el);
                        }
                        count++;
                    }

                    count = 0;
                    foreach (TreeNode system in systemsCollection)
                    {
                        List<string> elements = ClassDBRequests.getRelation(system.Text, "Files", "Systems", "Sys_Files");
                        foreach (string element in elements)
                        {
                            TreeNode doc = new TreeNode();
                            doc.Name = element.Split(' ')[0];
                            doc.Text = element;
                            doc.Tag = "FileR";
                            treeViewElements.Nodes[3].Nodes[count].Nodes.Add(doc);
                        }
                        count++;
                    }

                    count = 0;
                    foreach (TreeNode system in systemsCollection)
                    {
                        TreeNodeCollection systemNodes = treeViewElements.Nodes[3].Nodes[count].Nodes;
                        int countD = 0;
                        foreach (TreeNode node in systemNodes)
                        {
                            if (node.Tag.ToString() == "DeviceR")
                            {
                                List<string> elements = ClassDBRequests.getRelation(node.Text, "Details", "Devices", "Dev_Det");
                                int countDet = 0;
                                foreach (string element in elements)
                                {
                                    TreeNode el = new TreeNode();
                                    el.Name = element.Split(' ')[0];
                                    el.Text = element;
                                    el.Tag = "DetailR";
                                    treeViewElements.Nodes[3].Nodes[count].Nodes[countD].Nodes.Add(el);
                                    List<string> files = ClassDBRequests.getRelation(element, "Files", "Details", "Det_Files");
                                    foreach (string file in files)
                                    {
                                        TreeNode fileNode = new TreeNode();
                                        fileNode.Name = file.Split(' ')[0];
                                        fileNode.Text = file;
                                        fileNode.Tag = "FileR";
                                        treeViewElements.Nodes[3].Nodes[count].Nodes[countD].Nodes[countDet].Nodes.Add(fileNode);
                                    }
                                    countDet++;
                                }

                                elements = ClassDBRequests.getRelation(node.Text, "Files", "Devices", "Dev_Files");
                                foreach (string element in elements)
                                {
                                    TreeNode doc = new TreeNode();
                                    doc.Name = element.Split(' ')[0];
                                    doc.Text = element;
                                    doc.Tag = "FileR";
                                    treeViewElements.Nodes[3].Nodes[count].Nodes[countD].Nodes.Add(doc);
                                }

                            }
                            countD++;
                        }
                        count++;
                    }
                    break;
            }            
        }

        
        //Добавление нового файла в базу
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
            Form formDocuments = new FormElements(treeViewElements.SelectedNode.Tag.ToString(), treeViewElements.SelectedNode.Text, "File", "Det_Files");
            //formDocuments.Tag = treeViewElements.SelectedNode.Text;
            formDocuments.ShowDialog();
            if (Variables.needRefresh)
            {
                listBox1.Items.Clear();
                List<string> elements = ClassDBRequests.getRelation(treeViewElements.SelectedNode.Text, "Files", "Details", "Det_Files");
                if (elements.Count() != 0)
                {
                    listBox1.Items.Add("Документы");
                    foreach (string element in elements)
                    {
                        listBox1.Items.Add(element);
                    }
                }

                treeViewElements.SelectedNode.Nodes.Clear();
                foreach (string element in elements)
                {
                    TreeNode file = new TreeNode();
                    file.Name = element.Split(' ')[0];
                    file.Text = element;
                    file.Tag = "File";
                    treeViewElements.SelectedNode.Nodes.Add(file);
                }
                //TreeNode selectedNode = treeViewElements.SelectedNode;
                //treeViewElements.Nodes[1].Nodes.Clear();
                //fillNodes("Details");
                treeViewElements.Nodes[2].Nodes.Clear();
                fillNodes("Devices");
                treeViewElements.Nodes[3].Nodes.Clear();
                fillNodes("Systems");
                //treeViewElements.SelectedNode = selectedNode;

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
        }

        //Добавить документ к устройству
        private void документыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formElements = new FormElements(treeViewElements.SelectedNode.Tag.ToString(), treeViewElements.SelectedNode.Text, "File", "Dev_Files");
            //formDocuments.Tag = treeViewElements.SelectedNode.Text;
            formElements.ShowDialog();
            listBox1.Items.Clear();
            
            List<string> elements = ClassDBRequests.getRelation(treeViewElements.SelectedNode.Text, "Files", "Devices", "Dev_Files");
            if (elements.Count() != 0)
            {
                listBox1.Items.Add("Документы");
                foreach (string element in elements)
                {
                    listBox1.Items.Add(element);                    
                }
            }            
                        
            //treeViewElements.Nodes[1].Nodes.Clear();
            //fillNodes("Details");
            treeViewElements.Nodes[2].Nodes.Clear();
            fillNodes("Devices");
            treeViewElements.Nodes[3].Nodes.Clear();
            fillNodes("Systems");

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
            Form formElements = new FormElements(treeViewElements.SelectedNode.Tag.ToString(), treeViewElements.SelectedNode.Text, "Detail", "Dev_Det");
            //formDocuments.Tag = treeViewElements.SelectedNode.Text;
            formElements.ShowDialog();
            listBox1.Items.Clear();
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

            treeViewElements.Nodes[2].Nodes.Clear();
            fillNodes("Devices");
            treeViewElements.Nodes[3].Nodes.Clear();
            fillNodes("Systems");
        }

        //Добавить документ к системе
        private void документыToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //string detName = treeViewElements.SelectedNode.Text;
            Form formElements = new FormElements(treeViewElements.SelectedNode.Tag.ToString(), treeViewElements.SelectedNode.Text, "File", "Sys_Files");
            //formDocuments.Tag = treeViewElements.SelectedNode.Text;
            formElements.ShowDialog();
            listBox1.Items.Clear();
            List<string> elements = ClassDBRequests.getRelation(treeViewElements.SelectedNode.Text, "Devices", "Systems", "Sys_Dev");
            if (elements.Count() != 0)
            {
                listBox1.Items.Add("Устройства");
                foreach (string element in elements)
                {
                    listBox1.Items.Add(element);
                }
            }

            elements = ClassDBRequests.getRelation(treeViewElements.SelectedNode.Text, "Files", "Systems", "Sys_Files");
            if (elements.Count() != 0)
            {
                listBox1.Items.Add("Документы");
                foreach (string element in elements)
                {
                    listBox1.Items.Add(element);
                    //TreeNode node = new TreeNode();
                    //node.Name = element.Split(' ')[0];
                    //node.Text = element;
                    //node.Tag = "FileR";
                    //treeViewElements.SelectedNode.Nodes.Add(node);
                }
            }

            treeViewElements.Nodes[3].Nodes.Clear();
            fillNodes("Systems");
            
        }

        //Добавить устройство к системе
        private void устройстваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formElements = new FormElements(treeViewElements.SelectedNode.Tag.ToString(), treeViewElements.SelectedNode.Text, "Device", "Sys_Dev");
            //formDocuments.Tag = treeViewElements.SelectedNode.Text;
            formElements.ShowDialog();
            listBox1.Items.Clear();
            List<string> elements = ClassDBRequests.getRelation(treeViewElements.SelectedNode.Text, "Files", "Systems", "Sys_Files");
            if (elements.Count() != 0)
            {
                listBox1.Items.Add("Документы");
                foreach (string element in elements)
                {
                    listBox1.Items.Add(element);
                }
            }

            elements = ClassDBRequests.getRelation(treeViewElements.SelectedNode.Text, "Devices", "Systems", "Sys_Dev");
            if (elements.Count() != 0)
            {
                listBox1.Items.Add("Устройства");
                foreach (string element in elements)
                {
                    listBox1.Items.Add(element);
                }
            }

            treeViewElements.Nodes[3].Nodes.Clear();
            fillNodes("Systems");
        }

        private void удалитьДокументыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string element = treeViewElements.SelectedNode.Text;
            ClassDBRequests.removeElement(element, "File");
            treeViewElements.SelectedNode.Remove();
            //treeViewElements.Nodes[0].Nodes.Clear();
            //fillMainNodes("Files");
        }

        //Удаление документа
        private void документыToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Form removingForm = new FormRemovingElements("Files");
            removingForm.ShowDialog();
            treeViewElements.Nodes[0].Nodes.Clear();
            fillNodes("Files");
        }

        //Удаление детали
        private void деталиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form removingForm = new FormRemovingElements("Details");
            removingForm.ShowDialog();
            treeViewElements.Nodes[1].Nodes.Clear();
            fillNodes("Details");
        }

        //Удаление устройства
        private void устройстваToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form removingForm = new FormRemovingElements("Devices");
            removingForm.ShowDialog();
            treeViewElements.Nodes[2].Nodes.Clear();
            fillNodes("Devices");
        }

        //Удаление системы
        private void системыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form removingForm = new FormRemovingElements("Systems");
            removingForm.ShowDialog();
            treeViewElements.Nodes[3].Nodes.Clear();
            fillNodes("Systems");
        }

        private void удалитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string element = treeViewElements.SelectedNode.Text;
            ClassDBRequests.removeElement(element, "Detail");
            treeViewElements.SelectedNode.Remove();
        }

        private void удалитьToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string element = treeViewElements.SelectedNode.Text;
            ClassDBRequests.removeElement(element, "Device");
            treeViewElements.SelectedNode.Remove();
        }

        private void удалитьToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            string element = treeViewElements.SelectedNode.Text;
            ClassDBRequests.removeElement(element, "System");
            treeViewElements.SelectedNode.Remove();
        }

        private void документToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string fileName = openFileDialog1.FileName;
            ClassDBRequests.SaveFileToDatabase(fileName);
            fillNodes("Files");
        }

        private void детальToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form newFormElement = new FormNewElement();
            newFormElement.Tag = "forDetail";
            newFormElement.ShowDialog();
            treeViewElements.Nodes[1].Nodes.Clear();
            fillNodes("Details");
        }

        private void устройствоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form newFormElement = new FormNewElement();
            newFormElement.Tag = "forDevice";
            newFormElement.ShowDialog();
            treeViewElements.Nodes[2].Nodes.Clear();
            fillNodes("Devices");
        }

        private void системуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form newFormElement = new FormNewElement();
            newFormElement.Tag = "forSystem";
            newFormElement.ShowDialog();
            treeViewElements.Nodes[3].Nodes.Clear();
            fillNodes("Systems");
        }

        //Удаление связи Деталь-Документ
        private void документыToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Variables.containerType = "Details";
            Variables.containerName = treeViewElements.SelectedNode.Text;
            Variables.elementType = "Files";
            Variables.table = "Det_Files";
            FormRemoveRelation formRemoveRelation = new FormRemoveRelation();
            formRemoveRelation.ShowDialog();
            if (Variables.needRefresh)
            {                
                treeViewElements.SelectedNode.Nodes.Clear();                

                listBox1.Items.Clear();
                List<string> elements = ClassDBRequests.getRelation(treeViewElements.SelectedNode.Text, "Files", "Details", "Det_Files");
                if (elements.Count() != 0)
                {
                    listBox1.Items.Add("Документы");
                    foreach (string element in elements)
                    {
                        listBox1.Items.Add(element);
                        TreeNode node = new TreeNode();
                        node.Name = element.Split(' ')[0];
                        node.Text = element;
                        node.Tag = "FileR";
                        treeViewElements.SelectedNode.Nodes.Add(node);
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
                
                treeViewElements.Nodes[2].Nodes.Clear();
                treeViewElements.Nodes[3].Nodes.Clear();
                
                fillNodes("Devices");
                fillNodes("Systems");
            }
        }

        //Удаление связи Устройство-Документ
        private void документыToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Variables.containerType = "Devices";
            Variables.containerName = treeViewElements.SelectedNode.Text;
            Variables.elementType = "Files";
            Variables.table = "Dev_Files";
            FormRemoveRelation formRemoveRelation = new FormRemoveRelation();
            formRemoveRelation.ShowDialog();
            if (Variables.needRefresh)
            {
                

                listBox1.Items.Clear();
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
                    listBox1.Items.Add("Устройства");
                    foreach (string element in elements)
                    {
                        listBox1.Items.Add(element);
                    }
                }

                treeViewElements.Nodes[2].Nodes.Clear();
                treeViewElements.Nodes[3].Nodes.Clear();

                fillNodes("Devices");
                fillNodes("Systems");
            }
        }

        //Удаление связи Устройство-Деталь
        private void деталиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Variables.containerType = "Devices";
            Variables.containerName = treeViewElements.SelectedNode.Text;
            Variables.elementType = "Details";
            Variables.table = "Dev_Det";
            FormRemoveRelation formRemoveRelation = new FormRemoveRelation();
            formRemoveRelation.ShowDialog();
            if (Variables.needRefresh)
            {
                treeViewElements.SelectedNode.Nodes.Clear();
                listBox1.Items.Clear();
                List<string> elements = ClassDBRequests.getRelation(treeViewElements.SelectedNode.Text, "Details", "Devices", "Dev_Det");
                if (elements.Count() != 0)
                {
                    listBox1.Items.Add("Детали");
                    foreach (string element in elements)
                    {
                        listBox1.Items.Add(element);
                        TreeNode node = new TreeNode();
                        node.Name = element.Split(' ')[0];
                        node.Text = element;
                        node.Tag = "DetailR";
                        treeViewElements.SelectedNode.Nodes.Add(node);
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

                elements = ClassDBRequests.getRelation(treeViewElements.SelectedNode.Text, "Files", "Devices", "Dev_Files");
                if (elements.Count() != 0)
                {
                    listBox1.Items.Add("Документы");
                    foreach (string element in elements)
                    {
                        listBox1.Items.Add(element);
                        TreeNode node = new TreeNode();
                        node.Name = element.Split(' ')[0];
                        node.Text = element;
                        node.Tag = "FileR";
                        treeViewElements.SelectedNode.Nodes.Add(node);
                    }
                }                
                treeViewElements.Nodes[3].Nodes.Clear();                
                fillNodes("Systems");
            }
        }

        //Удаление связи система-документ
        private void документыToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Variables.containerType = "Systems";
            Variables.containerName = treeViewElements.SelectedNode.Text;
            Variables.elementType = "Files";
            Variables.table = "Sys_Files";
            FormRemoveRelation formRemoveRelation = new FormRemoveRelation();
            formRemoveRelation.ShowDialog();
            if (Variables.needRefresh)
            {
                treeViewElements.SelectedNode.Nodes.Clear();

                listBox1.Items.Clear();
                List<string> elements = ClassDBRequests.getRelation(treeViewElements.SelectedNode.Text, "Devices", "Systems", "Sys_Dev");
                if (elements.Count() != 0)
                {
                    listBox1.Items.Add("Устройства");
                    foreach (string element in elements)
                    {
                        listBox1.Items.Add(element);                        
                    }
                }

                elements = ClassDBRequests.getRelation(treeViewElements.SelectedNode.Text, "Files", "Systems", "Sys_Files");
                if (elements.Count() != 0)
                {
                    listBox1.Items.Add("Документы");
                    foreach (string element in elements)
                    {
                        listBox1.Items.Add(element);                        
                    }
                }

                treeViewElements.Nodes[3].Nodes.Clear();
                fillNodes("Systems");                                
            }
        }

        //Удаление связи система-устройство
        private void устройстваToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Variables.containerType = "Systems";
            Variables.containerName = treeViewElements.SelectedNode.Text;
            Variables.elementType = "Devices";
            Variables.table = "Sys_Dev";
            FormRemoveRelation formRemoveRelation = new FormRemoveRelation();
            formRemoveRelation.ShowDialog();
            if (Variables.needRefresh)
            {
                treeViewElements.SelectedNode.Nodes.Clear();
                listBox1.Items.Clear();
                List<string> elements = ClassDBRequests.getRelation(treeViewElements.SelectedNode.Text, "Devices", "Systems", "Sys_Dev");
                if (elements.Count() != 0)
                {
                    listBox1.Items.Add("Устройства");
                    foreach (string element in elements)
                    {
                        listBox1.Items.Add(element);                        
                    }
                }

                elements = ClassDBRequests.getRelation(treeViewElements.SelectedNode.Text, "Files", "Systems", "Sys_Files");
                if (elements.Count() != 0)
                {
                    listBox1.Items.Add("Документы");
                    foreach (string element in elements)
                    {
                        listBox1.Items.Add(element);                        
                    }
                }

                treeViewElements.Nodes[3].Nodes.Clear();
                fillNodes("Systems");
            }
        }

        //Скачивание пакета документации детали
        private void пакетДокументацииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string folderPath = folderBrowserDialog1.SelectedPath + @"\" + treeViewElements.SelectedNode.Text;
            Directory.CreateDirectory(folderPath);
            foreach (TreeNode node in treeViewElements.SelectedNode.Nodes)
            {
                int fileId = ClassDBRequests.getId(node.Text,"Files");
                ClassDBRequests.ReadFileFromDatabase(folderPath,fileId);
            }
        }

        //Скачивание файла
        private void скачатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string folderPath = folderBrowserDialog1.SelectedPath;
            int fileId = ClassDBRequests.getId(treeViewElements.SelectedNode.Text,"Files");
            ClassDBRequests.ReadFileFromDatabase(folderPath,fileId);
        }

        //Скачивание пакета документации устройства
        private void пакетДокументацииToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string folderPath = folderBrowserDialog1.SelectedPath + @"\" + treeViewElements.SelectedNode.Text;
            Directory.CreateDirectory(folderPath);
            //списки документов и деталей
            List<string> files = ClassDBRequests.getRelation(treeViewElements.SelectedNode.Text, "Files", "Devices", "Dev_Files");
            List<string> details = ClassDBRequests.getRelation(treeViewElements.SelectedNode.Text, "Details", "Devices", "Dev_Det");
            if ((files.Count != 0) || (details.Count != 0))
            {
                //скачивание файлов
                if (files.Count != 0)
                {
                    foreach (string file in files)
                    {
                        int fileId = ClassDBRequests.getId(file, "Files");
                        ClassDBRequests.ReadFileFromDatabase(folderPath, fileId);
                    }
                }
                //скачивание деталей            
                if (details.Count != 0)
                {
                    foreach (string detail in details)
                    {
                        string detailPath = folderPath + @"\" + detail;
                        Directory.CreateDirectory(detailPath);
                        files = ClassDBRequests.getRelation(treeViewElements.SelectedNode.Text, "Files", "Details", "Det_Files");
                        foreach (string file in files)
                        {
                            int fileId = ClassDBRequests.getId(file,"Files");
                            ClassDBRequests.ReadFileFromDatabase(detailPath, fileId);
                        }
                    }
                }
            }            
        }

        //Скачивание пакета документации системы
        private void пакетДокументацииToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string folderPath = folderBrowserDialog1.SelectedPath + @"\" + treeViewElements.SelectedNode.Text;
            Directory.CreateDirectory(folderPath);
            List<string> files = ClassDBRequests.getRelation(treeViewElements.SelectedNode.Text, "Files", "Systems", "Sys_Files");
            List<string> devices = ClassDBRequests.getRelation(treeViewElements.SelectedNode.Text, "Devices", "Systems", "Sys_Dev");
            if ((files.Count != 0) || (devices.Count != 0))
            {
                if (files.Count != 0)
                {
                    foreach (string file in files)
                    {
                        int fileId = ClassDBRequests.getId(file, "Files");
                        ClassDBRequests.ReadFileFromDatabase(folderPath, fileId);
                    }
                }
                //скачивание деталей            
                if (devices.Count != 0)
                {
                    foreach (string device in devices)
                    {
                        string devicePath = folderPath + @"\" + device;
                        Directory.CreateDirectory(devicePath);
                        files = ClassDBRequests.getRelation(device, "Files", "Devices", "Dev_Files");
                        foreach (string file in files)
                        {
                            int fileId = ClassDBRequests.getId(file, "Files");
                            ClassDBRequests.ReadFileFromDatabase(devicePath, fileId);
                        }

                        List<string> details = ClassDBRequests.getRelation(device, "Details", "Devices", "Dev_Det");
                        if (details.Count != 0)
                        {
                            foreach (string detail in details)
                            {
                                string path = devicePath + @"\" + detail;
                                Directory.CreateDirectory(path);
                                files = ClassDBRequests.getRelation(treeViewElements.SelectedNode.Text, "Files", "Details", "Det_Files");
                                if (files.Count != 0)
                                {
                                    foreach (string file in files)
                                    {
                                        int fileId = ClassDBRequests.getId(file,"Files");
                                        ClassDBRequests.ReadFileFromDatabase(path,fileId);
                                    }
                                }
                            }                            
                        }
                    }
                }
            }
        }

        private void заменитьВToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
