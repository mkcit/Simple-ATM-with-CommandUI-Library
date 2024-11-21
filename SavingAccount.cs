namespace ATM
{
	internal class SavingAccount : Account
	{
		private const float RATE = 0.05f;
		private double Commission { get; set; }
		public SavingAccount(int accountNumber, double balance)
		{
			AccountNumber = accountNumber;	
			Balance = balance;
			Commission = RATE * Balance;
			Balance -= Commission;
		}

		public override string ToString()
		{
			return
				$"{"Opening Commission".PadRight(GAP, ' ')}: {Commission.ToString("0.00$")}\n" +
				base.ToString();
		}
	}
}
