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
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;

namespace GOiCHS
{
    public partial class Form1 : Form
    {
        int qCount = 0;
        string[] testTypeArr = { "Охрана труда", "Пожарно-технический минимум" };
        string[] depArr = {  "Производственный отдел",
                                        "Служба организации и проведения торгов",
                                        "Отдел планирования инвестиций",
                                        "Управление экономики и финансов",
                                        "Финансовый отдел",
                                        "Планово-экономический отдел",
                                        "Служба перспективного развития",
                                        "Договорно-правовая служба",
                                        "Отдел комплектации",
                                        "Служба управления персоналом",
                                        "Группа ОКР",
                                        "Управление разработки программного обеспечения",
                                        "Группа разработки и внедрения интеллектуальных систем",
                                        "Служба информационных технологий",
                                        "Отдел разработки и тестирования программного обеспечения",
                                        "Управление НИОКР",
                                        "Отдел прикладной оптики и электроники",
                                        "Отдел нормативно-технической документации и технического контроля",
                                        "Служба волоконно-оптических технологий",
                                        "Производственно-техническое управление",
                                        "Отдел эксплуатации",
                                        "Сборочно-ремонтный участок",
                                        "Эксплуатационный участок ОКР",
                                        "Руководство",
                                        "Участок №2 (г. Брянск)",
                                        "Участок №4",
                                        "Участок №5 (г. Самара)",
                                        "Участок №6 (п. Пурпе)",
                                        "Участок №7"};
        string[] titleArr = {"Ведущий инженер",
                            "Ведущий инженер-программист",
                            "Ведущий специалист",
                            "Делопроизводитель",
                            "Заместитель начальника управления",
                            "Инженер",
                            "Инженер 1 категории",
                            "Инженер 2 категории",
                            "Инженер-програмист",
                            "Инженер-програмист 1 категории",
                            "Начальник группы",
                            "Начальник отдела",
                            "Начальник службы",
                            "Начальник управления",
                            "Начальник участка",
                            "Помощник ген.директора",
                            "Помощник по информационной безопасности",
                            "Специалист",
                            "Cпециалист 1 категории",
                            "Специалист по складскому учету",
                            "Старший техник" };
        string[] categoryArr = { "0", "1 1-я категория", "2 2-я категория", "3 Ведущий" };
        string[] checkTypeArr = { "Первичная", "Повторная", "Внеочередная" };

        //const string fileName = @"D:\forohrana\questionlist.xlsx";
        private string fileName = "";
        string[] qtenQuestions = new string[10];
        string[] atenQuestions = new string[10];
        string[] uatenQuestions = new string[10];

        string testTypeString;
        string surnameString;
        string nameString;
        string patronymicString;
        string depString;
        string titleString;
        string checkTypeString;

        private Excel.Sheets excelsheets;
        private Excel.Worksheet excelworksheet;
        private Excel.Range excelcells;
        private Excel.Workbooks excelappworkbooks;
        private Excel.Workbook excelappworkbook;
        private Excel.Application excelapp;
        //string docName = @"D:\forohrana\report.xltx";
        //string docName = Environment.CurrentDirectory+ @"\Report.xltx";
        string docName = "";

        Stopwatch sw = new Stopwatch();
        string elapsedTime1;
        Timer t = new Timer();
        long startTime;
        long endTime;
        long elapsedTime;
        int trueAnswers = 0;

