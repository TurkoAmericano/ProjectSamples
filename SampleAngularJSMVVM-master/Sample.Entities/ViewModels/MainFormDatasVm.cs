using Sample.Entities.Data.ViewModels;
using Sample.Entities.Implementation;
using Sample.Entities.Interfaces;
using System;
using System.Windows.Input;

namespace Sample.Entities.ViewModels
{
    public class MainFormDatasVm : ViewModelBase<MainFormDataVm>, IGetData
    {
        private readonly IViewResolver _viewResolver;
        private readonly ICommand _getDataCommand;
        public ICommand GetDataCommand => _getDataCommand;

        public MainFormDatasVm(IDataProvider provider, IViewResolver viewResolver)
        {
            _provider = provider;
            _viewResolver = viewResolver;

            _getDataCommand = new GetDataCommand<MainFormDataVm>(this);
        }

        public override void UpdateItem()
        {
            throw new NotImplementedException();
        }

        public override void AddItem()
        {
            throw new NotImplementedException();
        }

        public override void DeleteItem()
        {
            throw new NotImplementedException();
        }

        public override void CancelItem()
        {
            throw new NotImplementedException();
        }

        void IGetData.GetData(object parameter)
        {
            _viewResolver.Show("SampleCustomer");
        }
    }
}
