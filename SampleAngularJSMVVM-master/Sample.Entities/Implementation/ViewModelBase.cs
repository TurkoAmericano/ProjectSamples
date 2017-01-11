using Sample.Entities.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Sample.Entities.Implementation
{
    public abstract class ViewModelBase<T> : ObservableObject, IListViewModel<T> where T : IDataViewModel<T>, new()
    {
        protected IDataProvider _provider;

        private ObservableCollection<T> _itemList;
        private T _selectedItemVM;
        private bool _itemSelected;
        private readonly ICommand _updateCommand;
        private readonly ICommand _addCommand;
        private readonly ICommand _deleteCommand;
        private readonly ICommand _cancelCommand;
        private readonly ICommand _getDataCommand;

        public ObservableCollection<T> ItemList
        {
            get { return _itemList; }
            private set
            {
                _itemList = value;
                OnPropertyChanged("ItemList");
                SelectedItem = default(T);
            }
        }

        public T SelectedItem
        {
            get { return _selectedItemVM; }
            set
            {
                if (value == null)
                {
                    if (_selectedItemVM != null)
                    {
                        _selectedItemVM.PropertyChanged -= SelectedItemPropertyChanged;
                    }
                    _selectedItemVM = default(T);
                    ItemSelected = false;
                }
                else
                {
                    if (_selectedItemVM == null)
                    {
                        _selectedItemVM = new T();
                        _selectedItemVM.PropertyChanged += SelectedItemPropertyChanged;
                    }

                    _selectedItemVM.Update(value);
                    ItemSelected = true;
                }
                OnPropertyChanged("SelectedItem");
            }
        }

        public bool ItemSelected
        {
            get { return _itemSelected; }
            private set
            {
                _itemSelected = value;
                OnPropertyChanged("ItemSelected");
            }
        }

        private void SelectedItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged("SelectedItem");
        }

        public ICommand UpdateCommand => _updateCommand;
        public ICommand AddCommand => _addCommand;
        public ICommand DeleteCommand => _deleteCommand;
        public ICommand CancelCommand => _cancelCommand;
        public ICommand SelectionCommand => _getDataCommand;

        protected ViewModelBase()
        {
            ItemList = new ObservableCollection<T>();
            _updateCommand = new UpdateCommand<T>(this);
            _addCommand = new AddCommand<T>(this);
            _deleteCommand = new DeleteCommand<T>(this);
            _cancelCommand = new CancelCommand<T>(this);
            _getDataCommand = new GetDataCommand<T>(this);
        }

        public abstract void UpdateItem();
        public abstract void AddItem();
        public abstract void DeleteItem();
        public abstract void CancelItem();
        //public abstract void GetDataItem();
    }
}
