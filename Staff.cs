using System;

namespace payroll_software_learn_cs_in_one_day_book_project
{
    internal class Staff
    {
        public Staff(string name, decimal rate)
        {
            StaffName = name;
            _hourlyRate = rate;
        }

        private decimal _hourlyRate;
        private int _hoursWorked;

        public string StaffName { get; private set; }
        public decimal TotalPay { get; protected set; }
        public decimal BasicPay { get; private set; }
        public int HoursWorked
        {
            get { return _hoursWorked; }
            set
            {
                if (value > 0) _hoursWorked = value;
                else _hoursWorked = 0;
            }
        }

        public virtual void CalculatePay()
        {
            Console.WriteLine("Calculating Pay...");
            TotalPay = BasicPay = _hoursWorked * _hourlyRate;
        }

        public override string ToString()
        {
            return $"\nStaff Member: {StaffName}\nWorked Hours: {HoursWorked}\nHourly Rate: {_hourlyRate}\nTotal Pay: {TotalPay}";
        }
    }
}
