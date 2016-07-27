using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Office.Interop.Excel;


namespace GOiCHS
{
    public partial class Form1 : Form
    {
        int qCount = 0;
        string[] testTypeArr = { "0 Охрана труда", "1 Пожарно-технический минимум" };
        string[] depArr = {  "0 Производственный отдел",
                                        "1 Служба организации и проведения торгов",
                                        "2 Отдел планирования инвестиций",
                                        "3 Управление экономики и финансов",
                                        "4 Финансовый отдел",
                                        "5 Планово-экономический отдел",
                                        "6 Служба перспективного развития",
                                        "7 Договорно-правовая служба",
                                        "8 Отдел комплектации",
                                        "9 Служба управления персоналом",
                                        "10 Группа ОКР",
                                        "11 Управление разработки программного обеспечения",
                                        "12 Группа разработки и внедрения интеллектуальных систем",
                                        "13 Служба информационных технологий",
                                        "14 Отдел разработки и тестирования программного обеспечения",
                                        "15 Управление НИОКР",
                                        "16 Отдел прикладной оптики и электроники",
                                        "17 Отдел нормативно-технической документации и технического контроля",
                                        "18 Служба волоконно-оптических технологий",
                                        "19 Производственно-техническое управление",
                                        "20 Отдел эксплуатации",
                                        "21 Сборочно-ремонтный участок",
                                        "22 Эксплуатационный участок ОКР",
                                        "23 Руководство",
                                        "24 Участок №2 (г. Брянск)",
                                        "25 Участок №4",
                                        "26 Участок №5 (г. Самара)",
                                        "27 Участок №6 (п. Пурпе)",
                                        "28 Участок №7"};
        string[] titleArr = {"0 Ведущий инженер",
                            "1 Ведущий инженер-программист",
                            "2 Ведущий специалист",
                            "3 Делопроизводитель",
                            "4 Заместитель начальника управления",
                            "5 Инженер",
                            "6 Инженер 1 категории",
                            "7 Инженер 2 категории",
                            "8 Инженер-програмист",
                            "9 Инженер-програмист 1 категории",
                            "10 Начальник группы",
                            "11 Начальник отдела",
                            "12 Начальник службы",
                            "13 Начальник управления",
                            "14 Начальник участка",
                            "15 Помощник ген.директора",
                            "16 Помощник по информационной безопасности",
                            "17 Специалист",
                            "18 Cпециалист 1 категории",
                            "19 Специалист по складскому учету",
                            "20 Старший техник" };
        string[] categoryArr = { "0", "1 1-я категория", "2 2-я категория", "3 Ведущий" };
        string[] checkTypeArr = { "0 Первичная", "1 Повторная", "2 Внеочередная" };

        const string fileName = @"D:\forohrana\questionlist.xlsx";
        string[] qtenQuestions = new string[10];
        string[] atenQuestions = new string[10];

        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

            qLabelContent.Visible = false;
            for (int i=0;i<testTypeArr.Length;i++)
            {
                testTypeCBox.Items.Add(testTypeArr[i]);
            }
            for (int i = 0; i < depArr.Length; i++)
            {
                depCBox.Items.Add(depArr[i]);
            }
            for (int i = 0; i < titleArr.Length; i++)
            {
                titleCbox.Items.Add(titleArr[i]);
            }
            for (int i = 0; i < checkTypeArr.Length; i++)
            {
                checkTypeCBox.Items.Add(checkTypeArr[i]);
            }                
        }

