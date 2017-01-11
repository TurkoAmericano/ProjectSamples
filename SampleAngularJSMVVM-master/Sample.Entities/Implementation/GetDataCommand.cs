using Sample.Entities.Interfaces;
using System;
using System.Windows.Input;

namespace Sample.Entities.Implementation
{
    public class GetDataCommand<T> : ICommand where T : IDataViewModel<T>
    {
        private readonly IListViewModel<T> _viewModel;

        public GetDataCommand(IListViewModel<T> model)
        {
            if (model == null)
                return;

            _viewModel = model;
        }

        ~GetDataCommand()
        {
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var vm = _viewModel as IGetData;
            vm?.GetData(parameter);
        }

#pragma warning disable 67
        public event EventHandler CanExecuteChanged;
#pragma warning restore 67
    }
}
