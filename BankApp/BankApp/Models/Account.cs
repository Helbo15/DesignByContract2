using BankApp.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Models
{
    public class Account : IFAccount
    {
        public Account(IFBank bankInfo, IFCustomer CustomerInfo, int number)
        {
            this.BankInfo = bankInfo;
            this.CustomerInfo = CustomerInfo;
            this.Number = number;
            this.InOutMovement = new List<IFMovement>();
            //this.InOutMovement.Add(FirstInMovement);
        }
        public decimal Balance
        {
            get
            {
                //decimal returnval = 0m;
                //foreach (IFMovement mov in InOutMovement)
                //{
                //    if (mov.Source.Equals(this.Number))
                //    {
                //        returnval -= mov.Amount;
                //    }
                //    else if (mov.Target.Equals(this.Number))
                //    {
                //        returnval += mov.Amount;
                //    }
                //}
                //return returnval;
                // decimal returnval = InOutMovement.Sum<IFMovement>(mov => (mov.Source.Number.Equals(this.Number) ? -mov.Amount : mov.Amount));
                //return returnval>=0 ? returnval : 0;
                return InOutMovement.Sum<IFMovement>(mov => (mov.Source.Number.Equals(this.Number) && mov.Source.BankInfo.Name.Equals(this.BankInfo.Name)) ? -mov.Amount : mov.Amount);
            }
        }

        public IFBank BankInfo { get; set; }

        public IFCustomer CustomerInfo { get; set; }

        public ICollection<IFMovement> InOutMovement { get; set; }

        public int Number { get; set; }
    }
}
