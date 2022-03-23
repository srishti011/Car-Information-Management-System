using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBL;
using CarEntity;

namespace CarApplication
{
    public class Customer
    {
        static CarBusineesLayer bao = new CarBusineesLayer();
        public static void ShowCar()
        {
            List<Car> cList = null;
            cList = bao.ShowCarBal();
            Console.WriteLine("Model" + "___" + "ManufacturerName" + "___" + "Type" + "___" + "Price");
            foreach (Car cr in cList)
            {
                Console.WriteLine(cr.Model + "   " + cr.ManufacturerName + "   " + cr.Type + "   " + cr.Price);
            }
        }
        public static void SearchCar()
        {
            Console.WriteLine("Enter Model name to Search Car : ");
            string m = Console.ReadLine();
            Console.WriteLine(bao.SearchCarBal(m));
        }

        public void Run()
        {
            while (true)
            {
                    int choice;
                    do
                    {
                        Console.WriteLine("_______________________________________________________");
                        Console.WriteLine("Options.....");
                        Console.WriteLine("1.Show Available Cars");
                        Console.WriteLine("2.Search Car");
                        Console.WriteLine("3.Exit");
                        try
                        {
                            choice = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception ex)
                        {
                            choice = 100;
                            Console.WriteLine("Expected a numerical Value");
                        }
                        Console.WriteLine("_______________________________________________________");
                        switch (choice)
                        {
                            case 1:
                                ShowCar();
                                break;
                            case 2:
                                SearchCar();
                                break;
                            case 3:
                                break;
                            default:
                                Console.WriteLine("Please make a valid chooice...");
                                break;
                        }
                    } while (choice != 3);
                
                Console.WriteLine("enter x to exit from the customer Window");
                if ("x" == Console.ReadLine())
                {
                    break;
                }
            }
        }

    }
}
