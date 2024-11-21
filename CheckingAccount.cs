namespace ATM
{
	internal class CheckingAccount : Account
	{
		private const float WIDTHDRAW_RATE = 0.1F;
		public CheckingAccount(int accountNumber, double balance)
		{
			AccountNumber = accountNumber;
			Balance = balance;
		}


		public override bool Withdraw(double value)
		{
			return (base.Withdraw((value + (value * WIDTHDRAW_RATE))));
		}

		public override string ToString()
		{
			return
				base.ToString();
		}
	}
}
