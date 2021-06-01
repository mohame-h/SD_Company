using System.Collections.Generic;
using System.Threading.Tasks;

namespace Test.IServices
{
    public interface IGeneric<T>
    {
        List<T> RetriveAll();
        T Retrive(int id);
        T Create(T item);
        bool Delete(int id);
        T Put(T item);

    }
}
