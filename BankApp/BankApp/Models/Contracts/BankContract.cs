using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Models.Contracts
{
    [ContractClassFor(typeof(IFBank))]
    public abstract class BankContract : IFBank
    {
        private int nextAccountNumber;  
        public ICollection<IFAccount> Accounts { get; set; }
        public IList<IFBank> banks { get; set; }
        public ICollection<IFCustomer> Customers { get; set; }
        public string Name { get; set; }

        public int GetNextAccountNumber()
        {
            Contract.Ensures(!Accounts.Any(acc => acc.Number.Equals(nextAccountNumber)));
            return nextAccountNumber;
        }

        public ICollection<IFMovement> MakeStatement(IFCustomer aCustomer, IFAccount aAccount)
        {
            Contract.Requires(aCustomer.Accounts.Contains(aAccount));
            return null;
        }
        public void Move(decimal amount, int source, int target)
        {
            Contract.Requires(amount > 0);
            Contract.Requires(source > 0);
            Contract.Requires(target > 0);
            //Contract.Requires(Accounts.Any(a => a.Number.Equals(source)));
            //Contract.Requires(Accounts.Any(a => a.Number.Equals(target)));
            Contract.Requires(Accounts.First(a => a.Number.Equals(source)).Balance >= amount);
            Contract.Ensures(banks.FirstOrDefault(b => b.Accounts.Any<IFAccount>(acc => acc.Number.Equals(source))).Accounts.FirstOrDefault(acc => acc.Number.Equals(source)) != null);
            Contract.Ensures(banks.FirstOrDefault(b => b.Accounts.Any<IFAccount>(acc => acc.Number.Equals(target))).Accounts.FirstOrDefault(acc => acc.Number.Equals(target)) != null);


        }

        [ContractInvariantMethod]
        private void Invariants()
        {
            Contract.Invariant(nextAccountNumber > 0);
            Contract.Invariant(Name != null);
            Contract.Invariant(Customers != null);
            Contract.Invariant(Accounts != null);
        }
    }
}
