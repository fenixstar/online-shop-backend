using System.Collections.Generic;
using System.Linq;
using online_shop_backend.Models.Entities;
using online_shop_backend.Repositories.Interfaces;

namespace online_shop_backend.tests.Mocks
{
    public class SampleProducerRepository : IProducerRepository
    {
        public SampleProducerRepository()
        {
            Producers = new List<Producer>
            {
                new Producer
                {
                    Id = 1,
                    Name = "Producer1",
                    Details = new List<ProducerDetail>
                    {
                        new ProducerDetail
                        {
                            Id = 1,
                            ProducerId = 1,
                            Address1 = "QWERTY",
                            Address2 = "ASDF",
                            City = "ZXCV",
                            Country = "JKL",
                            Email = "QWERTY@email.com",
                            PhoneNumber = "1234567890"
                        }
                    }
                },
                new Producer
                {
                    Id = 2,
                    Name = "Producer2",
                    Details = new List<ProducerDetail>
                    {
                        new ProducerDetail
                        {
                            Id = 2,
                            ProducerId = 2,
                            Address1 = "UIOP",
                            Address2 = "BNM",
                            City = "TYU",
                            Country = "ZXCBNM",
                            Email = "ASDFG@email.com",
                            PhoneNumber = "0987654321"
                        }
                    }
                }
            };
        }

        private ICollection<Producer> Producers { get; }

        public void AddProducer(Producer producer)
        {
            Producers.Add(producer);
        }

        public void RemoveProducer(Producer producer)
        {
            Producers.Remove(producer);
        }

        public void UpdateProducer(Producer producer)
        {
            Producers.Remove(Producers.First(p => p.Id == producer.Id));
            Producers.Add(producer);
        }

        public Producer GetProducer(int id)
        {
            return Producers.First(p => p.Id == id);
        }

        public ICollection<Producer> GetAllProducers()
        {
            return Producers;
        }

        public ICollection<ProducerDetail> GetDetailsForProducer(int id)
        {
            return Producers.First(p => p.Id == id)?.Details;
        }
    }
}