using System;

namespace DIO.Bank
{
	/// <summary>
	/// The Bank Account entity
	/// </summary>
	public class BankAccount
	{
		/// <summary>
		/// Reference the account type.
		/// </summary>
		private AccountType AccountType { get; set; }

		/// <summary>
		/// The Bank Balance
		/// </summary>
		private double BankBalance { get; set; }

		/// <summary>
		/// The Bank Credit
		/// </summary>
		private double BankCredit { get; set; }

		/// <summary>
		/// Name of Bank account of person
		/// </summary>
		private string Name { get; set; }

		/// <summary>
		/// Represents the account bank
		/// </summary>
		/// <param name="accountType"></param>
		/// <param name="bankBalance"></param>
		/// <param name="bankCredit"></param>
		/// <param name="name"></param>
		public BankAccount(AccountType accountType, double bankBalance, double bankCredit, string name)
		{
			this.AccountType = accountType;
			this.BankBalance = bankBalance;
			this.BankCredit = bankCredit;
			this.Name = name;
		}

		/// <summary>
		/// Returns true if it is possible to withdraw the amount from the bank account.
		/// </summary>
		/// <param name="withdrawalAmount"></param>
		/// <returns></returns>
		public bool Withdraw(double withdrawalAmount)
		{
            if (this.BankBalance - withdrawalAmount < (this.BankCredit *-1)){
                Console.WriteLine("Insufficient bank balance!");
                return false;
            }
            this.BankBalance -= withdrawalAmount;

            Console.WriteLine("Current bank balance of the account of {0} é {1}", this.Name, this.BankBalance);

            return true;
		}

		/// <summary>
		/// Make the deposit in the account and print the bank balance.
		/// </summary>
		/// <param name="depositAmount"></param>
		public void Deposit(double depositAmount)
		{
			this.BankBalance += depositAmount;

            Console.WriteLine("Current bank balance of the account of {0} is {1}", this.Name, this.BankBalance);
		}

		/// <summary>
		/// Deposits the withdrawal amount from the source account in a destination account
		/// </summary>
		/// <param name="transferValue"></param>
		/// <param name="destinationAccount"></param>
		public void Tranfer(double transferValue, BankAccount destinationAccount)
		{
			if (this.Withdraw(transferValue)){
                destinationAccount.Deposit(transferValue);
            }
		}

		/// <summary>
		/// Print information to console
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
            string retorno = "";
            retorno += "Account Type " + this.AccountType + " | ";
            retorno += "Name " + this.Name + " | ";
            retorno += "Bank Balance " + this.BankBalance + " | ";
            retorno += "Bank credit " + this.BankCredit;
			return retorno;
		}
	}
}