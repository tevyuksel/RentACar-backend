using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarManagerTest1();
            //CarManagerTest2();
            //ColorManagerTest1();
            //UserManagerTest1();
            //CarManagerTest3();
        }

    //    private static void CarManagerTest3()
    //    {
                
    //        CarManager carManager = new CarManager(new EfCarDal());
    //        carManager.Add( new Car { CarId = 5, BrandId = 1, ColorId = 1, DailyPrice = 250, CarName = "Fiat", Description = "Açıklama", ModelYear = 2020 });

    //        var result = carManager.GetAll();
    //        if (result.Success == true)
    //        {
    //            foreach (var car in result.Data)
    //            {
    //                Console.WriteLine(car.CarName + " " + car.ModelYear + " model aracın günlük kiralama bedeli " + car.DailyPrice + " TL'dir.");
    //            }
    //        }
    //    }
        


    //    private static void UserManagerTest1()
    //    {

    //        UserManager userManager = new UserManager(new EfUserDal());
    //        userManager.Add(new User { UserId =50, FirstName = "Tevhid", LastName = "Yüksel", EMail = "tevyuksel@gmail.com", Password = "242400" });

    //        var result = userManager.GetAll();
    //        if (result.Success == true)
    //        {
    //            foreach (var user in result.Data)
    //            {
    //                Console.WriteLine(user.FirstName + " " + user.LastName + " hoşgeldin! ");
    //            }
    //        }
    //    }

    //    private static void ColorManagerTest1()
    //    {

    //        ColorManager colorManager = new ColorManager(new EfColorDal());
    //        var result = colorManager.GetAll();
    //        if (result.Success == true)
    //        {
    //            foreach (var color in result.Data)
    //            {
    //                Console.WriteLine(color.ColorId + "/" + color.ColorName);
    //            }
    //        }
    //    }

    //    private static void CarManagerTest1()
    //    {

    //        CarManager carManager = new CarManager(new EfCarDal());
    //        var result = carManager.GetAll();
    //        if (result.Success == true)
    //        {
    //            foreach (var car in result.Data)
    //            {
    //                Console.WriteLine(car.CarName + " " + car.ModelYear + " model aracın günlük kiralama bedeli " + car.DailyPrice + " TL'dir.");
    //            }
    //        }
    //    }
    //    private static void CarManagerTest2()
    //    {

    //        CarManager carManager = new CarManager(new EfCarDal());
    //        var result = carManager.GetProductDetails();
    //        if (result.Success == true)
    //        {
    //            foreach (var car in result.Data)
    //            {
    //                Console.WriteLine(car.CarName + " " + car.ColorName + " renk aracın günlük kiralama bedeli " + car.DailyPrice + " TL'dir.");
    //            }
    //        }
    //    }

    }
}
