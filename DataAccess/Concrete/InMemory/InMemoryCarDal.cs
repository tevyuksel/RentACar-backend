using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    //public class InMemoryCarDal : ICarDal
    //{
    //    List<Car> _car;
    //    public InMemoryCarDal()
    //    {
    //        _car = new List<Car>
    //        {
    //            new Car{CarId=1, BrandId=1, ColorId=1, DailyPrice=250, Description="Açıklama", ModelYear=2020},
    //            new Car{CarId=2, BrandId=1, ColorId=2, DailyPrice=350, Description="Açıklama", ModelYear=2019},
    //            new Car{CarId=3, BrandId=2, ColorId=2, DailyPrice=400, Description="Açıklama", ModelYear=2020},
    //            new Car{CarId=4, BrandId=2, ColorId=3, DailyPrice=200, Description="Açıklama", ModelYear=2018},
    //            new Car{CarId=5, BrandId=3, ColorId=4, DailyPrice=550, Description="Açıklama", ModelYear=2021},

    //        };

    //    }

    //    public void Add(Car car)
    //    {
    //        _car.Add(car);
    //    }

    //    public void Delete(Car car)
    //    {
    //        Car carToDelete = _car.SingleOrDefault(c => c.CarId == car.CarId);
    //        _car.Remove(carToDelete);
    //    }

    //    public Car Get(Expression<Func<Car, bool>> filter)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public List<Car> GetAll()
    //    {
    //        return _car;
    //    }

    //    public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public List<Car> GetAllByBrand(int brandId)
    //    {
    //        return _car.Where(c => c.BrandId == brandId).ToList();
    //    }

    //    public List<CarDetailDto> GetCarDetails()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public List<CarDetailDto> GetCarDetailsDto()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Update(Car car)
    //    {
    //        Car carToUpdate = _car.SingleOrDefault(c => c.CarId == car.CarId);
    //        carToUpdate.BrandId = car.BrandId;
    //        carToUpdate.ColorId = car.ColorId;
    //        carToUpdate.ModelYear = car.ModelYear;
    //        carToUpdate.DailyPrice = car.DailyPrice;
    //        carToUpdate.Description = car.Description;
    //    }
    //}
}
