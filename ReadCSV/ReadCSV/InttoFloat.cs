using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReadCSV
{
    class InttoFloat
    {
        public string Name { get; set; }
        public float Roll { get; set; }
        public float Marks { get; set; }
        public void readAndConvert(string path)
        {
            var lines = File.ReadAllLines(@path).Select(x => x.Split(',')).Skip(1);
            var CSV =
                from line in lines
                let elements = line.Skip(1)
                select (from i in elements
                        let x = Regex.Match(i, "^[0-9]*[.][0-9]*$").Success
                        where (x == false)
                        select (float.Parse(i))).ToList();
            //var results = CSV.ToList();
            IEnumerable<float> numberList = CSV.SelectMany(x => x);
            foreach(float result in numberList)
            {
                Console.WriteLine(result);
            }
            
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            InttoFloat ob = new InttoFloat();
            Console.Write("Enter the path of the CSV file : ");
            string path = Console.ReadLine();
            ob.readAndConvert(path);
        }
    }
}
