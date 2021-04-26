using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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
    [ValidationAspect(typeof(RentalValidator))]
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;

        }

        [SecuredOperation("admin")]
        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(CheckIsCarReturn(rental.CarId));
            if (result != null)
            {
                return result;
            }

            _rentalDal.Add(rental);
            return new SuccessResult();
        }

        [SecuredOperation("admin")]
        public IResult Delete(Rental rental)
        {
            var result = BusinessRules.Run(CheckRentalExists(rental.Id));
            if (result != null)
            {
                return result;
            }
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == rentalId));
        }

        [CacheAspect]
        public IDataResult<List<Rental>> GetRentalsByCarId(int id)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.CarId == id));
        }

        [CacheAspect]
        public IDataResult<List<Rental>> GetRentalsByCustomerId(int id)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.CustomerId == id));
        }

        [SecuredOperation("admin")]
        public IResult Update(Rental rental)
        {
            var result = BusinessRules.Run(CheckRentalExists(rental.Id));
            if (result != null)
            {               
                return result;
            }
            _rentalDal.Update(rental);
            return new SuccessResult();
        }

        public bool CarIsAvailable(Rental rental)
        {
            bool isAvaileable = true;
            if (rental != null && rental.ReturnDate == new DateTime(1900, 01, 01, 00, 00, 00))
            {
                isAvaileable = false;
            }
            return isAvaileable;
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetailsDto()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetailsDto());
        }

        private IResult CheckIsCarReturn(int carId)
        {
            var results = _rentalDal.GetAll(r => r.CarId == carId);
            foreach (var result in results)
            {
                if (result.ReturnDate == null || result.RentDate > result.ReturnDate)
                {
                    return new ErrorResult(Messages.RentalCheckIsCarReturnError);
                }
            }

            return new SuccessResult();
        }

        private IResult CheckRentalExists(int rentalId)
        {
            var result = _rentalDal.Get(r => r.Id == rentalId);
            if (result == null)
            {
                return new ErrorResult(Messages.RentalCheckRentalExistsError);
            }

            return new SuccessResult();
        }
    }
}
