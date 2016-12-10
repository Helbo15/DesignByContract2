using BankApp.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Models
{
    public class Movement : IFMovement
    {
        public Movement(decimal amount,DateTime date,IFAccount source,IFAccount target)
        {
            this.Amount = amount;
            this.Date = date;
            this.Source = source;
            this.Target = target;
        }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public IFAccount Source { get; set; }
        public IFAccount Target { get; set; }
    }
}
