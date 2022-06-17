using Business.Abstract.Services;
using Business.BusinessAspects.Autofac;
using Business.Utilities.Messages;
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
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [ValidationAspect(typeof(ProductValidator), Priority = 4)]
        [AuthAspect("admin", Priority = 5)]
        [CacheRemoveAspect("IProductService.Get", Priority = 3)]
        public IResult Add(Product product)
        {
            var result = ExceptionHandler.HandleWithNoReturn(() =>
            {
                _productDal.Add(product);
            });
            if (!result)
            {
                return new ErrorResult(Messages.ErrorMessage);
            }
            return new SuccessResult(Messages.SuccessMessage);
        }
        [AuthAspect("admin", Priority = 5)]
        [CacheRemoveAspect("IproductService.Get", Priority = 3)]
        public IResult Delete(Product product)
        {

            var result = ExceptionHandler.HandleWithNoReturn(() =>
            {
                _productDal.Delete(product);
            });
            if (!result)
            {
                return new ErrorResult(Messages.ErrorMessage);
            }
            return new SuccessResult(Messages.SuccessMessage);
        }
        [AuthAspect("admin", Priority = 5)]
        [CacheAspect]
        public IDataResult<Product> GetById(int productId)
        {
            var result = ExceptionHandler.HandleWithReturn<int, Product>((x) =>
            {
                return _productDal.GetById(c => c.Id == x);
            }, productId);
            if (!result.Success)
            {
                return new ErrorDataResult<Product>(Messages.ErrorMessage);
            }
            return new SuccessDataResult<Product>(_productDal.GetById(c => c.Id == productId), Messages.SuccessMessage);
        }

        [AuthAspect("admin", Priority = 5)]
        [CacheAspect]
        public IDataResult<List<Product>> GetProducts(Expression<Func<Product, bool>> filter = null)
        {
            var result = ExceptionHandler.HandleWithReturn<Expression<Func<Product, bool>>, List<Product>>((f) =>
            {
                return _productDal.GetAll(f);
            }, filter);
            if (!result.Success)
            {
                return new ErrorDataResult<List<Product>>(Messages.ErrorMessage);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(filter), Messages.SuccessMessage);
        }

        [ValidationAspect(typeof(ProductValidator), Priority = 4)]
        [AuthAspect("admin", Priority = 5)]
        [CacheRemoveAspect("IProductService.Get", Priority = 3)]
        public IResult Update(Product product)
        {
            var result = ExceptionHandler.HandleWithNoReturn(() =>
            {
                _productDal.Update(product);
            });
            if (!result)
            {
                return new ErrorResult(Messages.ErrorMessage);
            }
            return new SuccessResult(Messages.SuccessMessage);
        }
    }
}