        public static string GetCellValue(string fileName,
        string sheetName,
        string addressName)
        {
            string value = null;

            // Open the spreadsheet document for read-only access.
            using (SpreadsheetDocument document =
                SpreadsheetDocument.Open(fileName, false))
            {
                // Retrieve a reference to the workbook part.
                WorkbookPart wbPart = document.WorkbookPart;

                // Find the sheet with the supplied name, and then use that 
                // Sheet object to retrieve a reference to the first worksheet.
                Sheet theSheet = wbPart.Workbook.Descendants<Sheet>().
                  Where(s => s.Name == sheetName).FirstOrDefault();

                // Throw an exception if there is no sheet.
                if (theSheet == null)
                {
                    throw new ArgumentException("sheetName");
                }

                // Retrieve a reference to the worksheet part.
                WorksheetPart wsPart =
                    (WorksheetPart)(wbPart.GetPartById(theSheet.Id));

                // Use its Worksheet property to get a reference to the cell 
                // whose address matches the address you supplied.
                Cell theCell = wsPart.Worksheet.Descendants<Cell>().
                  Where(c => c.CellReference == addressName).FirstOrDefault();

                // If the cell does not exist, return an empty string.
                if (theCell != null)
                {
                    value = theCell.InnerText;

                    // If the cell represents an integer number, you are done. 
                    // For dates, this code returns the serialized value that 
                    // represents the date. The code handles strings and 
                    // Booleans individually. For shared strings, the code 
                    // looks up the corresponding value in the shared string 
                    // table. For Booleans, the code converts the value into 
                    // the words TRUE or FALSE.
                    if (theCell.DataType != null)
                    {
                        switch (theCell.DataType.Value)
                        {
                            case CellValues.SharedString:

                                // For shared strings, look up the value in the
                                // shared strings table.
                                var stringTable =
                                    wbPart.GetPartsOfType<SharedStringTablePart>()
                                    .FirstOrDefault();

                                // If the shared string table is missing, something 
                                // is wrong. Return the index that is in
                                // the cell. Otherwise, look up the correct text in 
                                // the table.
                                if (stringTable != null)
                                {
                                    value =
                                        stringTable.SharedStringTable
                                        .ElementAt(int.Parse(value)).InnerText;
                                }
                                break;

                            case CellValues.Boolean:
                                switch (value)
                                {
                                    case "0":
                                        value = "FALSE";
                                        break;
                                    default:
                                        value = "TRUE";
                                        break;
                                }
                                break;
                        }
                    }
                }
            }
            return value;
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            testTypeLabel.Visible = false;
            testTypeCBox.Visible = false;
            surnameLabel.Visible = false;
            surnameTBox.Visible = false;
            nameLabel.Visible = false;
            nameTBox.Visible = false;
            patronymicLabel.Visible = false;
            patronymicTBox.Visible = false;
            departmentLabel.Visible = false;
            depCBox.Visible = false;
            titleLabel.Visible = false;
            titleCbox.Visible = false;
            checkTypeLabel.Visible = false;
            checkTypeCBox.Visible = false;
            startBtn.Visible = false;
            qLabel.Visible = true;
            this.Width = 935;
            this.Height = 410;
            qLabelContent.Visible = true;
            aLabel.Visible = true;
            aTextBox.Visible = true;
            skipBttn.Visible = true;
            aButton.Visible = true;
        
////////////////////////////Начальник ПТУ, зам. начальника ПТУ, начальник участка ПТУ, начальник отдела эксплуатации ПТУ, начальник сборочно-ремонтного участка,начальник управления НИОКР, начальник отдела прикладной оптики и электроники 
            if (//Начальник ПТУ
                ((testTypeCBox.SelectedItem.ToString() == testTypeArr[0]) & (depCBox.SelectedItem.ToString() == depArr[19]) & (titleCbox.SelectedItem.ToString() == titleArr[13])) ||
                //Зам. начачльника ПТУ
                ((testTypeCBox.SelectedItem.ToString() == testTypeArr[0]) & (depCBox.SelectedItem.ToString() == depArr[19]) & (titleCbox.SelectedItem.ToString() == titleArr[4])) ||
                //Начальники участков
                ((testTypeCBox.SelectedItem.ToString() == testTypeArr[0]) & (titleCbox.SelectedItem.ToString() == titleArr[14]))||
                //Начальник отдела эксплуатации
                ((testTypeCBox.SelectedItem.ToString() == testTypeArr[0]) & (depCBox.SelectedItem.ToString() == depArr[20]) & (titleCbox.SelectedItem.ToString() == titleArr[11])) ||
                //Начальник управления НИОКР
                ((testTypeCBox.SelectedItem.ToString() == testTypeArr[0]) & (depCBox.SelectedItem.ToString() == depArr[15]) & (titleCbox.SelectedItem.ToString() == titleArr[13])) ||
                //Начальник отдела прикладной оптики и электроники
                ((testTypeCBox.SelectedItem.ToString() == testTypeArr[0]) & (depCBox.SelectedItem.ToString() == depArr[16]) & (titleCbox.SelectedItem.ToString() == titleArr[11])))
            {   
                int cCount = 0;
                int rCount = Convert.ToInt32(GetCellValue(fileName, "Лист1", "A1"))-3;
                string[] qArr = new string[rCount];
                string[] aArr = new string[rCount];

                for (int i = 0; i < rCount; i++)
                {
                    string checkCell = "C" + (i + 3).ToString();                    
                    if (GetCellValue(fileName, "Лист1", checkCell) == "1")
                    {
                        string qTargetCell = "A" + (i + 3).ToString();
                        string aTargetCell = "B" + (i + 3).ToString();
                        qArr[cCount] = GetCellValue(fileName, "Лист1", qTargetCell);
                        aArr[cCount] = GetCellValue(fileName, "Лист1", aTargetCell);
                        cCount++;                        
                    }
                    
                }
                Array.Resize<string>(ref qArr, cCount);
                Array.Resize<string>(ref aArr, cCount);

                Random rand = new Random();
                for (int i = 0; i < 10; i++)
                {
                    int pos = rand.Next(0, qArr.Length);
                    qtenQuestions[i] = qArr[pos];
                    atenQuestions[i] = aArr[pos];
                }

                qLabelContent.Text = qtenQuestions[qCount];                
            }
////////////////////////////Начальник отдела комплектации
            else if ((testTypeCBox.SelectedItem.ToString()==testTypeArr[0]) & (depCBox.SelectedItem.ToString()==depArr[8]) & (titleCbox.SelectedItem.ToString()==titleArr[11]))
            {
                int cCount = 0;
                int rCount = Convert.ToInt32(GetCellValue(fileName, "Лист1", "A1")) - 3;
                string[] qArr = new string[rCount];
                string[] aArr = new string[rCount];

                for (int i = 0; i < rCount; i++)
                {
                    string checkCell = "E" + (i + 3).ToString();
                    if (GetCellValue(fileName, "Лист1", checkCell) == "1")
                    {
                        string qTargetCell = "A" + (i + 3).ToString();
                        string aTargetCell = "B" + (i + 3).ToString();
                        qArr[cCount] = GetCellValue(fileName, "Лист1", qTargetCell);
                        aArr[cCount] = GetCellValue(fileName, "Лист1", aTargetCell);
                        cCount++;
                    }

                }
                Array.Resize<string>(ref qArr, cCount);
                Array.Resize<string>(ref aArr, cCount);

                Random rand = new Random();
                for (int i = 0; i < 10; i++)
                {
                    int pos = rand.Next(0, qArr.Length);
                    qtenQuestions[i] = qArr[pos];
                    atenQuestions[i] = aArr[pos];
                }

                qLabelContent.Text = qtenQuestions[qCount];
            }
////////////////////////////Начальник службы управления персонала
            else if ((testTypeCBox.SelectedItem.ToString() == testTypeArr[0]) & (depCBox.SelectedItem.ToString() == depArr[9]) & (titleCbox.SelectedItem.ToString() == titleArr[12]))
            {
                int cCount = 0;
                int rCount = Convert.ToInt32(GetCellValue(fileName, "Лист1", "A1")) - 3;
                string[] qArr = new string[rCount];
                string[] aArr = new string[rCount];

                for (int i = 0; i < rCount; i++)
                {
                    string checkCell = "G" + (i + 3).ToString();
                    if (GetCellValue(fileName, "Лист1", checkCell) == "1")
                    {
                        string qTargetCell = "A" + (i + 3).ToString();
                        string aTargetCell = "B" + (i + 3).ToString();
                        qArr[cCount] = GetCellValue(fileName, "Лист1", qTargetCell);
                        aArr[cCount] = GetCellValue(fileName, "Лист1", aTargetCell);
                        cCount++;
                    }

                }
                Array.Resize<string>(ref qArr, cCount);
                Array.Resize<string>(ref aArr, cCount);

                Random rand = new Random();
                for (int i = 0; i < 10; i++)
                {
                    int pos = rand.Next(0, qArr.Length);
                    qtenQuestions[i] = qArr[pos];
                    atenQuestions[i] = aArr[pos];
                }

                qLabelContent.Text = qtenQuestions[qCount];
            }
////////////////////////////Руководители управлений, отделов и служб
            else if (//Начальник группы
                     ((testTypeCBox.SelectedItem.ToString() == testTypeArr[0]) & (titleCbox.SelectedItem.ToString() == titleArr[10])) ||
                     //Начальник отдела
                     ((testTypeCBox.SelectedItem.ToString() == testTypeArr[0]) & (titleCbox.SelectedItem.ToString() == titleArr[11])) ||
                     //Начальник службы
                     ((testTypeCBox.SelectedItem.ToString() == testTypeArr[0]) & (titleCbox.SelectedItem.ToString() == titleArr[12])) ||
                     //Начальник управления
                     ((testTypeCBox.SelectedItem.ToString() == testTypeArr[0]) & (titleCbox.SelectedItem.ToString() == titleArr[13])))
            {
                int cCount = 0;
                int rCount = Convert.ToInt32(GetCellValue(fileName, "Лист1", "A1")) - 3;
                string[] qArr = new string[rCount];
                string[] aArr = new string[rCount];

                for (int i = 0; i < rCount; i++)
                {
                    string checkCell = "D" + (i + 3).ToString();
                    if (GetCellValue(fileName, "Лист1", checkCell) == "1")
                    {
                        string qTargetCell = "A" + (i + 3).ToString();
                        string aTargetCell = "B" + (i + 3).ToString();
                        qArr[cCount] = GetCellValue(fileName, "Лист1", qTargetCell);
                        aArr[cCount] = GetCellValue(fileName, "Лист1", aTargetCell);
                        cCount++;
                    }

                }
                Array.Resize<string>(ref qArr, cCount);
                Array.Resize<string>(ref aArr, cCount);

                Random rand = new Random();
                for (int i = 0; i < 10; i++)
                {
                    int pos = rand.Next(0, qArr.Length);
                    qtenQuestions[i] = qArr[pos];
                    atenQuestions[i] = aArr[pos];
                }

                qLabelContent.Text = qtenQuestions[qCount];
            }
////////////////////////////Инженеры и специалисты: ПТУ, сборочно - ремонтного участка, отдела прикладной оптики и электроники
            else if (//инженеры отдела эксплуатации
                     ((testTypeCBox.SelectedItem.ToString() == testTypeArr[0]) & (depCBox.SelectedItem.ToString() == depArr[20]) & (titleCbox.SelectedItem.ToString().Contains("Инженер") || titleCbox.SelectedItem.ToString().Contains("инженер"))) ||
                     //инженеры участков
                     ((testTypeCBox.SelectedItem.ToString() == testTypeArr[0]) & (depCBox.SelectedItem.ToString().Contains("Участок") || depCBox.SelectedItem.ToString().Contains("участок")) & (titleCbox.SelectedItem.ToString().Contains("Инженер")|| titleCbox.SelectedItem.ToString().Contains("инженер"))) ||
                     //инженеры отдела прикладной оптики и электроники
                     ((testTypeCBox.SelectedItem.ToString() == testTypeArr[0]) & (depCBox.SelectedItem.ToString() == depArr[16]) & (titleCbox.SelectedItem.ToString().Contains("Инженер") || titleCbox.SelectedItem.ToString().Contains("инженер"))) ||
                     //специалисты отдела эксплуатации
                     ((testTypeCBox.SelectedItem.ToString() == testTypeArr[0]) & (depCBox.SelectedItem.ToString() == depArr[20]) & (titleCbox.SelectedItem.ToString().Contains("специалист")|| titleCbox.SelectedItem.ToString().Contains("Специалист"))) ||
                     //специалисты участков
                     ((testTypeCBox.SelectedItem.ToString() == testTypeArr[0]) & (depCBox.SelectedItem.ToString().Contains("Участок") || depCBox.SelectedItem.ToString().Contains("участок")) & (titleCbox.SelectedItem.ToString().Contains("Специалист") || titleCbox.SelectedItem.ToString().Contains("специалист"))) ||
                     //специалисты отдела прикладной оптики и электроники
                     ((testTypeCBox.SelectedItem.ToString() == testTypeArr[0]) & (depCBox.SelectedItem.ToString() == depArr[16]) & (titleCbox.SelectedItem.ToString().Contains("Специалист") || titleCbox.SelectedItem.ToString().Contains("специалист")))
                     )
            {
                int cCount = 0;
                int rCount = Convert.ToInt32(GetCellValue(fileName, "Лист1", "A1")) - 3;
                string[] qArr = new string[rCount];
                string[] aArr = new string[rCount];

                for (int i = 0; i < rCount; i++)
                {
                    string checkCell = "F" + (i + 3).ToString();
                    if (GetCellValue(fileName, "Лист1", checkCell) == "1")
                    {
                        string qTargetCell = "A" + (i + 3).ToString();
                        string aTargetCell = "B" + (i + 3).ToString();
                        qArr[cCount] = GetCellValue(fileName, "Лист1", qTargetCell);
                        aArr[cCount] = GetCellValue(fileName, "Лист1", aTargetCell);
                        cCount++;
                    }

                }
                Array.Resize<string>(ref qArr, cCount);
                Array.Resize<string>(ref aArr, cCount);

                Random rand = new Random();
                for (int i = 0; i < 10; i++)
                {
                    int pos = rand.Next(0, qArr.Length);
                    qtenQuestions[i] = qArr[pos];
                    atenQuestions[i] = aArr[pos];
                }

                qLabelContent.Text = qtenQuestions[qCount];
            }
            else
            {
                int cCount = 0;
                int rCount = Convert.ToInt32(GetCellValue(fileName, "Лист1", "A1")) - 3;
                string[] qArr = new string[rCount];
                string[] aArr = new string[rCount];

                for (int i = 0; i < rCount; i++)
                {
                    string checkCell = "F" + (i + 3).ToString();
                    if (GetCellValue(fileName, "Лист1", checkCell) == "1")
                    {
                        string qTargetCell = "A" + (i + 3).ToString();
                        string aTargetCell = "B" + (i + 3).ToString();
                        qArr[cCount] = GetCellValue(fileName, "Лист1", qTargetCell);
                        aArr[cCount] = GetCellValue(fileName, "Лист1", aTargetCell);
                        cCount++;
                    }

                }
                Array.Resize<string>(ref qArr, cCount);
                Array.Resize<string>(ref aArr, cCount);

                Random rand = new Random();
                for (int i = 0; i < 10; i++)
                {
                    int pos = rand.Next(0, qArr.Length);
                    qtenQuestions[i] = qArr[pos];
                    atenQuestions[i] = aArr[pos];
                }

                qLabelContent.Text = qtenQuestions[qCount];
            }
        }

        private void aButton_Click(object sender, EventArgs e)
        {
            if (qCount < 9)
            {
                qCount++;
                qLabelContent.Text = qtenQuestions[qCount];
            }            
        }
    }
}
