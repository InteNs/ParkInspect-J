using System.Collections.ObjectModel;

namespace ParkInspect.Repository.Interface
{
    public interface IBaseRepository<T>
    {
        ObservableCollection<T> GetAll();
        bool Add(T item);
        bool Delete(T item);
        bool Update(T item);
    }
}
