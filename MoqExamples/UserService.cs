using MoqExamples.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoqExamples
{
	public class UserService : ILogger
	{
		public ILogger _logger;

		public UserService(ILogger logger)
		{
			_logger = logger;
		}

		public void LogMessage(string message)
		{
			throw new NotImplementedException();
		}

		public void PerformAction(string username, string message)
		{

		}
	}
}
