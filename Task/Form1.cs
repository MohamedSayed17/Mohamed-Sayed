using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task;

namespace tASK
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<EmployeeDTO> employeeDtoList = new List<EmployeeDTO>();
            List<ProjectDTO> projectDtoList = new List<ProjectDTO>();
            List<PairesEmployeeDto> pairesEmployeeDtoList = new List<PairesEmployeeDto>();
            List<PairesEmployeeDto> allPairesEmployeeList = new List<PairesEmployeeDto>();
            List<string> pairesEmployee = new List<string>();

            // get file from path
            string[] textData = System.IO.File.ReadAllLines("../../Task.txt");
            string[] headers = textData[0].Split(',');

            //Create and populate DataTable            
            for (int i = 1; i < textData.Length; i++)
            {
                // add the data from file in object
                EmployeeDTO employeeDto = new EmployeeDTO();
                employeeDto.EmployeeID = Convert.ToInt32(textData[i].Split(',')[0]);
                employeeDto.ProjectID = Convert.ToInt32(textData[i].Split(',')[1]);
                employeeDto.DateFrom = textData[i].Split(',')[2];

                // check if the toDate is null to update it to be today date 
                if (string.Compare(textData[i].Split(',')[3], "null", true) != 0)
                    employeeDto.DateTo = textData[i].Split(',')[3];
                else
                    employeeDto.DateTo = DateTime.Now.ToString("yyyy-MM-dd");
                employeeDtoList.Add(employeeDto);
            }

            // get all projects grouped by ProjectID
            var groupedDataByProjectID = employeeDtoList.GroupBy(p => p.ProjectID).ToList();
            foreach (var project in groupedDataByProjectID)
            {
                // get project data
                var projectDate = project.Select(a => new { a.DateFrom, a.DateTo, a.EmployeeID }).ToList();
                double previousWorkingDay = 0;

                // for loop for each project employee
                for (int i = 0; i < projectDate.Count; i++)
                {
                    PairesEmployeeDto pairesEmployeeDto = new PairesEmployeeDto();
                    var employee1Dto = projectDate[i];
                    DateTime dateFrom = Convert.ToDateTime(employee1Dto.DateFrom);
                    int counter = i + 1;
                    // counter to get each next employee to check start and end date for eachone
                    while (counter < projectDate.Count)
                    {
                        counter++;
                        var employee2Dto = projectDate[counter - 1];
                        DateTime dateTo = Convert.ToDateTime(employee2Dto.DateTo);
                        double workingDays = 0;

                        // check if date of first employee equal to the date of the next employee

                        if (dateFrom != Convert.ToDateTime(employee2Dto.DateFrom))
                        {
                            TimeSpan workingDayForEmp1 = Convert.ToDateTime(employee1Dto.DateTo).Subtract(dateFrom);
                            TimeSpan workingDayForEmp2 = Convert.ToDateTime(dateTo).Subtract(Convert.ToDateTime(employee2Dto.DateFrom));

                            workingDays = workingDayForEmp1.TotalDays + workingDayForEmp2.TotalDays;
                        }
                        else
                        {
                            TimeSpan difference = dateTo.Subtract(dateFrom);
                            workingDays = difference.TotalDays;
                        }

                        // check the working days to get the make working data 
                        if (workingDays > previousWorkingDay && previousWorkingDay != 0 && workingDays != previousWorkingDay)
                        {
                            pairesEmployeeDto.EmployeeID1 = employee1Dto.EmployeeID;
                            pairesEmployeeDto.EmployeeID2 = employee2Dto.EmployeeID;
                            pairesEmployeeDto.workingDays = workingDays;
                            pairesEmployeeDto.projectID = project.Key;
                            pairesEmployeeDtoList.Clear();
                            // list for max working day of project
                            pairesEmployeeDtoList.Add(pairesEmployeeDto);
                        }
                        previousWorkingDay = workingDays;
                    }
                }
                // all paired employees for each project 
                allPairesEmployeeList.AddRange(pairesEmployeeDtoList);
            }
            dataGridForPairedEmployees.DataSource = allPairesEmployeeList;
            
        }
    }
}
