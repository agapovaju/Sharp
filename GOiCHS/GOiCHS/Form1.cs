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

namespace GOiCHS
{
    public partial class Form1 : Form
    {
        string[] testTypeArr = { "0Охрана труда", "1Пожарно-технический минимум" };
        string[] departmentArr = {  "0Производственный отдел",
                                        "1Служба организации и проведения торгов",
                                        "2Отдел планирования инвестиций",
                                        "3Управление экономики и финансов",
                                        "4Финансовый отдел",
                                        "5Планово-экономический отдел",
                                        "6Служба перспективного развития",
                                        "7Договорно-правовая служба",
                                        "8Отдел комплектации",
                                        "9Служба управления персоналом",
                                        "10Группа ОКР",
                                        "11Управление разработки программного обеспечения",
                                        "12Группа разработки и внедрения интеллектуальных систем",
                                        "13Служба информационных технологий",
                                        "14Отдел разработки и тестирования программного обеспечения",
                                        "15Управление НИОКР",
                                        "16Отдел прикладной оптики и электроники",
                                        "17Отдел нормативно-технической документации и технического контроля",
                                        "18Служба волоконно-оптических технологий",
                                        "19Производственно-техническое управление",
                                        "20Отдел эксплуатации",
                                        "21Сборочно-ремонтный участок",
                                        "22Эксплуатационный участок ОКР",
                                        "23Руководство",
                                        "24Участок №2 (г. Брянск)",
                                        "25Участок №4",
                                        "26Участок №5 (г. Самара)",
                                        "27Участок №6 (п. Пурпе)",
                                        "28Участок №7"};
        string[] titleArr = {   "0Ведущий инженер",
                                    "1Ведущий инженер-программист",
                                    "2Ведущий специалист",
                                    "3Делопроизводитель",
                                    "4Заместитель начальника управления",
                                    "5Инженер",
                                    "6Инженер 1 категории",
                                    "7Инженер 2 категории",
                                    "8Инженер-програмист",
                                    "9Инженер-програмист 1 категории",
                                    "10Начальник группы",
                                    "11Начальник отдела",
                                    "12Начальник службы",
                                    "13Начальник управления",
                                    "14Начальник участка",
                                    "15Помощник ген.директора",
                                    "16Помощник по информационной безопасности",
                                    "17Специалист",
                                    "18Специалист 1 категории",
                                    "19Специалист по складскому учету",
                                    "20Старший техник"};
        string[] checkTypeArr = { "0Первичная", "1Повторная", "2Внеочередная" };
        const string fileName = @"D:\forohrana\questionlist.xlsx";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            string[] currQuestions = new string[10];
            for (int i=0;i<testTypeArr.Length;i++)
            {
                testTypeCBox.Items.Add(testTypeArr[i]);
            }
            for (int i = 0; i < departmentArr.Length; i++)
            {
                departmentCBox.Items.Add(departmentArr[i]);
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

        private void startTestBttn_Click(object sender, EventArgs e)
        {
            if ((testTypeCBox.SelectedItem.ToString()==testTypeArr[0])&(departmentCBox.SelectedItem.ToString()==departmentArr[19])&(titleCbox.SelectedItem.ToString()==titleArr[13]))
            {
                string[] qArr = new string[151];
                string[] trueAnswerArr = new string[151];
                // Retrieve the value in cell A1.
                //string value = GetCellValue(fileName, "НАЧ-ПТУ-СРУ-НИОКР_ОПТИКИ", "A1");
                //Console.WriteLine(value);
                // Retrieve the date value in cell A2.
                //value = GetCellValue(fileName, "Sheet1", "A2");
                //Console.WriteLine(
                //DateTime.FromOADate(double.Parse(value)).ToShortDateString());
                for (int i = 0; i <= 154; i++)
                {
                    string qTargetCell = "A" + (i + 1).ToString();
                    string taTargetCell = "B" + (i + 1).ToString();
                    qArr[i] = GetCellValue(fileName, "Лист1", qTargetCell);
                    trueAnswerArr[i] = GetCellValue(fileName, "НАЧ-ПТУ-СРУ-НИОКР_ОПТИКИ", taTargetCell);
                }
                qLabelContent.Text = qArr[new Random().Next(0, qArr.Length)];
            }



            
        }
    }
}
