using MoqExamples.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoqExamples
{
    public class PaymentProcessor : IPaymentService
    {
        public IPaymentService PaymentService { get; set; }

		public PaymentProcessor(IPaymentService paymentService)
		{
			PaymentService = paymentService;
		}

		public string TrackPayment(int id)
        {
            return "";
        }

		public string GetPaymentStatus(int id)
		{
			throw new NotImplementedException();
		}
	}
}
