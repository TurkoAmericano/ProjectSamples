using System.ComponentModel;

namespace Sample.Entities.Interfaces
{
    public interface IDataViewModel<T> : INotifyPropertyChanged
    {
        int GetId();
        bool Validate();
        void Update(T item);
    }
}