namespace payroll_software_learn_cs_in_one_day_book_project
{
    internal class Admin : Staff
    {
        public Admin(string name) : base(name, _adminHourlyRate)
        {
        }

        private const decimal _overtimeRate = 15.5m;
        private const decimal _adminHourlyRate = 30;

        public decimal Overtime { get; private set; }

        public override void CalculatePay()
        {
            base.CalculatePay();
            if (HoursWorked > 160)
            {
                Overtime = _overtimeRate * (HoursWorked - 160);
                TotalPay += Overtime;
            }
        }

        public override string ToString()
        {
            return $"\nStaff Member: {StaffName}\nWorked Hours: {HoursWorked}\nHourly Rate: {_adminHourlyRate}\nTotal Pay: {TotalPay}";
        }
    }
}
