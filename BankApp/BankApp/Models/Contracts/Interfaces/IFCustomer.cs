using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Models.Contracts
{
    [ContractClass(typeof(CustomerContract))]

    public interface IFCustomer
    {
        int Id { get; set; }
        string Name { get; set; }
        IFBank BankInfo { get; set; }
        ICollection<Account> Accounts { get; set; }
    }
}
