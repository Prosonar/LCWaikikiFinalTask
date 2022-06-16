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
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        [ValidationAspect(typeof(CategoryValidator), Priority = 4)]
        [AuthAspect("admin", Priority = 5)]
        [CacheRemoveAspect("ICategoryService.Get", Priority = 3)]
        public IResult Add(Category category)
        {
            var result = ExceptionHandler.HandleWithNoReturn(() =>
            {
                _categoryDal.Add(category);
            });
            if (!result)
            {
                return new ErrorResult(Messages.ErrorMessage);
            }
            return new SuccessResult(Messages.SuccessMessage);
        }
        [AuthAspect("admin", Priority = 5)]
        [CacheRemoveAspect("ICategoryService.Get", Priority = 3)]
        public IResult Delete(Category category)
        {

            var result = ExceptionHandler.HandleWithNoReturn(() =>
            {
                _categoryDal.Delete(category);
            });
            if (!result)
            {
                return new ErrorResult(Messages.ErrorMessage);
            }
            return new SuccessResult(Messages.SuccessMessage);
        }
        [AuthAspect("admin", Priority = 5)]
        [CacheAspect]
        public IDataResult<Category> GetById(int categoryId)
        {
            var result = ExceptionHandler.HandleWithReturn<int, Category>((x) =>
            {
                return _categoryDal.GetById(c => c.Id == x);
            }, categoryId);
            if (!result.Success)
            {
                return new ErrorDataResult<Category>(Messages.ErrorMessage);
            }
            return new SuccessDataResult<Category>(_categoryDal.GetById(c => c.Id == categoryId), Messages.SuccessMessage);
        }

        [AuthAspect("admin", Priority = 5)]
        [CacheAspect]
        public IDataResult<List<Category>> GetCategories(Expression<Func<Category, bool>> filter = null)
        {
            var result = ExceptionHandler.HandleWithReturn<Expression<Func<Category, bool>>, List<Category>>((f) =>
            {
                return _categoryDal.GetAll(f);
            }, filter);
            if (!result.Success)
            {
                return new ErrorDataResult<List<Category>>(Messages.ErrorMessage);
            }
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(filter), Messages.SuccessMessage);
        }

        [ValidationAspect(typeof(CategoryValidator), Priority = 4)]
        [AuthAspect("admin", Priority = 5)]
        [CacheRemoveAspect("ICategoryService.Get", Priority = 3)]
        public IResult Update(Category category)
        {
            var result = ExceptionHandler.HandleWithNoReturn(() =>
            {
                _categoryDal.Update(category);
            });
            if (!result)
            {
                return new ErrorResult(Messages.ErrorMessage);
            }
            return new SuccessResult(Messages.SuccessMessage);
        }
    }
}
