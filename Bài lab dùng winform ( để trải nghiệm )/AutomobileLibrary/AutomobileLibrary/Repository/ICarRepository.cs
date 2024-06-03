using System.Collections;
using System.Collections.Generic;
using AutomobileLibrary.BussinessObject;

namespace AutomobileLibrary.Repository
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetCars();
        Car GetCarByID(int carId);
        void DeleteCar(int carId);
        void InsertCar(Car car);
        void UpdateCar(Car car);
    }
}
