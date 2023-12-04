using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace ConAppAssignment26
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**** Binary Conversion ****");
            Employee employee = new Employee()
            {
                ID = 1,
                FirstName = "Naveen",
                LastName = "Galla",
                Salary = 90000.90
            };
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@"C:\Mphasis\Day-21\Assignment\ConAppAssignment26\ConAppAssignment26\Employee.txt",
            FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, employee);
            stream.Close();

            stream = new FileStream(@"C:\Mphasis\Day-21\Assignment\ConAppAssignment26\ConAppAssignment26\Employee.txt",
            FileMode.Open, FileAccess.Read);

            Employee employeenew = (Employee)formatter.Deserialize(stream);

            Console.WriteLine(employeenew.ID);
            Console.WriteLine(employeenew.FirstName);
            Console.WriteLine(employeenew.LastName);
            Console.WriteLine(employeenew.Salary);

            Console.WriteLine("**** XML Conversion ****");
            XmlSerializer serializer = new XmlSerializer(typeof(Employee));
            using (TextWriter writer = new StreamWriter("Employee.xml"))
            {
                serializer.Serialize(writer, employee);
            }

            //Deserialize the Object from Xml

            using (TextReader reader = new StreamReader("Employee.xml"))
            {
                Employee deserializedPerson = (Employee)serializer.Deserialize(reader);
                Console.WriteLine($"ID        : {deserializedPerson.ID}  \nFirstName : {deserializedPerson.FirstName} \nLastName  : {deserializedPerson.LastName} \nSalary    : {deserializedPerson.Salary}");
            }

            Console.ReadKey();
        }
    }
}
