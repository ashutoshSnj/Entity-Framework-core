using Inheritance_inEF;
using System;
    namespace inhirance
{
    public class mainapp
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("todays we start the inhiritance in Entity Framwork");
            /*   using (var context = new DBConnection())
               {

                   context.Employe.Add(new FullTimeEmployee("Ashutosh Shelke","Warje",1256336));
                   context.Employe.Add(new PartTimeEmployee("Miss Sayli", "Pune","will be Permanant"));

                   context.SaveChanges();

               } */
            /*   using (var cnn = new DBConnection2())
               {
                   cnn.Employes.Add(new FullTimeEmployee("Ashutosh Shelke", "Warje", 1256336));
                   cnn.Employes.Add(new PartTimeEmployee("Miss Sayli", "Pune", "will be Permanent"));

                   cnn.SaveChanges();
               } */
            using (var cnn = new DBConnection3())
            {
                cnn.FullTimeEmployees.Add(new FullTimeEmployee("Ashutosh Shelke", "Warje", 1256336));
                cnn.PartTimeEmployees.Add(new PartTimeEmployee("Miss Sayli", "Pune", "will be Permanent"));

                cnn.SaveChanges();
            }
        }
    }
}

