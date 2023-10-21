using System.Collections.Generic;
using System.Linq;
using online_shop_backend.Models.Entities;
using online_shop_backend.Repositories.Interfaces;

namespace online_shop_backend.tests.Mocks
{
    public class SamplePaymentTypeRepository : IPaymentTypeRepository
    {
        public SamplePaymentTypeRepository()
        {
            PaymentTypes = new List<PaymentType>
            {
                new PaymentType
                {
                    Id = 1,
                    Name = "PaymentType1"
                }
            };
        }

        private ICollection<PaymentType> PaymentTypes { get; }

        public void AddPaymentType(PaymentType paymentType)
        {
            PaymentTypes.Add(paymentType);
        }

        public void RemovePaymentType(PaymentType paymentType)
        {
            PaymentTypes.Remove(paymentType);
        }

        public void UpdatePaymentType(PaymentType paymentType)
        {
            PaymentTypes.Remove(PaymentTypes.First(pt => pt.Id == paymentType.Id));
        }

        public PaymentType GetPaymentType(int id)
        {
            return PaymentTypes.First(pt => pt.Id == id);
        }

        public ICollection<PaymentType> GetAllPaymentTypes()
        {
            return PaymentTypes;
        }
    }
}