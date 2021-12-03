using System;
using System.Collections.Generic;

namespace payroll_software_learn_cs_in_one_day_book_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int year = 0;
            while (year == 0)
            {
                Console.Write("Please enter the year: ");

                try
                {
                    year = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error! Invalid year!");
                }
            }

            int month = 0;
            while (month == 0)
            {
                Console.Write("Please enter the month: ");

                try
                {
                    month = int.Parse(Console.ReadLine());
                    if (month < 1 || month > 12)
                    {
                        Console.WriteLine("Error! Invalid month!");
                        month = 0;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error! Invalid month!");
                }
            }

            FileReader reader = new FileReader();
            List<Staff> staffList = reader.ReadFile();
            for (int i = 0; i < staffList.Count; i++)
            {
                try
                {
                    Console.WriteLine($"\nEnter hours worked for {staffList[i].StaffName}: ");
                    staffList[i].HoursWorked = int.Parse(Console.ReadLine());
                    staffList[i].CalculatePay();
                    Console.WriteLine(staffList[i]);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    i--;
                }
            }

            PaySlip ps = new PaySlip(year, month);
            ps.GeneratePaySlip(staffList);
            ps.GenerateSummary(staffList);

            Console.ReadLine();
        }
    }
}
