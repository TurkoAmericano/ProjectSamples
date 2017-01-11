using Sample.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sample.Entities.Implementation
{
    internal class CancelCommand<T> : ICommand where T : IDataViewModel<T>
    {
        private readonly IListViewModel<T> _viewModel;

        public CancelCommand(IListViewModel<T> model)
        {
            if (model == null)
                return;

            _viewModel = model;
            _viewModel.PropertyChanged += vm_PropertyChanged;
        }

        ~CancelCommand()
        {
            _viewModel.PropertyChanged -= vm_PropertyChanged;
        }

        public bool CanExecute(object parameter)
        {
            return _viewModel.ItemSelected;
        }

        public void Execute(object parameter)
        {
            _viewModel.CancelItem();
        }

        public event EventHandler CanExecuteChanged;

        private void vm_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (string.Compare(e.PropertyName, "ItemSelected", StringComparison.Ordinal) == 0)
            {
                CanExecuteChanged?.Invoke(this, new EventArgs());
            }
        }
    }
}
