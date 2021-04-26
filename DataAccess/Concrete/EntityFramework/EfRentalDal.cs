using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetailsDto()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars 
                             on r.CarId equals c.Id
                             join cus in context.Customers 
                             on r.CustomerId equals cus.Id
                             join u in context.Users 
                             on cus.UserId equals u.Id
                             join b in context.Brands 
                             on c.BrandId equals b.BrandId

                             select new RentalDetailDto()
                             {
                                 RentalId = r.Id,
                                 Description = c.Descriptions,
                                 Brand = b.BrandName,
                                 ModelYear = c.ModelYear,
                                 CompanyName = cus.CompanyName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 CarId = c.Id,
                                 UserId = u.Id,
                             };
                return  result.ToList();
            }
        }
    }
}
