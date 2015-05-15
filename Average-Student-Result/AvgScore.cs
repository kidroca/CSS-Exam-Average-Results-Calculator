using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class AvgScore
{
    static void Main(string[] args)
    {

        /* Gettting all the data in an array */
        Console.WriteLine("Enter path to the file, e.g. C:\\Folder\\results.csv ");
        var results = System.IO.File.ReadAllText(Console.ReadLine())
            .Split(',', '\n');

        int[] dataArray = new int[results.Length]; // Array for all the numbers

        for (int i = 0; i < results.Length; i++)
        {
            int.TryParse(results[i], out dataArray[i]); // Parsing the numbers in there
        }

        int studentsCount = 0;
        int avgScore = 0;
        int excelScores = 0;
        int[] grades = new int[dataArray.Length / 2]; // Extracting only the grades here

        /* Get every odd index, skip the first two as they are words. */
        for (int i = 3, j = 0; i < dataArray.Length; i += 2, j++)
        {   
            studentsCount++;
            grades[j] = dataArray[i]; // Getting the grades in a separate list 
            avgScore += grades[j]; // Sum of all grades

            if (grades[j] == 100)
            {
                excelScores++;  // Counting how many excellent grades are there 
            }
        }

        Array.Sort(grades); // Sorting the grades to find the best 25%

        Console.WriteLine();
        Console.WriteLine("Students = " + studentsCount);
        Console.WriteLine("Average Result = {0}", avgScore / studentsCount);
        Console.WriteLine("Top 25% are above " + grades[grades.Length - grades.Length / 4]);
        Console.WriteLine("There are {0} excellent results", excelScores);
        Console.WriteLine();

        // Keep the console window open in debug mode.
        Console.WriteLine("Press any key to exit.");
        System.Console.ReadKey();
    }
}