        public Form1()
        {
            InitializeComponent();
            this.Width = 480;
            this.Height = 410;
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
            if ((testTypeCBox.SelectedItem == null) || (surnameTBox.Text == "") || (nameTBox.Text == "") || (patronymicTBox.Text == "") || (depCBox.SelectedItem == null) || (titleCbox.SelectedItem == null) || (checkTypeCBox.SelectedItem == null))
            {
                MessageBox.Show("Необходимо заполнить все поля", "Внимание!", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }            
            else
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
                this.Height = 300;
                this.Text = testTypeCBox.SelectedItem.ToString();
                qLabelContent.Visible = true;
                aLabel.Visible = true;
                aTextBox.Visible = true;
                skipBttn.Visible = true;
                aButton.Visible = true;

                testTypeString = testTypeCBox.SelectedItem.ToString();
                surnameString = surnameTBox.Text;
                nameString = nameTBox.Text;
                patronymicString = patronymicTBox.Text;
                depString = depCBox.SelectedItem.ToString();
                titleString = titleCbox.SelectedItem.ToString();
                checkTypeString = checkTypeCBox.SelectedItem.ToString();

                startTime = DateTime.Now.Ticks;
                sw.Start();

                t.Interval = 900 * 1000; //15 минут
                t.Tick += delegate {
                    MessageBox.Show("Закончилось время на выполнение теста. Необходимо начать заново", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close(); };
                t.Start();
                
                ////////////////////////////Пожарка
                if (testTypeCBox.SelectedItem.ToString() == testTypeArr[1])
                {                    
                    int cCount = 0;
                    int rCount = Convert.ToInt32(GetCellValue(fileName, "Пожарка", "A1")) - 3;
                    string[] qArr = new string[rCount];
                    string[] aArr = new string[rCount];

                    for (int i = 0; i < rCount; i++)
                    {                        
                        string qTargetCell = "A" + (i + 3).ToString();
                        string aTargetCell = "B" + (i + 3).ToString();
                        qArr[cCount] = GetCellValue(fileName, "Пожарка", qTargetCell);
                        qArr[cCount] = qArr[cCount].Replace("_x000D_","");
                        aArr[cCount] = GetCellValue(fileName, "Пожарка", aTargetCell);
                        aArr[cCount] = aArr[cCount].Replace("_x000D_", "");
                        cCount++;

                    }
                    Array.Resize<string>(ref qArr, cCount);
                    Array.Resize<string>(ref aArr, cCount);

                    Random rand = new Random();

                    int j = 0;
                    while (j < 10)
                    {
                        int pos = rand.Next(0, qArr.Length);
                        if (qtenQuestions.Contains<string>(qArr[pos]) == false)
                        {
                            qtenQuestions[j] = qArr[pos];
                            atenQuestions[j] = aArr[pos];
                            j++;
                        }
                    }           
                    qLabelContent.Text = qtenQuestions[qCount];
                    if (qLabelContent.Text.Contains("Красный квадрат"))
                    {
                        Bitmap image1 = new Bitmap(Environment.CurrentDirectory+ @"\Pic\4.jpg");
                        pBox.Image = image1;
                    }
                    if (qLabelContent.Text.Contains("Желтый треугольник"))
                    {
                        Bitmap image1 = new Bitmap(Environment.CurrentDirectory + @"\Pic\2.jpg");
                        pBox.Image = image1;
                    }
                    if (qLabelContent.Text.Contains("Синий круг"))
                    {
                        Bitmap image1 = new Bitmap(Environment.CurrentDirectory + @"\Pic\3.jpg");
                        pBox.Image = image1;
                    }
                    if (qLabelContent.Text.Contains("зеленый квадрат"))
                    {
                        Bitmap image1 = new Bitmap(Environment.CurrentDirectory + @"\Pic\5.jpg");
                        pBox.Image = image1;
                    }
                    if (qLabelContent.Text.Contains("Красный круг"))
                    {
                        Bitmap image1 = new Bitmap(Environment.CurrentDirectory + @"\Pic\1.jpg");
                        pBox.Image = image1;
                    }
                    if (qLabelContent.Text.Contains("синий квадрат"))
                    {
                        Bitmap image1 = new Bitmap(Environment.CurrentDirectory + @"\Pic\6.jpg");
                        pBox.Image = image1;
                    }
                }                
                ////////////////////////////Начальник ПТУ, зам. начальника ПТУ, начальник участка ПТУ, начальник отдела эксплуатации ПТУ, начальник сборочно-ремонтного участка,начальник управления НИОКР, начальник отдела прикладной оптики и электроники 
                else if (//Начальник ПТУ
                    ((testTypeCBox.SelectedItem.ToString() == testTypeArr[0]) & (depCBox.SelectedItem.ToString() == depArr[19]) & (titleCbox.SelectedItem.ToString() == titleArr[13])) ||
                    //Зам. начачльника ПТУ
                    ((testTypeCBox.SelectedItem.ToString() == testTypeArr[0]) & (depCBox.SelectedItem.ToString() == depArr[19]) & (titleCbox.SelectedItem.ToString() == titleArr[4])) ||
                    //Начальники участков
                    ((testTypeCBox.SelectedItem.ToString() == testTypeArr[0]) & (titleCbox.SelectedItem.ToString() == titleArr[14])) ||
                    //Начальник отдела эксплуатации
                    ((testTypeCBox.SelectedItem.ToString() == testTypeArr[0]) & (depCBox.SelectedItem.ToString() == depArr[20]) & (titleCbox.SelectedItem.ToString() == titleArr[11])) ||
                    //Начальник управления НИОКР
                    ((testTypeCBox.SelectedItem.ToString() == testTypeArr[0]) & (depCBox.SelectedItem.ToString() == depArr[15]) & (titleCbox.SelectedItem.ToString() == titleArr[13])) ||
                    //Начальник отдела прикладной оптики и электроники
                    ((testTypeCBox.SelectedItem.ToString() == testTypeArr[0]) & (depCBox.SelectedItem.ToString() == depArr[16]) & (titleCbox.SelectedItem.ToString() == titleArr[11])))
                {
                    int cCount = 0;
                    int rCount = Convert.ToInt32(GetCellValue(fileName, "Лист1", "A1")) - 3;
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

                    int j = 0;
                    while (j < 10)
                    {
                        int pos = rand.Next(0, qArr.Length);
                        if (qtenQuestions.Contains<string>(qArr[pos]) == false)
                        {
                            qtenQuestions[j] = qArr[pos];
                            atenQuestions[j] = aArr[pos];
                            j++;
                        }
                    }

                    /*for (int i = 0; i < 10; i++)
                    {
                        int pos = rand.Next(0, qArr.Length);
                        //if (qtenQuestions.Contains<string>(qArr[pos]))
                        qtenQuestions[i] = qArr[pos];
                        atenQuestions[i] = aArr[pos];
                    }*/

                    qLabelContent.Text = qtenQuestions[qCount];
                }
                ////////////////////////////Начальник отдела комплектации
                else if ((testTypeCBox.SelectedItem.ToString() == testTypeArr[0]) & (depCBox.SelectedItem.ToString() == depArr[8]) & (titleCbox.SelectedItem.ToString() == titleArr[11]))
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
                    int j = 0;
                    while (j < 10)
                    {
                        int pos = rand.Next(0, qArr.Length);
                        if (qtenQuestions.Contains<string>(qArr[pos]) == false)
                        {
                            qtenQuestions[j] = qArr[pos];
                            atenQuestions[j] = aArr[pos];
                            j++;
                        }
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
                    int j = 0;
                    while (j < 10)
                    {
                        int pos = rand.Next(0, qArr.Length);
                        if (qtenQuestions.Contains<string>(qArr[pos]) == false)
                        {
                            qtenQuestions[j] = qArr[pos];
                            atenQuestions[j] = aArr[pos];
                            j++;
                        }
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
                    int j = 0;
                    while (j < 10)
                    {
                        int pos = rand.Next(0, qArr.Length);
                        if (qtenQuestions.Contains<string>(qArr[pos]) == false)
                        {
                            qtenQuestions[j] = qArr[pos];
                            atenQuestions[j] = aArr[pos];
                            j++;
                        }
                    }

                    qLabelContent.Text = qtenQuestions[qCount];
                }
                ////////////////////////////Инженеры и специалисты: ПТУ, сборочно - ремонтного участка, отдела прикладной оптики и электроники
                else if (//инженеры отдела эксплуатации
                         ((testTypeCBox.SelectedItem.ToString() == testTypeArr[0]) & (depCBox.SelectedItem.ToString() == depArr[20]) & (titleCbox.SelectedItem.ToString().Contains("Инженер") || titleCbox.SelectedItem.ToString().Contains("инженер"))) ||
                         //инженеры участков
                         ((testTypeCBox.SelectedItem.ToString() == testTypeArr[0]) & (depCBox.SelectedItem.ToString().Contains("Участок") || depCBox.SelectedItem.ToString().Contains("участок")) & (titleCbox.SelectedItem.ToString().Contains("Инженер") || titleCbox.SelectedItem.ToString().Contains("инженер"))) ||
                         //инженеры отдела прикладной оптики и электроники
                         ((testTypeCBox.SelectedItem.ToString() == testTypeArr[0]) & (depCBox.SelectedItem.ToString() == depArr[16]) & (titleCbox.SelectedItem.ToString().Contains("Инженер") || titleCbox.SelectedItem.ToString().Contains("инженер"))) ||
                         //специалисты отдела эксплуатации
                         ((testTypeCBox.SelectedItem.ToString() == testTypeArr[0]) & (depCBox.SelectedItem.ToString() == depArr[20]) & (titleCbox.SelectedItem.ToString().Contains("специалист") || titleCbox.SelectedItem.ToString().Contains("Специалист"))) ||
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
                    int j = 0;
                    while (j < 10)
                    {
                        int pos = rand.Next(0, qArr.Length);
                        if (qtenQuestions.Contains<string>(qArr[pos]) == false)
                        {
                            qtenQuestions[j] = qArr[pos];
                            atenQuestions[j] = aArr[pos];
                            j++;
                        }
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
                    int j = 0;
                    while (j < 10)
                    {
                        int pos = rand.Next(0, qArr.Length);
                        if (qtenQuestions.Contains<string>(qArr[pos]) == false)
                        {
                            qtenQuestions[j] = qArr[pos];
                            atenQuestions[j] = aArr[pos];
                            j++;
                        }
                    }

                    qLabelContent.Text = qtenQuestions[qCount];
                }
            }
            
        }

        private void aButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (aTextBox.Text != "")
                {
                    pBox.Image = null;
                    trueAnswers = 0;
                    if (qCount < 9)
                    {
                        uatenQuestions[qCount] = aTextBox.Text;
                        qCount++;
                        qLabelContent.Text = qtenQuestions[qCount];
                        if (qLabelContent.Text.Contains("Красный квадрат"))
                        {
                            Bitmap image1 = new Bitmap(Environment.CurrentDirectory + @"\Pic\4.jpg");
                            pBox.Image = image1;
                        }
                        if (qLabelContent.Text.Contains("Желтый треугольник"))
                        {
                            Bitmap image1 = new Bitmap(Environment.CurrentDirectory + @"\Pic\2.jpg");
                            pBox.Image = image1;
                        }
                        if (qLabelContent.Text.Contains("Синий круг"))
                        {
                            Bitmap image1 = new Bitmap(Environment.CurrentDirectory + @"\Pic\3.jpg");
                            pBox.Image = image1;
                        }
                        if (qLabelContent.Text.Contains("зеленый квадрат"))
                        {
                            Bitmap image1 = new Bitmap(Environment.CurrentDirectory + @"\Pic\5.jpg");
                            pBox.Image = image1;
                        }
                        if (qLabelContent.Text.Contains("Красный круг"))
                        {
                            Bitmap image1 = new Bitmap(Environment.CurrentDirectory + @"\Pic\1.jpg");
                            pBox.Image = image1;
                        }
                        if (qLabelContent.Text.Contains("синий квадрат"))
                        {
                            Bitmap image1 = new Bitmap(Environment.CurrentDirectory + @"\Pic\6.jpg");
                            pBox.Image = image1;
                        }
                    }
                    else
                    {
                        endTime = DateTime.Now.Ticks;
                        sw.Stop();
                        TimeSpan ts = sw.Elapsed;
                        elapsedTime1 = String.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);
                        elapsedTime = (endTime - startTime) / 1000;
                        for (int i = 0; i < 9; i++)
                        {
                            if (atenQuestions[i] == uatenQuestions[i])
                            {
                                trueAnswers++;
                            }
                        }
                        if (trueAnswers <= 7)
                        {
                            string message = "Правильных ответов " + trueAnswers + ". Тест не сдан";
                            MessageBox.Show(message, "Результат", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            saveReport();
                            Close();
                        }
                        else
                        {
                            string message = "Правильных ответов " + trueAnswers + ". Тест сдан";
                            MessageBox.Show(message, "Результат", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            saveReport();
                            Close();
                        }
                    }
                    aTextBox.Text = "";

                }
                else
                {
                    string message = "Поле ОТВЕТ не может быть пустым. Заполните поле.";
                    MessageBox.Show(message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            
        }

        private void skipBttn_Click(object sender, EventArgs e)
        {
            pBox.Image = null;
            string skipQString;
            string skipAString;
            skipQString = qtenQuestions[qCount];
            skipAString = atenQuestions[qCount];
            for (int i=qCount;i<9;i++)
            {
                qtenQuestions[i] = qtenQuestions[i + 1];
                atenQuestions[i] = atenQuestions[i + 1];                
            }
            qtenQuestions[9] = skipQString;
            atenQuestions[9] = skipAString;
            if (qCount != 9)
            {
                
                qLabelContent.Text = qtenQuestions[qCount];
                if (qLabelContent.Text.Contains("Красный квадрат"))
                {
                    Bitmap image1 = new Bitmap(@"D:\ForOhrana\Pic\4.jpg");
                    pBox.Image = image1;
                }
                if (qLabelContent.Text.Contains("Желтый треугольник"))
                {
                    Bitmap image1 = new Bitmap(@"D:\ForOhrana\Pic\2.jpg");
                    pBox.Image = image1;
                }
                if (qLabelContent.Text.Contains("Синий круг"))
                {
                    Bitmap image1 = new Bitmap(@"D:\ForOhrana\Pic\3.jpg");
                    pBox.Image = image1;
                }
                if (qLabelContent.Text.Contains("зеленый квадрат"))
                {
                    Bitmap image1 = new Bitmap(@"D:\ForOhrana\Pic\5.jpg");
                    pBox.Image = image1;
                }
                if (qLabelContent.Text.Contains("Красный круг"))
                {
                    Bitmap image1 = new Bitmap(@"D:\ForOhrana\Pic\1.jpg");
                    pBox.Image = image1;
                }
                if (qLabelContent.Text.Contains("синий квадрат"))
                {
                    Bitmap image1 = new Bitmap(@"D:\ForOhrana\Pic\6.jpg");
                    pBox.Image = image1;
                }
            }
            aTextBox.Text = "";
            
        }

        private void saveReport()
        {
            try
            {
                string savePath = Environment.CurrentDirectory + @"\reports\" + surnameString + nameString + " " + DateTime.Now.ToString("dd-MM-yy-hh-mm") + ".xlsx";
                excelapp = new Excel.Application();
                excelapp.Visible = true;
                excelapp.SheetsInNewWorkbook = 1;
                excelapp.Workbooks.Open(docName,
      Type.Missing, Type.Missing, Type.Missing, Type.Missing,
      Type.Missing, Type.Missing, Type.Missing, Type.Missing,
      Type.Missing, Type.Missing, Type.Missing, Type.Missing,
      Type.Missing, Type.Missing);

                excelappworkbooks = excelapp.Workbooks;
                excelappworkbook = excelappworkbooks["Report1"];
                excelsheets = excelappworkbook.Worksheets;
                //Получаем ссылку на лист 1
                excelworksheet = (Excel.Worksheet)excelsheets.get_Item(1);
                //Забиваем ФИО  
                excelcells = excelworksheet.get_Range("A6", "A6");
                excelcells.Value2 += surnameString + " " + nameString + " " + patronymicString;
                //Забиваем должность
                excelcells = excelworksheet.get_Range("A8", "A8");
                excelcells.Value2 += titleString;
                //Забиваем подразделение
                excelcells = excelworksheet.get_Range("A9", "A9");
                excelcells.Value2 += depString;
                //Забиваем тему проверки
                excelcells = excelworksheet.get_Range("A10", "A10");
                excelcells.Value2 += testTypeString;
                //Забиваем дату
                excelcells = excelworksheet.get_Range("A11", "A11");
                excelcells.Value2 += DateTime.Now.ToString("dd-MM-yyyy");
                //Заполняем таблицу с вопросами и ответами
                for (int i = 0; i < 10; i++)
                {
                    int ti = i + 16;
                    string cellB = "B" + ti.ToString();
                    string cellC = "C" + ti.ToString();
                    string cellD = "D" + ti.ToString();
                    string cellF = "F" + ti.ToString();
                    string res;
                    excelcells = excelworksheet.get_Range(cellB, cellB);
                    excelcells.Value2 = qtenQuestions[i];
                    excelworksheet.get_Range(cellB, cellB).EntireRow.AutoFit();

                    excelcells = excelworksheet.get_Range(cellC, cellC);
                    excelcells.Value2 = uatenQuestions[i];
                    excelcells = excelworksheet.get_Range(cellD, cellD);
                    excelcells.Value2 = atenQuestions[i];
                    if (uatenQuestions[i] == atenQuestions[i])
                    {
                        res = "Верно";
                    }
                    else
                    {
                        res = "Неверно";
                    }
                    excelcells = excelworksheet.get_Range(cellF, cellF);
                    excelcells.Value2 = res;

                }

                //Забиваем результат проверки
                excelcells = excelworksheet.get_Range("B28", "B28");
                if (trueAnswers > 7)
                {
                    excelcells.Value2 += "Сдал";
                }
                else
                {
                    excelcells.Value2 += "Не сдал";
                }
                //Забиваем количество ответов
                excelcells = excelworksheet.get_Range("F28", "F28");
                excelcells.Value2 = trueAnswers.ToString();
                excelcells = excelworksheet.get_Range("F29", "F29");
                excelcells.Value2 = (10 - trueAnswers).ToString();
                //Забиваем фактическое время прохождения теста

                excelcells = excelworksheet.get_Range("D29", "D29");
                excelcells.Value2 = elapsedTime1;
                //excelcells.Value2 = elapsedTime.ToString();
                //MessageBox.Show(savePath,"123",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                excelappworkbook.SaveAs(savePath);
                excelappworkbook.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void открытьФайлСВопросамиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            fileName = openFileDialog1.FileName;            
        }

        private void открытьФайлСОтчетомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            docName = openFileDialog1.FileName;
        }
    }
}
