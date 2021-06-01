using System.Collections.Generic;
using System.Threading.Tasks;

namespace Test.IServices
{
    public interface ILogin<T>
    {
        List<T> RetriveAll();
        T Retrive(string email);
        T Create(T item);
        bool Delete(string email);
        T Put(T item);

    }
}
