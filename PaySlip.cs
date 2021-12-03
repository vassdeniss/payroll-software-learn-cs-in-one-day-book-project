using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace payroll_software_learn_cs_in_one_day_book_project
{
    internal class PaySlip
    {
        public PaySlip(int year, int month)
        {
            _year = year;
            _month = month;
        }

        enum Months
        {
            JAN, FEB, MAR, APR, MAY, JUNE, JUL, AUG, SEP, OCT, NOV, DEC
        }

        private int _year;
        private int _month;

        public void GeneratePaySlip(List<Staff> list)
        {
            string fileName;
            string month = Enum.GetName(typeof(Months), _month - 1);
            foreach (Staff staff in list)
            {
                fileName = $"{staff.StaffName}.txt";
                using StreamWriter sw = new StreamWriter(fileName);
                sw.WriteLine($"PAYSLIP FOR {month} {_year}");
                sw.WriteLine("====================");
                sw.WriteLine($"Staff Name: {staff.StaffName}");
                sw.WriteLine($"Hours Worked: {staff.HoursWorked}");
                sw.WriteLine("");
                sw.WriteLine($"Basic Pay: {staff.BasicPay:C}");
                if (staff is Manager manager) sw.WriteLine($"Allowance: {manager.Allowance:C}");
                if (staff is Admin admin) sw.WriteLine($"Overtime: {admin.Overtime:C}");
                sw.WriteLine("");
                sw.WriteLine("====================");
                sw.WriteLine($"Total Pay: {staff.TotalPay:C}");
                sw.WriteLine("====================");
                sw.Close();
            }
        }

        public void GenerateSummary(List<Staff> list)
        {
            var result =
                from staff in list
                where staff.HoursWorked < 10
                orderby staff.StaffName ascending
                select new { staff.StaffName, staff.HoursWorked };

            if (result.Count() > 0)
            {
                string fileName = "summary.txt";
                using StreamWriter sw = new StreamWriter(fileName);
                sw.WriteLine("Staff with less than 10 working hours");
                sw.WriteLine("");
                foreach (var staff in result)
                    sw.WriteLine($"Name of Staff: {staff.StaffName}, Hours Worked: {staff.HoursWorked}");
                sw.Close();
            }
        }

        public override string ToString() =>
            $"Month: {_month}\nYear: {_year}";
    }
}
