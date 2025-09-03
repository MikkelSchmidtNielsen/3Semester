using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversionOfControlAssignment.Interfaces
{
    public interface IEmailSender
    {
        void Send(string message);
    }
}
