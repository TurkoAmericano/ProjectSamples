using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Sample.Entities.Interfaces
{
    public interface IListViewModel<T> : INotifyPropertyChanged
    {
        T SelectedItem { get; set; }
        ObservableCollection<T> ItemList { get; }
        bool ItemSelected { get; }

        void UpdateItem();
        void AddItem();
        void DeleteItem();
        void CancelItem();
    }
}