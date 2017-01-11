using System;
using System.ComponentModel;
using System.Windows.Input;
using Sample.Entities.Interfaces;

namespace Sample.Entities.Implementation
{
    internal class AddCommand<T> : ICommand where T : IDataViewModel<T>
    {
        private readonly IListViewModel<T> _viewModel;

        public AddCommand(IListViewModel<T> model)
        {
            if (model == null)
                return;

            _viewModel = model;
            _viewModel.PropertyChanged += vm_PropertyChanged;
        }

        ~AddCommand()
        {
            _viewModel.PropertyChanged -= vm_PropertyChanged;
        }

        public bool CanExecute(object parameter)
        {
            return !_viewModel.ItemSelected;
        }

        public void Execute(object parameter)
        {
            _viewModel.AddItem();
        }

        public event EventHandler CanExecuteChanged;

        private void vm_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (string.Compare(e.PropertyName, "SelectedItem", StringComparison.Ordinal) == 0)
            {
                CanExecuteChanged?.Invoke(this, new EventArgs());
            }
        }
    }
}
