using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace StoreStudentDetails
{
    class StoreStudDetails
    {
        static void Main(string[] args)
        {
            string[] studFile = File.ReadAllLines(@"F:\Linq Assignment\StoreStudentDetails\StoreStudentDetails\StudDetails.csv");
            string[] studFeeFile = File.ReadAllLines(@"F:\Linq Assignment\StoreStudentDetails\StoreStudentDetails\StudFeesDetails.csv");
            studFile = studFile.Skip(1).ToArray();
            studFeeFile = studFeeFile.Skip(1).ToArray();
            IEnumerable<string> query1 =
                from studFee in studFeeFile
                let feeFields = studFee.Split(',')
                from stud in studFile
                let studFields = stud.Split(',')
                where Convert.ToInt32(feeFields[0]) == Convert.ToInt32(studFields[0]) && Convert.ToInt32(feeFields[2]) != 0
                select (studFields[0] + "," + studFields[1] + " " + studFields[2]);
            Console.WriteLine("List of Students who paid the fees : ");
            foreach(string str in query1)
            {
                Console.WriteLine(str);
            }
            IEnumerable<string> query2 =
                from studFee in studFeeFile
                let FeeFields = studFee.Split(',')
                from stud in studFile
                let studFields = stud.Split(',')
                where Convert.ToInt32(FeeFields[0]) == Convert.ToInt32(studFields[0]) && Convert.ToInt32(FeeFields[2]) == 0
                select (studFields[0] + "," + studFields[1] + " " + studFields[2] + "," + (Convert.ToInt32(FeeFields[1])+100).ToString() +
                "," + studFields[5] + "," + studFields[8]);
            var csvList = new List<string>();
            csvList.Add("Student Id,Student Name,New Amount to Pay,Father's Mobile Number,Mother's Mobile Number");
            csvList.AddRange(query2);
            string outputPath = @"F:\Linq Assignment\StoreStudentDetails\StoreStudentDetails\NewStudentFeeDetails.csv";
            File.WriteAllLines(outputPath, csvList);
            Console.ReadKey();
        }
    }
}
