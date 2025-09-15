using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoqExamples.Interfaces
{
    public interface IUserRepository
    {
		string GetUserRole(int userId);
	}
}
