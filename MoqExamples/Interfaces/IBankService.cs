using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoqExamples.Interfaces
{
    public interface IBankService
    {
        decimal GetBalance(int id);

        bool CanWithdraw(int id, decimal balance);
    }
}
