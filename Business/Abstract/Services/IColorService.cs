using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.Services
{
    public interface IColorService
    {
        IDataResult<List<Color>> GetColors(Expression<Func<Color, bool>> filter = null);
        IDataResult<Color> GetById(int colorId);
        IResult Add(Color color);
        IResult Delete(Color color);
        IResult Update(Color color);
    }
}
