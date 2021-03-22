using Business.AbstractValidator;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using Entities.Concrete;

using System.Text;
using Core.Utilities.Results;
using Core.Aspects.Autofac.Validation;
using Business.ValidationRules.FluentValidation;
using Business.Constants;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _color;
        public ColorManager(IColorDal color)
        {
            _color = color;
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            _color.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(Color color)
        {
            _color.Delete(color);
            return new  SuccessResult(Messages.ColorDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_color.GetAll());
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_color.Get(d => d.ColorId == id));
        }

        public IResult Update(Color color)
        {
            _color.Update(color);

            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
