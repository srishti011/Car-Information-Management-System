using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CarBL;
using CarEntity;

namespace CarApplication
{
    public class Administrator
    {
        static CarBusineesLayer bao = new CarBusineesLayer();
        public static int Login()
        {
            SqlConnection connection;
            SqlCommand command;
            connection = ConnectionHelper.GetConnection();
            connection.Open();
            Console.WriteLine("Enter Username: ");
            string un = Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            string ps = Console.ReadLine();
            command = new SqlCommand("prcCred", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@un", un);
            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                string pass = dr["password_"].ToString();
                if (pass == ps)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            connection.Close();
            command.Dispose();
            return 0;
        }
        public static void AddCar() { 
            Car c = new Car();
            Console.WriteLine("enter manufacturer name");
            c.ManufacturerName = Console.ReadLine();
            Console.WriteLine("enter model name");
            c.Model = Console.ReadLine();
            Console.WriteLine("enter Car Type: Hatchback||Sedan||SUV : ");
            c.Type = Console.ReadLine();
            while (c.Type != "Hatchback" && c.Type != "Sedan" && c.Type != "SUV")
            {
                Console.WriteLine("enter Car Type: Hatchback||Sedan||SUV : ");
                c.Type = Console.ReadLine();
            }
            Console.WriteLine("enter Engine Name");
            c.Engine = Console.ReadLine();
            Console.WriteLine("enter BHP value");
            c.BHP = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Transmission Type");
            c.Transmission = Console.ReadLine();
            while (c.Transmission != "Automatic" && c.Transmission != "Manual" )
            {
                Console.WriteLine("enter Car Type: Automatic||Manual : ");
                c.Transmission = Console.ReadLine();
            }
            Console.WriteLine("Enter Mileage");
            c.Mileage = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Total number of Seats");
            c.Seat = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Does Car have Air Bag Facility");
            c.AirBagDetails = Console.ReadLine();
            Console.WriteLine("Enter BootSpace");
            c.BootSpace = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Car Cost");
            c.Price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(bao.AddCarBal(c));
        }
        public static void UpdateCar() {
            Car c = new Car();
            Console.WriteLine("enter model name");
            c.Model = Console.ReadLine();
            Car old = bao.SearchCarBal(c.Model);
            if (old != null)
            {
                Console.WriteLine("Old features are");
                Console.WriteLine(old);
                Console.WriteLine("Rewrite the Features: ");
                Console.WriteLine("enter Engine Name");
                c.Engine = Console.ReadLine();
                Console.WriteLine("enter BHP value");
                c.BHP = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Mileage");
                c.Mileage = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Total number of Seats");
                c.Seat = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Does Car have Air Bag Facility");
                c.AirBagDetails = Console.ReadLine();
                Console.WriteLine("Enter BootSpace");
                c.BootSpace = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Car Cost");
                c.Price = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(bao.UpdateCarBal(c));
            }
            else {
                Console.WriteLine("Car Model Not Available to Update");
            }
        }
        public static void RemoveCar() {
            Console.WriteLine("Enter Model name to remove: ");
            string m = Console.ReadLine();
            Console.WriteLine(bao.RemoveCarBal(m));
        }
        public static void SearchCar() {
            Console.WriteLine("Enter Model name to Search Car : ");
            string m = Console.ReadLine();
            Console.WriteLine(bao.SearchCarBal(m));
        }
        public static void ShowCar() {
            List<Car> cList = null;
            cList = bao.ShowCarBal();
            Console.WriteLine("Model" + "___" + "ManufacturerName" + "___" + "Type" + "___" + "Price");
            foreach (Car cr in cList)
            {
                Console.WriteLine(cr.Model+"   "+cr.ManufacturerName+"   "+cr.Type+"   "+cr.Price);
            }
        }
        public  void Run() {
            while (true) {
                int success = Login();
                if (success == 1)
                {
                    int choice;
                    do
                    {
                        Console.WriteLine("_______________________________________________________");
                        Console.WriteLine("Options.....");
                        Console.WriteLine("1.Add New Car");
                        Console.WriteLine("2.Update Car");
                        Console.WriteLine("3.Remove Car");
                        Console.WriteLine("4.Search Car");
                        Console.WriteLine("5.Show Available Cars");
                        Console.WriteLine("6.Exit");
                        try
                        {
                            choice = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception ex) {
                            choice = 100;
                            Console.WriteLine("Expected a numerical Value");
                        }
                        Console.WriteLine("_______________________________________________________");
                        switch (choice)
                        {
                            case 1:
                                AddCar();
                                break;
                            case 2:
                                UpdateCar();
                                break;
                            case 3:
                                RemoveCar();
                                break;
                            case 4:
                                SearchCar();
                                break;
                            case 5:
                                ShowCar();
                                break;
                            case 6:
                                break;
                            default:
                                Console.WriteLine("Please make a valid chooice...");
                                break;
                        }
                    } while (choice != 6);
                }
                else {
                    Console.WriteLine("Login UnSuccessful");
                }
                Console.WriteLine("enter x to exit\npress any key to relogin");
                if ("x" == Console.ReadLine()) {
                    break;
                }
            }   
        }

    }
}
