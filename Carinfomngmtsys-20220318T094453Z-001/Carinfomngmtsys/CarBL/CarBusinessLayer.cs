using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDL;
using CarEntity;

namespace CarBL
{
    public class CarBusineesLayer
    {
        static CarDataLayer dao=new CarDataLayer();
        public List<Car> ShowCarBal() {
            return dao.ShowCar();
        }
        public string AddCarBal(Car c) {
            int id = dao.AddCar(c);
            if (id != -1)
            {
                return "Car Added with CarId " + id.ToString();
            }
            else {
                return "Unable to add Car" + "\ncheck the details correctly";
            }
        }
        public string UpdateCarBal(Car c) {
            return dao.UpdateCar(c);
        }
        public string RemoveCarBal(string model) { 
            return dao.DeleteCar(model);
        }
        public Car SearchCarBal(string model) {
            return dao.SearchCar(model);
        }
    }
}
