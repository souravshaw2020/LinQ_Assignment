using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BusDriverDetails
{
    class StoreBusDetails
    {
        static void Main(string[] args)
        {
            string[] studFile = File.ReadAllLines(@"F:\Linq Assignment\BusDriverDetails\BusDriverDetails\StudDetails.csv");
            string[] studFeeFile = File.ReadAllLines(@"F:\Linq Assignment\BusDriverDetails\BusDriverDetails\StudFeesDetails.csv");
            string[] driverFile = File.ReadAllLines(@"F:\Linq Assignment\BusDriverDetails\BusDriverDetails\BusDriverDetails.csv");
            studFile = studFile.Skip(1).ToArray();
            studFeeFile = studFeeFile.Skip(1).ToArray();
            driverFile = driverFile.Skip(1).ToArray();
            IEnumerable<string> query1 =
                from studFee in studFeeFile
                let feeFields = studFee.Split(',')
                from stud in studFile
                let studFields = stud.Split(',')
                where Convert.ToInt32(feeFields[0]) == Convert.ToInt32(studFields[0])
                select (studFields[0] + "," + studFields[1] + " " + studFields[2] + "," + feeFields[5] + "," + feeFields[6]);
            IEnumerable<string> query2 =
                from studDetails in query1
                let studFields = studDetails.Split(',')
                from driverDetails in driverFile
                let driverFields = driverDetails.Split(',')
                where Convert.ToInt32(studFields[3]) == Convert.ToInt32(driverFields[0]) && studFields[1] == "Sathya Sri"
                select (driverFields[3]);
            Console.WriteLine("Contact Number of Bus Driver Who Pick Up Sathya Sri ---");
            foreach(string contact in query2)
            {
                Console.WriteLine(contact);
            }
            Console.ReadKey();
        }
    }
}
