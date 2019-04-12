using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSearch
{
   public class Dealership
    {
        public string Make { get; set; }
        public string dealership { get; set; }

        public Dealership(string make, string dealerShip)
        {
            Make = make;
            dealership = dealerShip;
        }

        public static Dealership ParseFromFile(string line)
        {
            var columns = line.Split(',');

            return new Dealership
            {
                Make = columns[0],
                dealership = (columns[1])
            };
        }


        public Dealership()
        {

        }
        public override string ToString()
        {
            return $"{Make},{dealership}";
        }
    }
}
