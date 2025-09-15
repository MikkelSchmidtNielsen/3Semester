using MoqExamples.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoqExamples
{
    public class AccountManager : IBankService
    {
        public IBankService _bankService;

		public AccountManager(IBankService bankService)
		{
			_bankService = bankService;
		}

		public bool CanWithdraw(int id, decimal balance)
		{
			return true;
		}

		public decimal GetBalance(int id)
		{
			return 0;
		}
	}
}
