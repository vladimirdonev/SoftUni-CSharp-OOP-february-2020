namespace MilitaryElite.Models
{
    using MilitaryElite.Contracts;
    public class Private : Soldier, IPrivate
    {
        public Private(int id, string firstname, string lastname,decimal salary) 
            : base(id, firstname, lastname)
        {
            this.Salary = salary;
        }

        public decimal Salary { get; private set; }
        public override string ToString()
        {
            return base.ToString() + $" Salary: {this.Salary}"; 
        }
    }
}
