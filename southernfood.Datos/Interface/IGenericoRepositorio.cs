using System.Collections.Generic;
using System.Threading.Tasks;

namespace southernfood.Datos.Interface
{
    public interface IGenericoRepositorio<T> where T : class
    {
        Task<IEnumerable<T>> Get();
        Task<T> Find(int? id);
        Task<T> Add(T t);
        Task<bool> Update(T t);
        Task<bool> Delete(int id);
    }
}
