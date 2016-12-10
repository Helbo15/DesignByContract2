using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Models.Contracts
{
    [ContractClassFor(typeof(IFAccount))]
    public abstract class AccountContract : IFAccount
    {
        protected AccountContract(decimal balance, IFBank bankInfo, IFCustomer CustomerInfo, int number)
        {
            Contract.Requires(bankInfo.Customers.Any(cust => cust.Id.Equals(CustomerInfo.Id)));
            Contract.Requires(!bankInfo.Accounts.Any(acc => acc.Number.Equals(number)));

        }
        public decimal Balance
        {
            get
            {
                Contract.Ensures(Balance >= 0);
                return decimal.Zero;
            }

           
        }
        public IFBank BankInfo { get; set; }
        public IFCustomer CustomerInfo { get; set; }

        public ICollection<IFMovement> InOutMovement { get; set; }

        public int Number { get; set; }
        [ContractInvariantMethod]
        private void Invariants()
        {
            Contract.Invariant(BankInfo != null);
            Contract.Invariant(CustomerInfo != null);
            Contract.Invariant(Number > 0);
            Contract.Invariant(InOutMovement != null);
            
                /*InOutMovement.Sum(mov => (mov.Source.Number.Equals(this.Number) && mov.Source.BankInfo.Name.Equals(this.BankInfo.Name)) ? -mov.Amount : mov.Amount) >= 0);*/
        }
        }
}
