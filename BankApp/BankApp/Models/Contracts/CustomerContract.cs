using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Models.Contracts
{
    [ContractClassFor(typeof(IFCustomer))]
    public abstract class CustomerContract : IFCustomer
    {
        public ICollection<Account> Accounts { get; set; }
        public IFBank BankInfo { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        [ContractInvariantMethod]

        private void Invariants()
        {
            Contract.Invariant(Id > 0);
            Contract.Invariant(Name != null);
            Contract.Invariant(BankInfo != null);
            Contract.Invariant(Accounts != null);
        }
    }
}
