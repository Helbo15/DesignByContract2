using BankApp.Models;
using BankApp.Models.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BankApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private int nextAccountNumber =1;
        private List<IFBank> banks;
        private IFBank selectedBank;
        private IFCustomer SelectedCustomer;
        private IFAccount selectedAccount;
        private IFAccount depositWithdrawAccount;

        public MainPage()
        {
            this.InitializeComponent();
            //MainGrid.MaxHeight = main.MinHeight;
            //Accounts.MaxHeight = main.MinHeight;
            //AccountsScroll.MaxHeight = main.MinHeight;

            banks = new List<IFBank>();
            banks.Add(new Bank("Nordea"));
            banks[0].Customers.Add(new Customer("Ole Hansen", 1, banks[0]));
            banks[0].Customers.Add(new Customer("Bent Jensen", 2, banks[0]));
            banks[0].Customers.Add(new Customer("Kurt Jensen", 3, banks[0]));
            banks.Add(new Bank("Danske Bank"));
            banks[1].Customers.Add(new Customer("Ole Hansen", 1, banks[1]));
            banks[1].Customers.Add(new Customer("Børge jørgensen", 2, banks[1]));
            banks[1].Customers.Add(new Customer("Aase Olsen", 3, banks[1]));
            banks.Add(new Bank("Jyske Bank"));
            banks[2].Customers.Add(new Customer("Søren Christensen", 1, banks[2]));
            banks[2].Customers.Add(new Customer("Ida Sørensen", 2, banks[2]));
            banks[2].Customers.Add(new Customer("Freja Hansen", 3, banks[2]));
            banks[0].banks = banks;
            banks[1].banks = banks;
            banks[2].banks = banks;
            selectedBank = null;
            SelectedCustomer = null;
            selectedAccount = null;
            Bank depositWithdrawBank = new Bank("dWBank");
            depositWithdrawBank.Customers.Add(new Customer("dWCustomer", 1, depositWithdrawBank));
            depositWithdrawAccount = new Account(depositWithdrawBank, depositWithdrawBank.Customers.ToList()[0], depositWithdrawBank.GetNextAccountNumber());
            depositWithdrawBank.Accounts.Add(depositWithdrawAccount);
            
        }

        private void BtnNordea_Click(object sender, RoutedEventArgs e)
        {
            selectedBank = banks[0];
            ((Button)SecondRowItem1.Children[0]).Content = selectedBank.Customers.ToList<IFCustomer>()[0].Name;
            ((Button)SecondRowItem2.Children[0]).Content = selectedBank.Customers.ToList<IFCustomer>()[1].Name;
            ((Button)SecondRowItem3.Children[0]).Content = selectedBank.Customers.ToList<IFCustomer>()[2].Name;
            AccountList.Items.Clear();
            AddAccount.Content = "";
            AccountList.Items.Add(AddAccount);
        }

        private void BtnDanskeBank_Click(object sender, RoutedEventArgs e)
        {
            selectedBank = banks[1];
            ((Button)SecondRowItem1.Children[0]).Content = selectedBank.Customers.ToList<IFCustomer>()[0].Name;
            ((Button)SecondRowItem2.Children[0]).Content = selectedBank.Customers.ToList<IFCustomer>()[1].Name;
            ((Button)SecondRowItem3.Children[0]).Content = selectedBank.Customers.ToList<IFCustomer>()[2].Name;
            AccountList.Items.Clear();
            AddAccount.Content = "";
            AccountList.Items.Add(AddAccount);
        }

        private void BtnJyskeBank_Click(object sender, RoutedEventArgs e)
        {
            selectedBank = banks[2];
            ((Button)SecondRowItem1.Children[0]).Content = selectedBank.Customers.ToList<IFCustomer>()[0].Name;
            ((Button)SecondRowItem2.Children[0]).Content = selectedBank.Customers.ToList<IFCustomer>()[1].Name;
            ((Button)SecondRowItem3.Children[0]).Content = selectedBank.Customers.ToList<IFCustomer>()[2].Name;
            AccountList.Items.Clear();
            AddAccount.Content = "";
            AccountList.Items.Add(AddAccount);
        }

        private void BtnFirstPerson_Click(object sender, RoutedEventArgs e)
        {
            AccountList.Items.Clear();
            SelectedCustomer = selectedBank.Customers.ToList<IFCustomer>()[0];
            Button addAccountBTn = new Button();
            addAccountBTn.Content = "Add account";
            //addAccountBTn.Padding = new Thickness(6.0d);
            //addAccountBTn.Margin = new Thickness(0.0d);
            addAccountBTn.FontSize = 10;
            addAccountBTn.HorizontalAlignment = HorizontalAlignment.Stretch;
            addAccountBTn.Click += BtnAddAccount_Click; 
            AddAccount.Content = addAccountBTn;
            AccountList.Items.Add(AddAccount);
            foreach (Account acc in SelectedCustomer.Accounts)
            {
                ListViewItem accNumber = new ListViewItem();
                Button btnAccNumber = new Button();
                btnAccNumber.Content = acc.Number;

                btnAccNumber.Click += btnViewAccount_Click;
                accNumber.Content = btnAccNumber;
                AccountList.Items.Add(accNumber);
            }
        }

        private void BtnSecondPerson_Click(object sender, RoutedEventArgs e)
        {

            AccountList.Items.Clear();
            SelectedCustomer = selectedBank.Customers.ToList<IFCustomer>()[1];
            Button addAccountBTn = new Button();
            addAccountBTn.Content = "Add account";
            //addAccountBTn.Padding = new Thickness(6.0d);
            //addAccountBTn.Margin = new Thickness(0.0d);
            addAccountBTn.FontSize = 10;
            addAccountBTn.HorizontalAlignment = HorizontalAlignment.Stretch;
            addAccountBTn.Click += BtnAddAccount_Click;
            AddAccount.Content = addAccountBTn;
            AccountList.Items.Add(AddAccount);

            foreach (Account acc in SelectedCustomer.Accounts)
            {
                ListViewItem accNumber = new ListViewItem();
                Button btnAccNumber = new Button();
                btnAccNumber.Content = acc.Number;

                btnAccNumber.Click += btnViewAccount_Click;
                accNumber.Content = btnAccNumber;
                AccountList.Items.Add(accNumber);
            }
        }

        private void BtnThirdPerson_Click(object sender, RoutedEventArgs e)
        {

            AccountList.Items.Clear();
            SelectedCustomer = selectedBank.Customers.ToList<IFCustomer>()[2];
            Button addAccountBTn = new Button();
            addAccountBTn.Content = "Add account";
            //addAccountBTn.Padding = new Thickness(6.0d);
            //addAccountBTn.Margin = new Thickness(0.0d);
            addAccountBTn.FontSize = 10;
            addAccountBTn.HorizontalAlignment = HorizontalAlignment.Stretch;
            addAccountBTn.Click += BtnAddAccount_Click;
            AddAccount.Content = addAccountBTn;
            AccountList.Items.Add(AddAccount);

            foreach (Account acc in SelectedCustomer.Accounts)
            {
                ListViewItem accNumber = new ListViewItem();
                Button btnAccNumber = new Button();
                btnAccNumber.Content = acc.Number;

                btnAccNumber.Click += btnViewAccount_Click;
                accNumber.Content = btnAccNumber;

                AccountList.Items.Add(accNumber);
            }
        }

        private void BtnAddAccount_Click(object sender, RoutedEventArgs e)
        {
            Account newAccount = new Account(selectedBank, SelectedCustomer, this.GetNextAccountNumber());
            selectedBank.Accounts.Add(newAccount);
            SelectedCustomer.Accounts.Add(newAccount);
            ListViewItem accNumber =new ListViewItem();
            Button btnAccNumber = new Button();
            btnAccNumber.Content = SelectedCustomer.Accounts.FirstOrDefault(acc=> acc.Number == newAccount.Number).Number;
            btnAccNumber.FontSize = 14;
            btnAccNumber.Click += btnViewAccount_Click;
            accNumber.Content = btnAccNumber;
            AccountList.Items.Add(accNumber);
        }

        private int GetNextAccountNumber()
        {
            return nextAccountNumber++;
        }

        private void btnViewAccount_Click(object sender, RoutedEventArgs e)
        {
            selectedAccount = SelectedCustomer.Accounts.FirstOrDefault(acc => acc.Number.Equals(((Button)sender).Content));
            DateList.Items.Clear();
            AmountList.Items.Clear();
            TargetList.Items.Clear();
            SourceList.Items.Clear();
          
            ListViewHeaderItem HeaderDate = new ListViewHeaderItem();
            ListViewHeaderItem HeaderSource = new ListViewHeaderItem();
            ListViewHeaderItem HeaderTarget = new ListViewHeaderItem();
            ListViewHeaderItem HeaderAmount = new ListViewHeaderItem();
            TextBlock dateText = new TextBlock();
            TextBlock sourceText = new TextBlock();
            TextBlock targetText = new TextBlock();
            TextBlock amountText = new TextBlock();
            dateText.Text = "Date";
            sourceText.Text = "Source";
            targetText.Text = "Target";
            amountText.Text = "Amount";
            HeaderDate.Content = dateText;
            HeaderSource.Content = sourceText;
            HeaderTarget.Content = targetText;
            HeaderAmount.Content = amountText;
            AmountList.Items.Add(HeaderAmount);
            TargetList.Items.Add(HeaderTarget);
            SourceList.Items.Add(HeaderSource);
            DateList.Items.Add(HeaderDate);

            List<IFMovement> movementList = selectedBank.MakeStatement(SelectedCustomer, selectedAccount).ToList<IFMovement>(); 
            foreach(IFMovement aMovement in movementList)
            {
                ListViewItem AmountItem = new ListViewItem();
                ListViewItem TargetItem = new ListViewItem();
                ListViewItem SourceItem = new ListViewItem();
                ListViewItem DateItem = new ListViewItem();
                AmountItem.Content = aMovement.Amount;
                TargetItem.Content = aMovement.Target.BankInfo.Name +": " + aMovement.Target.Number;
                SourceItem.Content = aMovement.Source.BankInfo.Name + ": " + aMovement.Source.Number;
                DateItem.Content = aMovement.Date.ToString();
                AmountList.Items.Add(AmountItem);
                TargetList.Items.Add(TargetItem);
                SourceList.Items.Add(SourceItem);
                DateList.Items.Add(DateItem);
            }
            accBallance.Text = selectedAccount.Balance.ToString();


        }

        private void depositBtn_click(object sender, RoutedEventArgs e)
        {
            selectedAccount.InOutMovement.Add(new Movement(100.00m, DateTime.Now, depositWithdrawAccount, selectedAccount));
            DateList.Items.Clear();
            AmountList.Items.Clear();
            TargetList.Items.Clear();
            SourceList.Items.Clear();

            ListViewHeaderItem HeaderDate = new ListViewHeaderItem();
            ListViewHeaderItem HeaderSource = new ListViewHeaderItem();
            ListViewHeaderItem HeaderTarget = new ListViewHeaderItem();
            ListViewHeaderItem HeaderAmount = new ListViewHeaderItem();
            TextBlock dateText = new TextBlock();
            TextBlock sourceText = new TextBlock();
            TextBlock targetText = new TextBlock();
            TextBlock amountText = new TextBlock();
            dateText.Text = "Date";
            sourceText.Text = "Source";
            targetText.Text = "Target";
            amountText.Text = "Amount";
            HeaderDate.Content = dateText;
            HeaderSource.Content = sourceText;
            HeaderTarget.Content = targetText;
            HeaderAmount.Content = amountText;
            AmountList.Items.Add(HeaderAmount);
            TargetList.Items.Add(HeaderTarget);
            SourceList.Items.Add(HeaderSource);
            DateList.Items.Add(HeaderDate);

            List<IFMovement> movementList = selectedBank.MakeStatement(SelectedCustomer, selectedAccount).ToList<IFMovement>();
            foreach (IFMovement aMovement in movementList)
            {
                ListViewItem AmountItem = new ListViewItem();
                ListViewItem TargetItem = new ListViewItem();
                ListViewItem SourceItem = new ListViewItem();
                ListViewItem DateItem = new ListViewItem();
                AmountItem.Content = aMovement.Amount;
                TargetItem.Content = aMovement.Target.BankInfo.Name + ": " + aMovement.Target.Number;
                SourceItem.Content = aMovement.Source.BankInfo.Name + ": " + aMovement.Source.Number;
                DateItem.Content = aMovement.Date.ToString();
                AmountList.Items.Add(AmountItem);
                TargetList.Items.Add(TargetItem);
                SourceList.Items.Add(SourceItem);
                DateList.Items.Add(DateItem);
            }
            accBallance.Text = selectedAccount.Balance.ToString();
        }

        private void withDrawBtn_Click(object sender, RoutedEventArgs e)
        {
            selectedAccount.InOutMovement.Add(new Movement(100.00m, DateTime.Now, selectedAccount,depositWithdrawAccount ));
            DateList.Items.Clear();
            AmountList.Items.Clear();
            TargetList.Items.Clear();
            SourceList.Items.Clear();

            ListViewHeaderItem HeaderDate = new ListViewHeaderItem();
            ListViewHeaderItem HeaderSource = new ListViewHeaderItem();
            ListViewHeaderItem HeaderTarget = new ListViewHeaderItem();
            ListViewHeaderItem HeaderAmount = new ListViewHeaderItem();
            TextBlock dateText = new TextBlock();
            TextBlock sourceText = new TextBlock();
            TextBlock targetText = new TextBlock();
            TextBlock amountText = new TextBlock();
            dateText.Text = "Date";
            sourceText.Text = "Source";
            targetText.Text = "Target";
            amountText.Text = "Amount";
            HeaderDate.Content = dateText;
            HeaderSource.Content = sourceText;
            HeaderTarget.Content = targetText;
            HeaderAmount.Content = amountText;
            AmountList.Items.Add(HeaderAmount);
            TargetList.Items.Add(HeaderTarget);
            SourceList.Items.Add(HeaderSource);
            DateList.Items.Add(HeaderDate);

            List<IFMovement> movementList = selectedBank.MakeStatement(SelectedCustomer, selectedAccount).ToList<IFMovement>();
            foreach (IFMovement aMovement in movementList)
            {
                ListViewItem AmountItem = new ListViewItem();
                ListViewItem TargetItem = new ListViewItem();
                ListViewItem SourceItem = new ListViewItem();
                ListViewItem DateItem = new ListViewItem();
                AmountItem.Content = aMovement.Amount;
                TargetItem.Content = aMovement.Target.BankInfo.Name + ": " + aMovement.Target.Number;
                SourceItem.Content = aMovement.Source.BankInfo.Name + ": " + aMovement.Source.Number;
                DateItem.Content = aMovement.Date.ToString();
                AmountList.Items.Add(AmountItem);
                TargetList.Items.Add(TargetItem);
                SourceList.Items.Add(SourceItem);
                DateList.Items.Add(DateItem);
            }
            accBallance.Text = selectedAccount.Balance.ToString();
        }

        //private void makeStatmentBtn_Click(object sender, RoutedEventArgs e)
        //{

        //}

        private void moveBtn_Click(object sender, RoutedEventArgs e)
        {
            //IFAccount transferTargetAccount = banks.FirstOrDefault(Ab => Ab.Name.Equals(BankDestination.Text)).Accounts.FirstOrDefault(acc => acc.Number.Equals(int.Parse(AccountNumber.Text)));
            //selectedAccount.InOutMovement.Add(new Movement(decimal.Parse(TransferAmount.Text), DateTime.Now, selectedAccount, transferTargetAccount));
            //transferTargetAccount.InOutMovement.Add(new Movement(decimal.Parse(TransferAmount.Text), DateTime.Now, selectedAccount, transferTargetAccount));
            selectedBank.Move(decimal.Parse(TransferAmount.Text), selectedAccount.Number, int.Parse(AccountNumber.Text));

            DateList.Items.Clear();
            AmountList.Items.Clear();
            TargetList.Items.Clear();
            SourceList.Items.Clear();

            ListViewHeaderItem HeaderDate = new ListViewHeaderItem();
            ListViewHeaderItem HeaderSource = new ListViewHeaderItem();
            ListViewHeaderItem HeaderTarget = new ListViewHeaderItem();
            ListViewHeaderItem HeaderAmount = new ListViewHeaderItem();
            TextBlock dateText = new TextBlock();
            TextBlock sourceText = new TextBlock();
            TextBlock targetText = new TextBlock();
            TextBlock amountText = new TextBlock();
            dateText.Text = "Date";
            sourceText.Text = "Source";
            targetText.Text = "Target";
            amountText.Text = "Amount";
            HeaderDate.Content = dateText;
            HeaderSource.Content = sourceText;
            HeaderTarget.Content = targetText;
            HeaderAmount.Content = amountText;
            AmountList.Items.Add(HeaderAmount);
            TargetList.Items.Add(HeaderTarget);
            SourceList.Items.Add(HeaderSource);
            DateList.Items.Add(HeaderDate);

            List<IFMovement> movementList = selectedBank.MakeStatement(SelectedCustomer, selectedAccount).ToList<IFMovement>();

            foreach (IFMovement aMovement in movementList)
            {
                ListViewItem AmountItem = new ListViewItem();
                ListViewItem TargetItem = new ListViewItem();
                ListViewItem SourceItem = new ListViewItem();
                ListViewItem DateItem = new ListViewItem();

                AmountItem.Content = aMovement.Amount;
                TargetItem.Content = aMovement.Target.BankInfo.Name + ": " + aMovement.Target.Number;
                SourceItem.Content = aMovement.Source.BankInfo.Name + ": " + aMovement.Source.Number;
                DateItem.Content = aMovement.Date.ToString();
                AmountList.Items.Add(AmountItem);
                TargetList.Items.Add(TargetItem);
                SourceList.Items.Add(SourceItem);
                DateList.Items.Add(DateItem);
            }
            accBallance.Text = selectedAccount.Balance.ToString();

        }
    }
    }
