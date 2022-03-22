using System;
using System.Collections.Generic;

namespace DIO.Bank
{
	class Program
	{
		static List<BankAccount> bankAccountList = new List<BankAccount>();

		static void Main(string[] args)
		{
			string userOption = GetUserOption();

			while (userOption.ToUpper() != "X")
			{
				switch (userOption)
				{
					case "1":
						ListAccount();
						break;
					case "2":
						InsertAccount();
						break;
					case "3":
						ToTransfer();
						break;
					case "4":
						ToWithdraw();
						break;
					case "5":
						MakeDeposit();
						break;
                    case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				userOption = GetUserOption();
			}
			
			Console.WriteLine("Thank you for using our services!");
			Console.ReadLine();
		}

		/// <summary>
		/// Make Deposit on bank account.
		/// </summary>
		private static void MakeDeposit()
		{
			ListAccount();
			Console.Write("Enter the bank account number: ");
			int accountIndex = int.Parse(Console.ReadLine());

			Console.Write("Enter the amount to be deposited: ");
			double depositAmount = double.Parse(Console.ReadLine());

			if(depositAmount > 0 && accountIndex >= 0 && depositAmount < bankAccountList[accountIndex].BankCredit)
				bankAccountList[accountIndex].Deposit(depositAmount);
            else
            {
				Console.WriteLine("Enter a valid bank account number and valid deposit amount!");
				ListAccountByIndex(accountIndex);
			}
		}

		/// <summary>
		/// withdraws if the bank account balance allows.
		/// </summary>
		private static void ToWithdraw()
		{
			ListAccount();
			Console.Write("Enter the bank account number: ");
			int accountIndex = int.Parse(Console.ReadLine());

			Console.Write("Enter the amount to be withdrawn: ");
			double withdrawalAmount = double.Parse(Console.ReadLine());

			if (withdrawalAmount > 0 && accountIndex >= 0)
				bankAccountList[accountIndex].Withdraw(withdrawalAmount);
			else
				Console.Write("Enter a valid bank account number and withdrawal Amount!");
		}

		/// <summary>
		/// Deposits the withdrawal amount from the source account in a destination account
		/// </summary>
		private static void ToTransfer()
		{
			ListAccount();
			Console.Write("Enter the origin account number: ");
			int originAccountIndex = int.Parse(Console.ReadLine());

            Console.Write("Enter the destination account number: ");
			int destinationAccountIndex = int.Parse(Console.ReadLine());

			Console.Write("Enter the amount to be transferred: ");
			double transferAmount = double.Parse(Console.ReadLine());

			int lenthOfListBankaccount = bankAccountList.Count;

			if(lenthOfListBankaccount < 2)
            {
				Console.WriteLine("It is necessary to inform a second account to carry out the bank transfer: ");
				ListAccount();
				Console.WriteLine(" ");
				InsertAccount();
			}
			else
				bankAccountList[originAccountIndex].Tranfer(transferAmount, bankAccountList[destinationAccountIndex]);
		}

		/// <summary>
		/// Enter a bank account as a record
		/// </summary>
		private static void InsertAccount()
		{
			Console.WriteLine("Enter a new bank account:");

			// Resolver essa condição!
			Console.Write("Enter '1' for natural person or '2' for legal person: ");
			int inputAccountType = int.Parse(Console.ReadLine());

			Console.Write("Enter client name: ");
			string inputName = Console.ReadLine();

			Console.Write("Enter the opening balance: ");
			double inputBankBalance = double.Parse(Console.ReadLine());

			Console.Write("Enter bank account credit: ");
			double inputBankCredit = double.Parse(Console.ReadLine());

			BankAccount newBankAccount = new BankAccount((AccountType)inputAccountType,
										inputBankBalance,
										inputBankCredit,
										inputName);

			bankAccountList.Add(newBankAccount);
		}

		/// <summary>
		/// List of registered bank accounts
		/// </summary>
		private static void ListAccount()
		{
			Console.WriteLine("List bank accounts:");

			if (bankAccountList.Count == 0)
			{
				Console.WriteLine("No bank account registered!");
				return;
			}

			for (int i = 0; i < bankAccountList.Count; i++)
			{
				BankAccount account = bankAccountList[i];
				Console.Write("#{0} - ", i);
				Console.WriteLine(account);
			}
		}

		/// <summary>
		/// List of registered bank account by index
		/// </summary>
		/// <param name="accountIndex"></param>
		private static void ListAccountByIndex(int accountIndex)
		{
			Console.WriteLine("List bank account #{0}:", accountIndex);

			BankAccount account = bankAccountList[accountIndex];
			Console.WriteLine(account);
		}

		/// <summary>
		/// Get user option
		/// </summary>
		/// <returns></returns>
		private static string GetUserOption()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Bank at your service!!!");
			Console.WriteLine("Enter the desired option:");

			Console.WriteLine("1- List accounts");
			Console.WriteLine("2- Insert a new account");
			Console.WriteLine("3- Transfer an amount");
			Console.WriteLine("4- Withdraw an amount");
			Console.WriteLine("5- Make an Deposit");
            Console.WriteLine("C- Clear the screen");
			Console.WriteLine("X- Exit");
			Console.WriteLine();

			string userOption = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return userOption;
		}
	}
}
