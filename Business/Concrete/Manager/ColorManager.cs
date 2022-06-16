using Business.Abstract.Services;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.Manager
{
    public class ColorManager : IColorService
    {
        public IResult Add(Color color)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Color color)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Color> GetById(int colorId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Color>> GetColors(Expression<Func<Color, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Color color)
        {
            throw new NotImplementedException();
        }
    }
}
