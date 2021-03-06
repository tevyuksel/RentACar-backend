using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    [ValidationAspect(typeof(CarImageValidator))]
    class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [CacheAspect]
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImagesListed);
        }

        [CacheAspect]
        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(ci => ci.Id == id));
        }

        [CacheAspect]
        public IDataResult<List<CarImage>> GetCarImageByCarId(int id)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(id));
                           
        }

        [SecuredOperation("admin")]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimit(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarAdded);
        }

        [SecuredOperation("admin")]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = Environment.CurrentDirectory + @"\" + FileHelper.Update(_carImageDal.Get(p => p.Id == carImage.Id).ImagePath, file);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        [SecuredOperation("admin")]
        public IResult Delete(CarImage carImage)
        {
            var oldpath = Path.GetFullPath(_carImageDal.Get(p => p.Id == carImage.Id).ImagePath);

            IResult result = BusinessRules.Run(
                FileHelper.Delete(oldpath));

            if (result != null)
            {
                return result;
            }

            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }


        private IResult CheckImageExists(int imageId)
        {
            var result = _carImageDal.Get(i => i.Id == imageId);
            if (result == null)
            {
                return new ErrorResult(Messages.CarImageExistsError);
            }

            return new SuccessResult();
        }

        private IResult CheckImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.CarImageImageLimitError);
            }

            return new SuccessResult();
        }

        private List<CarImage> CheckIfCarImageNull(int id)
        {
            string path = @"images\default.jpg";
            var result = _carImageDal.GetAll(c => c.CarId == id).Any();
            if (!result)
            {
                return new List<CarImage> { new CarImage { CarId = id, ImagePath = path.Replace("\\", "/"), Date = DateTime.Now } };
            }
            return _carImageDal.GetAll(p => p.CarId == id);
        }

    }
}
