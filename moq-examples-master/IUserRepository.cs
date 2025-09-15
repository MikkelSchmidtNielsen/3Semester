using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moq_examples
{
    public interface IUserRepository
    {
        string GetUserRole(int userId);
    }
}
