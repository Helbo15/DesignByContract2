using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Models.Contracts
{
    [ContractClassFor(typeof(IFMovement))]
    public abstract class MovementContract : IFMovement
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public IFAccount Source { get; set; }
        public IFAccount Target { get; set; }


        [ContractInvariantMethod]
        private void Invariants()
        {
            Contract.Invariant(Amount >= 0);
            Contract.Invariant(Date != null);
            Contract.Invariant(Source != null);
            Contract.Invariant(Target != null);
            
        }
    }
}
