using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    [ValidationAspect(typeof(CustomerValidator))]
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _custormerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _custormerDal = customerDal;
        }

        [SecuredOperation("admin")]
        public IResult Add(Customer customer)
        {
            _custormerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        [SecuredOperation("admin")]
        public IResult Delete(Customer customer)
        {
            _custormerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_custormerDal.GetAll(), Messages.CustomersListed);
        }

        [CacheAspect]
        public IDataResult<Customer> GetById(int customerId)
        {
            return new SuccessDataResult<Customer>(_custormerDal.Get(cus => cus.Id == customerId));
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetailsDto()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_custormerDal.GetCustomerDetailsDto());
        }

        [CacheAspect]
        public IDataResult<List<Customer>> GetCustomersByUserId(int id)
        {
            return new SuccessDataResult<List<Customer>>(_custormerDal.GetAll(cus => cus.UserId == id));
        }

        [SecuredOperation("admin")]
        public IResult Update(Customer customer)
        {
            _custormerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
