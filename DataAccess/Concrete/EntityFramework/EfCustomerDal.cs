using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentACarContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetailsDto()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from cus in context.Customers
                             join u in context.Users 
                             on cus.UserId equals u.Id

                             select new CustomerDetailDto()
                             {
                                 UserId = cus.UserId,
                                 FirstName = cus.CompanyName,
                                 LastName = u.FirstName,
                                 Email = u.LastName,
                                 CompanyName = u.Email                               
                             };
                return result.ToList();
            }
        }
    }
}
