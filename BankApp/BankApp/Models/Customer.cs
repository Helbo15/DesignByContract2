using BankApp.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Models
{
    public class Customer : IFCustomer
    {
        public Customer(string name,int id,IFBank bankInfo)
        {
            Accounts = new List<Account>();
            this.Name = name;
            this.Id = id;
            this.BankInfo = bankInfo;
        }
        public ICollection<Account> Accounts { get; set; }
        public IFBank BankInfo { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
