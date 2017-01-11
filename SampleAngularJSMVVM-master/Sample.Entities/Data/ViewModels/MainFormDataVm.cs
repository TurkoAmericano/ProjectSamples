using Sample.Entities.Data.Models;
using Sample.Entities.Implementation;
using Sample.Entities.Interfaces;

namespace Sample.Entities.Data.ViewModels
{
    public class MainFormDataVm : ObservableObject, IDataViewModel<MainFormDataVm>
    {
        private readonly MainFormData _mainformdata;

        public MainFormData GetDataObject
        {
            get { return _mainformdata; }
        }

        public int GetId()
        {
            return Id;
        }

        public void Update(MainFormDataVm item)
        {
            this.Id = item.Id;
            this.SelectedName = item.SelectedName;
        }

        public bool Validate()
        {
            return true;
        }

        public int Id
        {
            get { return _mainformdata.Id; }
            set
            {
                if (value != _mainformdata.Id)
                {
                    _mainformdata.Id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        public string SelectedName
        {
            get { return _mainformdata.SelectedName; }
            set
            {
                if (value != _mainformdata.SelectedName)
                {
                    _mainformdata.SelectedName = value;
                    OnPropertyChanged("SelectedName");
                }
            }
        }
    }
}
