using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSearch
{
    public class Car
    {
        public string Model { get; set; }
        public string Make { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }
        public string Tranmission { get; set; }
        public string Engine { get; set; }
        public int MilePerGal { get; set; }
        public string Type { get; set; }
        public string BodyType { get; set; }
        public string Drivetrain { get; set; }

        public Car(string model, string make, int year, int price, string tranmission, string engine, string milePerGal, string type, string bodyType ,string drivetrain)
        {
            Model = model;
            Make = make;
            Year = year;
            Price = price;
            Tranmission = tranmission;
            Engine = engine;
            MilePerGal = int.Parse(milePerGal);
            Type = type;
            BodyType = bodyType;
            Drivetrain = drivetrain;
        }

        public static Car ParseFromFile(string line)
        {
            var columns = line.Split(',');

            return new Car
            {
                Year = int.Parse(columns[0]),
                Make = columns[1],
                Model = columns[2],
                Price = int.Parse(columns[3]),
                Tranmission = columns[4],
                Engine = (columns[5]),
                MilePerGal = int.Parse(columns[6]),
                Type = (columns[7]),
                BodyType = (columns[8]),
                Drivetrain = (columns[9])
            };
        }


        public Car()
        {

        }
        public override string ToString()
        {
            return $"{Year}, {Model}, {Make}";
        }
    }


}
