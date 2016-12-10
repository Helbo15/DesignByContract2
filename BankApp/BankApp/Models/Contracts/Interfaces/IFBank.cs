using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Models.Contracts
{
    [ContractClass(typeof(BankContract))]
    public interface IFBank
    {
        IList<IFBank> banks { get; set; }
        string Name { get; set; }
        void Move(decimal amount, int source, int target);
        ICollection<IFAccount> Accounts { get; set; } 
        ICollection<IFCustomer> Customers { get; set; }
        ICollection<IFMovement> MakeStatement(IFCustomer aCustomer, IFAccount aAccount);
        int GetNextAccountNumber();
    }
}
