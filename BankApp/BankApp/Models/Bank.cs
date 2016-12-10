using BankApp.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Models
{
    public class Bank : IFBank
    {
        private int nextAccountNumber;
        public IList<IFBank> banks { get; set; }
        public Bank(string name)
        {
            Accounts = new List<IFAccount>();
            Customers = new List<IFCustomer>();
            this.Name = name;
            nextAccountNumber = 1;
        }
        public ICollection<IFAccount> Accounts { get; set; }
        public ICollection<IFCustomer> Customers { get; set; }
        public string Name { get; set; }

        public int GetNextAccountNumber()
        {
            return nextAccountNumber++;
        }

        public ICollection<IFMovement> MakeStatement(IFCustomer aCustomer, IFAccount aAccount)
        {
            return aAccount.InOutMovement;
        }

        public void Move(decimal amount, int source, int target)
        {
            IFBank targetBank = banks.FirstOrDefault(b=> b.Accounts.ToList<IFAccount>().Exists(acc=>acc.Number.Equals(target)) );
            IFAccount transferTargetAccount = targetBank.Accounts.FirstOrDefault(acc => acc.Number.Equals(target));
            IFAccount transverSourceAccount = this.Accounts.FirstOrDefault<IFAccount>(acc => acc.Number.Equals(source));
            transverSourceAccount.InOutMovement.Add(new Movement(amount, DateTime.Now, transverSourceAccount, transferTargetAccount));
            transferTargetAccount.InOutMovement.Add(new Movement(amount, DateTime.Now, transverSourceAccount, transferTargetAccount));

        }
    }
}
