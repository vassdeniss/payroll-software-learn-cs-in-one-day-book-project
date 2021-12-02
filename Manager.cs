namespace payroll_software_learn_cs_in_one_day_book_project
{
    internal class Manager : Staff
    {
        public Manager(string name) : base(name, _managerHourlyRate)
        {
        }

        private const decimal _managerHourlyRate = 50;

        public int Allowance { get; private set; }

        public override void CalculatePay()
        {
            base.CalculatePay();
            Allowance = 1000;
            if (HoursWorked > 160) TotalPay += Allowance;
        }

        public override string ToString()
        {
            return $"\nStaff Member: {StaffName}\nWorked Hours: {HoursWorked}\nHourly Rate: {_managerHourlyRate}\nTotal Pay: {TotalPay}";
        }
    }
}
