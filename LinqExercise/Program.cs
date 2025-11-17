using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            Console.WriteLine(numbers.Sum());

            //TODO: Print the Average of numbers
            Console.WriteLine(numbers.Average());

            //TODO: Order numbers in ascending order and print to the console
            int[] numbersAscend = numbers.OrderBy(n => n).ToArray();
            Array.ForEach(numbersAscend, n => Console.WriteLine(n));

            //TODO: Order numbers in descending order and print to the console
            int[] numbersDescend = numbers.OrderByDescending(n => n).ToArray();
            Array.ForEach(numbersDescend, n => Console.WriteLine(n));

            //TODO: Print to the console only the numbers greater than 6
            int[] numbersGreaterThanSix = numbers.Where(n => n > 6).ToArray();
            Array.ForEach(numbersGreaterThanSix, n => Console.WriteLine(n));

            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**
            foreach (int n in numbersAscend.Take(4))
            {
                Console.WriteLine(n);
            }

            // foreach (int n in numbersDescend.Take(4))
            // {
            //     Console.WriteLine(n);
            // }

            //TODO: Change the value at index 4 to your age, then print the numbers in descending order
            int[] ageIndexFour = numbers.Select((n, index) => index == 4 ? 35 : n).ToArray();
            int[] ageIndexFourDescend = ageIndexFour.OrderByDescending(n => n).ToArray();
            Array.ForEach(ageIndexFourDescend, n => Console.WriteLine(n));

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            IEnumerable<Employee> employeesCS = employees.Where(e =>
                e.FirstName.StartsWith('C') || e.FirstName.StartsWith('S')).OrderBy(e => e.FirstName);
            employeesCS.ToList().ForEach(e => Console.WriteLine($"{e.FullName}"));

            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            IEnumerable<Employee> employees26 =
                employees.Where(e => e.Age > 26).OrderBy(e => e.Age).ThenBy(e => e.FirstName);
            employees26.ToList().ForEach(e => Console.WriteLine($"{e.FullName} Age: {e.Age}"));

            //TODO: Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            IEnumerable<Employee> employeesYears35 = employees.Where(e => e.YearsOfExperience <= 10 && e.Age > 35);
            Console.WriteLine(employeesYears35.Sum(e => e.YearsOfExperience));

            //TODO: Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            Console.WriteLine(employeesYears35.Average(e => e.YearsOfExperience));

            //TODO: Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee { FirstName = "Alan", LastName = "Turing", Age = 113, YearsOfExperience = 87 }).ToList();
            // employees.ToList().ForEach(e => Console.WriteLine($"{e.LastName}, {e.FirstName} Age: {e.Age} Experience YTD: {e.YearsOfExperience}"));

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
