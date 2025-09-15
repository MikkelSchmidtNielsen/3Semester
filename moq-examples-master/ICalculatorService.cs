using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moq_examples
{
    // Define an interface for a basic service
        public interface ICalculatorService
        {
            int Add(int a, int b);
            int Multiply(int a, int b);
        }
    
}
