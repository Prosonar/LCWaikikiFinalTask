﻿using Business.Abstract.Services;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.ExceptionHandle;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.Manager
{
    public class BrandManager : IBrandService
    {
        private IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [ValidationAspect(typeof(BrandValidator), Priority = 4)]
        [AuthAspect("admin", Priority = 5)]
        [CacheRemoveAspect("IBrandService.Get", Priority = 3)]
        public IResult Add(Brand brand)
        {
            var result = ExceptionHandler.HandleWithNoReturn(() =>
            {
                _brandDal.Add(brand);
            });
            if (!result)
            {
                return new ErrorResult("");
            }
            return new SuccessResult("");
        }
        [AuthAspect("admin", Priority = 5)]
        [CacheRemoveAspect("IBrandService.Get", Priority = 3)]
        public IResult Delete(Brand brand)
        {
            var result = ExceptionHandler.HandleWithNoReturn(() =>
            {
                _brandDal.Delete(brand);
            });
            if (!result)
            {
                return new ErrorResult("");
            }
            return new SuccessResult("");
        }
        [AuthAspect("admin", Priority = 5)]
        [CacheAspect]
        public IDataResult<List<Brand>> GetBrands(Expression<Func<Brand, bool>> filter = null)
        {
            var result = ExceptionHandler.HandleWithReturn<Expression<Func<Brand, bool>>, List<Brand>>((f) =>
            {
                return _brandDal.GetAll(f);
            }, filter);
            if (!result.Success)
            {
                return new ErrorDataResult<List<Brand>>("");
            }
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(filter), "");
        }
        [AuthAspect("admin", Priority = 5)]
        [CacheAspect]
        public IDataResult<Brand> GetById(int brandId)
        {
            var result = ExceptionHandler.HandleWithReturn<int, Brand>((x) =>
            {
                return _brandDal.GetById(b => b.Id == x);
            }, brandId);
            if (!result.Success)
            {
                return new ErrorDataResult<Brand>("");
            }
            return new SuccessDataResult<Brand>(_brandDal.GetById(b => b.Id == brandId),"");
        }

        [ValidationAspect(typeof(BrandValidator), Priority = 4)]
        [AuthAspect("admin", Priority = 5)]
        [CacheRemoveAspect("IBrandService.Get", Priority = 3)]
        public IResult Update(Brand brand)
        {
            var result = ExceptionHandler.HandleWithNoReturn(() =>
            {
                _brandDal.Update(brand);
            });
            if (!result)
            {
                return new ErrorResult("");
            }
            return new SuccessResult("");
        }
    }
}
