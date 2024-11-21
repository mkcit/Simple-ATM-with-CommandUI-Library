namespace ATM
{
	internal class Account
	{
		protected const int GAP = 18;
		public int AccountNumber { get; set; }
		protected double Balance { get; set; }
		public  bool Deposit(double value)
		{
			if (IsAccepted(value))
			{
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine($"Open Balance".PadRight(GAP, ' ') + $":{Balance.ToString("0.00")}$");
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine($"+Deposit".PadRight(GAP, ' ') + $":{value}$");
				Balance += value;
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine($"Closed Balance".PadRight(GAP, ' ') + $":{Balance.ToString("0.00")}$");
				return true;
			}
			return false;
		}

		private bool IsAccepted(double value)
		{
			return value>0;
		}

		public virtual bool Withdraw(double value)
		{
			//Console.WriteLine($"Transaction Type: {nameof(Widthdraw)}\t-{value}");
			if (CheckBalance(value))
			{
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine($"Open Balance".PadRight(GAP, ' ') + $":{Balance.ToString("0.00")}$");
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine($"-Withdrawn".PadRight(GAP, ' ') + $":{value.ToString("0.00")}$");
				Balance -= value;
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine($"Closed Balance".PadRight(GAP, ' ') + $":{Balance.ToString("0.00")}$");

				return true;
			}
			return false;
		}

		public void DisplayBalance()
		{
			Console.WriteLine(this);
		}

		private bool CheckBalance(double value)
		{
			return Balance >= value;
			//throw new NotImplementedException();
		}

		public override string ToString()
		{
			return $"Account Number".PadRight(GAP, ' ') + $": {AccountNumber}\n" +
				"Blance".PadRight(GAP, ' ') + $": {Balance.ToString("0.00")}$";
		}

		internal bool Is(int accountNumber)
		{
			return accountNumber == AccountNumber;
		}
	}
}
