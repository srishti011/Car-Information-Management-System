using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarApplication
{
    public class UserInterface
    {
        public static void Main(string[] args) {
            while (true) {
                Console.WriteLine("Options....");
                Console.WriteLine("1.Admin Window");
                Console.WriteLine("2.Customer Window");
                Console.WriteLine("3.Exit");
                int choice;
                try
                {
                    Console.WriteLine("enter Your Choice...");
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e) {
                    Console.WriteLine("Make a valid choice (only Numeric Values)");
                    choice = 100;
                }
                switch (choice) {

                    case 1:
                        Administrator ad = new Administrator();
                        ad.Run();
                        break;
                    case 2:
                        Customer c = new Customer();
                        c.Run();
                        break;
                    case 3:
                        break;
                
                }
                Console.WriteLine("enter x to exit application.\nenter any other key to restart Application.");
                string s = Console.ReadLine();
                if (s == "x") {
                    return;
                }
            
            }

        }
    }
}
