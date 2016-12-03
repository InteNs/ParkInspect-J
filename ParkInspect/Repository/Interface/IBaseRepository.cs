using System.Collections.ObjectModel;
using Data;
using ParkInspect.ViewModel;

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
