using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Models.Contracts
{
    [ContractClass(typeof(MovementContract))]
    public interface IFMovement
    {
        DateTime Date { get; set; }
        decimal Amount { get; set; }
        IFAccount Target { get; set; }
        IFAccount Source { get; set; }
    }
}
