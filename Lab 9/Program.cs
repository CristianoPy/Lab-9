
using Lab_9;

var current_Account = new Bank_Account(0,"Cristiano",AccountType.Current_Account,5000);
current_Account.deposit(100);
current_Account.withdraw(50);
current_Account.withdraw(6000);

var investment_Account = new Bank_Account(0, "Cristiano", AccountType.Investment_Account, 21);
investment_Account.deposit(1000);
investment_Account.withdraw(1000);

var savings_Account = new Bank_Account(0, AccountType.Savings_Account, "Cristiano");
savings_Account.deposit(100);
savings_Account.withdraw(60);