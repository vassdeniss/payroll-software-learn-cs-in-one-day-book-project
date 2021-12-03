using System;
using System.Collections.Generic;
using System.IO;

namespace payroll_software_learn_cs_in_one_day_book_project
{
    internal class FileReader
    {
        List<Staff> _staffList = new List<Staff>();
        string[] _result = new string[2];
        string _fileName = "staff.txt";

        public List<Staff> ReadFile()
        {
            if (File.Exists(_fileName))
            {
                using StreamReader sr = new StreamReader(_fileName);
                while (!sr.EndOfStream)
                {
                    _result = sr.ReadLine().Split(", ");

                    if (_result[1] == "Manager") _staffList.Add(new Manager(_result[0]));
                    else if (_result[1] == "Admin") _staffList.Add(new Admin(_result[0]));
                    else _staffList.Add(new Worker(_result[0]));
                }
                sr.Close();
            }
            else Console.WriteLine("Error! File not found!");

            return _staffList;
        }
    }
}
