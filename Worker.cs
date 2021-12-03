namespace payroll_software_learn_cs_in_one_day_book_project
{
    internal class Worker : Staff
    {
        public Worker(string name) : base(name, _rate)
        {
        }

        private const decimal _rate = 20;

        public override void CalculatePay()
        {
            base.CalculatePay();
        }

        public override string ToString()
        {
            return $"\nStaff Member: {StaffName}\nWorked Hours: {HoursWorked}\nHourly Rate: {_rate:C}\nTotal Pay: {TotalPay:C}";
        }
    }
}
