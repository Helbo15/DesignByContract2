using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace BankApp.Models.Contracts
{
    [ContractClass(typeof(AccountContract))]

    public interface IFAccount
    {
        int Number { get; set; }
        decimal Balance { get;}
        IFBank BankInfo { get; set; }
        IFCustomer CustomerInfo { get; set; }

        ICollection<IFMovement> InOutMovement { get; set; }
    }
}