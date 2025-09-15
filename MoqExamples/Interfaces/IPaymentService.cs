using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoqExamples.Interfaces
{
    public interface IPaymentService
    {
        string GetPaymentStatus(int id);
    }
}
