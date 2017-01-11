using Sample.Entities.Data.Models;
using Sample.Entities.Implementation;
using Sample.Entities.Interfaces;

namespace Sample.Entities.Data.ViewModels
{
    public class CustomerVm : ObservableObject, IDataViewModel<CustomerVm>
    {
        private readonly Customer _customer;

        public Customer GetDataObject
        {
            get { return _customer; }
        }

        public int GetId()
        {
            return Id;
        }

        public CustomerVm()
        {
            _customer = new Customer()
            {
                Id = -1
            };
        }

        public CustomerVm(Customer people)
        {
            this._customer = people;
        }

        public void Update(CustomerVm item)
        {
            this.Id = item.Id;
            this.FirstName = item.FirstName;
            this.MiddleName = item.MiddleName;
            this.LastName = item.LastName;
            this.Address = item.Address;
            this.City = item.City;
            this.State = item.State;
            this.PostalCode = item.PostalCode;
        }

        public bool Validate()
        {
            if(string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName))
            {
                return false;
            }

            return true;
        }

        public int Id
        {
            get { return _customer.Id; }
            set
            {
                if (value != _customer.Id)
                {
                    _customer.Id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        public string FirstName
        {
            get { return _customer.FirstName; }
            set
            {
                if (value != _customer.FirstName)
                {
                    _customer.FirstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }

        public string MiddleName
        {
            get { return _customer.MiddleName; }
            set
            {
                if (value != _customer.MiddleName)
                {
                    _customer.MiddleName = value;
                    OnPropertyChanged("MiddleName");
                }
            }
        }

        public string LastName
        {
            get { return _customer.LastName; }
            set
            {
                if (value != _customer.LastName)
                {
                    _customer.LastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }

        public string Address
        {
            get { return _customer.Address; }
            set
            {
                if (value != _customer.Address)
                {
                    _customer.Address = value;
                    OnPropertyChanged("Address");
                }
            }
        }

        public string City
        {
            get { return _customer.City; }
            set
            {
                if (value != _customer.City)
                {
                    _customer.City = value;
                    OnPropertyChanged("City");
                }
            }
        }

        public string State
        {
            get { return _customer.State; }
            set
            {
                if (value != _customer.State)
                {
                    _customer.State = value;
                    OnPropertyChanged("State");
                }
            }
        }

        public string PostalCode
        {
            get { return _customer.PostalCode; }
            set
            {
                if (value != _customer.PostalCode)
                {
                    _customer.PostalCode = value;
                    OnPropertyChanged("PostalCode");
                }
            }
        }
    }
}
