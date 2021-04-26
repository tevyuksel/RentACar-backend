using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<Rental>> GetRentalsByCarId(int id);
        IDataResult<List<Rental>> GetRentalsByCustomerId(int id);
        IDataResult<Rental> GetById(int rentalId);
        IDataResult<List<RentalDetailDto>> GetRentalDetailsDto();
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);
    }
}
