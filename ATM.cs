

using CLConsoleCommandUI;
using System.Security.Principal;

namespace ATM
{
	internal class ATM
	{
		//List<Account> checkingAccounts;
		//List<Account> savingAccounts;
		List<Account> accounts;
		private Account? account;
		private static readonly int WAITING_TIME=3000;

		public ATM()
		{
			//checkingAccounts =
			accounts =
			[
				new CheckingAccount(1202411, 1856.66),
				new CheckingAccount(1202412, 450.79),
				new CheckingAccount(1202413, 8056.699),
				new CheckingAccount(1202414, 125000),
				new CheckingAccount(1202415, 18.122),
				new CheckingAccount(1202416, -25),
				new SavingAccount(2202478, 1500),
				new SavingAccount(2202444, 2866),
				new SavingAccount(2202423, 4856),
				new SavingAccount(2202419, 1253),
				new SavingAccount(2202418, 1588),
			];

		}

		public void Start()
		{
			try
			{
				do
				{
					Console.Clear();
					Console.Write("Enter your Account Number: ");
					string? accountNumber = Console.ReadLine();
					if (accountNumber != null)
					{
						bool isParsed = int.TryParse(accountNumber, out int accountNumberValue);
						if (isParsed)
						{
							account = IsFound(accountNumberValue);
							if (account != null)
							{
								DisplayMainMenu(null);
								//DisplayMainMenu();
							}
							else
								InvalidErrorMessage($"Accoun Number {accountNumber} is not found!");
						}
						else
							InvalidErrorMessage("You entered invalid account number");

					}
					else

						InvalidErrorMessage("You entered invalid account number");
				}
				while (true);
			}
			catch (Exception e)
			{
				InvalidErrorMessage(e.Message);
			}
			finally { }
			
		}
		private void DisplayMainMenu(Account account)
		{

			ConsoleCommandUI c = new ConsoleCommandUI(
				[ 
					new Command(
						"DISPLAY YOUR BALANCE",textAlignment:Command.TextAlignment.CENTER),
					new Command(
						"WITHDRAW FROM BALANCE",textAlignment:Command.TextAlignment.CENTER) ,
					new Command(
						"DEPOSIT INTO BALANCE",textAlignment:Command.TextAlignment.CENTER) ,
					new Command("CLOSE MY ACCOUNT",textAlignment:Command.TextAlignment.CENTER,foregroundColor:ConsoleColor.Yellow,hightlightingColor:ConsoleColor.Red)
				],padding:2);
			c.CommandPressed += C_CommandPressed;
			c.ShowOnScreen();


			//string? key = null;
			//do
			//{
			//	Console.Clear();
			//	Console.WriteLine("1-Display Balance");
			//	Console.WriteLine("2-Withdraw");
			//	Console.WriteLine("3-Disposite");
			//	Console.WriteLine("4-End");

			//	key = Console.ReadLine();
			//	if (key != null)
			//	{
			//		bool keyParsed = int.TryParse(key, out int keyValue);
			//		if (keyParsed)
			//		{
			//			switch (keyValue)
			//			{
			//				case 1:
			//					Console.Clear();
			//					Console.WriteLine(account);
			//					StopWaitingPressingKey();
			//					break;
			//				case 2:
			//					Console.Clear();
			//					Console.Write("Enter the value you want to withdraw: ");
			//					string? widthdrawValue = Console.ReadLine();
			//					if (widthdrawValue != null)
			//					{
			//						bool parsedValue =
			//							double.TryParse(widthdrawValue, out double value);

			//						if (parsedValue)
			//						{
			//							bool isWithdrawed = account.Widthdraw(value);
			//							if (isWithdrawed)
			//							{
			//								SuccesfullMessage("Process done!");
			//								StopWaitingPressingKey();
			//							}
			//							else
			//							{
			//								InvalidErrorMessage("You do not have enough balance !");
			//							}
			//						}

			//						else
			//							InvalidErrorMessage("You enter incorrect value !");
			//					}
			//					else
			//						InvalidErrorMessage("You enter incorrect value !");
			//					break;
			//				case 3:

			//					Console.Clear();
			//					Console.Write("Enter the value you want to diposit:");
			//					string? dipositValue = Console.ReadLine();
			//					if (dipositValue != null)
			//					{
			//						bool parsedValue =
			//							double.TryParse(dipositValue, out double value);

			//						if (parsedValue)
			//						{
			//							bool isDiposited = account.Disposite(value);
			//							if (isDiposited)
			//							{
			//								SuccesfullMessage("Process done!");
			//								StopWaitingPressingKey();
			//							}
			//							else
			//							{
			//								InvalidErrorMessage("Try again !");
			//							}
			//						}
			//						else
			//							InvalidErrorMessage("You enter incorrect value !");
			//					}
			//					else
			//						InvalidErrorMessage("You enter incorrect value !");
			//					break;
			//			}
			//		}
			//		else
			//			InvalidErrorMessage("Enter valid key!");
			//	}
			//	else
			//		InvalidErrorMessage("Enter valid key!");
			//}
			//while (IsNotFinished(key, 4));
		}

		private void C_CommandPressed(ConsoleCommandUI source, ConsoleKey key, int commandIndex)
		{
			if (account == null) InvalidErrorMessage("The system has error");
			else
			{

				switch (commandIndex)
				{
					case 0:
						Console.Clear();
						Console.WriteLine(account);
						StopWaitingPressingKey();
						break;
					case 1:
						Console.Clear();
						Console.Write("Enter the value you want to withdraw: ");
						string? widthdrawValue = Console.ReadLine();
						if (widthdrawValue != null)
						{
							bool parsedValue =
								double.TryParse(widthdrawValue, out double value);

							if (parsedValue)
							{
								bool isWithdrawed = account.Withdraw(value);
								if (isWithdrawed)
								{
									SuccesfullMessage("Process done!");
									StopWaitingPressingKey();
								}
								else
								{
									InvalidErrorMessage("You do not have enough balance !");
								}
							}

							else
								InvalidErrorMessage("You enter incorrect value !");
						}
						else
							InvalidErrorMessage("You enter incorrect value !");
						break;
					case 2:

						Console.Clear();
						Console.Write("Enter the value you want to diposit:");
						string? dipositValue = Console.ReadLine();
						if (dipositValue != null)
						{
							bool parsedValue =
								double.TryParse(dipositValue, out double value);

							if (parsedValue)
							{
								bool isDiposited = account.Deposit(value);
								if (isDiposited)
								{
									SuccesfullMessage("Process done!");
									StopWaitingPressingKey();
								}
								else
								{
									InvalidErrorMessage("Try again !");
								}
							}
							else
								InvalidErrorMessage("You enter incorrect value !");
						}
						else
							InvalidErrorMessage("You enter incorrect value !");
						break;
					case 3:
						source.End = true;
						break;
				}
			}
		}

		private static void StopWaitingPressingKey()
		{
			Console.Write("________________________________________________________\n"); 
			Console.Write("Press any key to return: ");
			Console.ReadKey();
			Console.Clear();
		}

		private void SuccesfullMessage(string message)
		{
			Console.WriteLine(message);
		}

		private bool IsNotFinished(string? key, int ConditionKey)
		{
			return int.Parse(key) != ConditionKey;
		}

		private static void InvalidErrorMessage(String message)
		{
			Console.WriteLine(message);
			Thread.Sleep(WAITING_TIME);
			Console.Clear();
		}

		private Account? IsFound(int accountNumber)
		{
			foreach (var account in accounts)
			{
				if (account.Is(accountNumber))
				{
					return account;
				}
			}
			return null;
		}
	}
}
