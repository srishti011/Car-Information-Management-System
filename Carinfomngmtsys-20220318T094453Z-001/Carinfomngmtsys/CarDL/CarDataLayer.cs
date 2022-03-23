using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CarEntity;

namespace CarDL
{
    public class CarDataLayer
    {
        SqlConnection connection;
        SqlCommand command;
       
        public List<Car> ShowCar()
        {
            connection = ConnectionHelper.GetConnection();
            connection.Open();
            List<Car> carList = new List<Car>();
            Car car = null;
            command = new SqlCommand("prcShowCar", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                car = new Car();
                car.Id = Convert.ToInt32(dr["ID"]);
                car.Model = dr["Model"].ToString();
                car.ManufacturerName = dr["Manufacturer"].ToString();
                car.Engine = dr["Engine"].ToString();
                car.BHP = Convert.ToInt32(dr["BHP"]);
                car.Type= dr["Type"].ToString();
                car.Transmission= dr["Transmission"].ToString();
                car.Mileage = Convert.ToInt32(dr["Mileage"]);
                car.Seat = Convert.ToInt32(dr["Seat"]);
                car.AirBagDetails = dr["AirBagDetails"].ToString();
                car.BootSpace = Convert.ToInt32(dr["BootSpace"]);
                car.Price = Convert.ToInt32(dr["Price"]);
                carList.Add(car);
            }
            connection.Close();
            command.Dispose();
            return carList;
        }

        public int AddCar(Car car)
        {
            connection = ConnectionHelper.GetConnection();
            connection.Open();
            command = new SqlCommand("prcAddCar", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int));
            command.Parameters["@ID"].Direction = ParameterDirection.Output;
            command.Parameters.AddWithValue("@Manufacturername", car.ManufacturerName);
            command.Parameters.AddWithValue("@Model",car.Model);
            command.Parameters.AddWithValue("@Type",car.Type);
            command.Parameters.AddWithValue("@Engine",car.Engine);
            command.Parameters.AddWithValue("@BHP", car.BHP);
            command.Parameters.AddWithValue("@Transmission", car.Transmission);
            command.Parameters.AddWithValue("@Mileage", car.Mileage);
            command.Parameters.AddWithValue("@Seats", car.Seat);
            command.Parameters.AddWithValue("@AirBagDetails", car.AirBagDetails);
            command.Parameters.AddWithValue("@Bootspace", car.BootSpace);
            command.Parameters.AddWithValue("@Price", car.Price);
            int id;
            try
            {
                command.ExecuteNonQuery();
                id = Convert.ToInt32(command.Parameters["@ID"].Value);
            }
            catch (Exception ex) {
                id = -1;
            }
            return id;
        }
        
        public string UpdateCar(Car car)
        {
            CarDataLayer dao = new CarDataLayer();
            connection = ConnectionHelper.GetConnection();
            connection.Open();
            command = new SqlCommand("prcUpdateCar", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Model", car.Model);
            command.Parameters.AddWithValue("@Engine", car.Engine);
            command.Parameters.AddWithValue("@BHP", car.BHP);
            command.Parameters.AddWithValue("@Mileage", car.Mileage);
            command.Parameters.AddWithValue("@Seats", car.Seat);
            command.Parameters.AddWithValue("@AirBagDetails", car.AirBagDetails);
            command.Parameters.AddWithValue("@Bootspace", car.BootSpace);
            command.Parameters.AddWithValue("@Price", car.Price);
            if (dao.SearchCar(car.Model) == null)
            {
                return "Record not found";
            }
            command.ExecuteNonQuery();
            return "Record Updated";
        }

        public string DeleteCar(string model)
        {
            connection = ConnectionHelper.GetConnection();
            connection.Open();
            CarDataLayer dao = new CarDataLayer();
            if (dao.SearchCar(model) == null)
            {
                return "Record not found";
            }
            Console.WriteLine("Enter y to continue deletion");
            string s =Console.ReadLine();
            if (s == "y")
            {
                command = new SqlCommand("prcRemoveCar", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Model", model);
                command.ExecuteNonQuery();
                return "Record Deleted";
            }
            else {
                return "Record not Deleted";
            }
            
        }
        
        public Car SearchCar(string model)
        {
            connection = ConnectionHelper.GetConnection();
            connection.Open();
            Car car = null;
            command = new SqlCommand("prcSearchCar", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Model", model);
             SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {

                car = new Car();
                car.Id = Convert.ToInt32(dr["ID"]);
                car.Model = dr["model"].ToString();
                car.ManufacturerName = dr["Manufacturer"].ToString();
                car.Seat = Convert.ToInt32(dr["Seat"]);
                car.Type = dr["type"].ToString();
                car.Transmission = dr["Transmission"].ToString();
                car.AirBagDetails = dr["AirBagDetails"].ToString();
                car.Price = Convert.ToInt32(dr["Price"]);
                car.Mileage = Convert.ToInt32(dr["Mileage"]);
                car.BHP = Convert.ToInt32(dr["BHP"]);
                car.Engine = dr["Engine"].ToString();
                car.BootSpace= Convert.ToInt32(dr["BootSpace"]);
              
                
            }
            connection.Close();
            command.Dispose();
            return car;
        }


    }
}
