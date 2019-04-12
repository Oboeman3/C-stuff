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
        public string DealerShip { get; set; }

        public Dealership(string make, string dealerShip)
        {
            Make = make;
            DealerShip = dealerShip;
        }

        public static Dealership ParseFromFile(string line)
        {
            var columns = line.Split(',');

            return new Dealership
            {
                Make = columns[0],
                DealerShip = (columns[1])
            };
        }


        public Dealership()
        {

        }
        public override string ToString()
        {
            return $"{Make},{DealerShip}";
        }
    }
}
