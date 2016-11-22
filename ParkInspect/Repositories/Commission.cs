using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkInspect.Repositories
{
    public class Commission
    {
        public int Id { get; set; }

        public int Frequency { get; set; }

        public int CustomerId { get; set; }

        public Commission(int id, int frequency, int customerId)
        {
            Id = id;
            Frequency = frequency;
            CustomerId = customerId;
        }

        public Commission()
        {

        }
    }
}
