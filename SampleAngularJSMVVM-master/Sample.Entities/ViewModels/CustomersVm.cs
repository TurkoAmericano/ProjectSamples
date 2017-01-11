using Sample.Entities.Data.Models;
using Sample.Entities.Data.ViewModels;
using Sample.Entities.Implementation;
using Sample.Entities.Interfaces;
using System.Linq;

namespace Sample.Entities.ViewModels
{
    public class CustomersVm : ViewModelBase<CustomerVm>
    {
        public CustomersVm(IDataProvider provider)
        {
            _provider = provider;

            LoadDataFromProvider();
        }

        private void LoadDataFromProvider()
        {
            ItemList.Clear();

            // Get all the records from the database and put them in a list.
            var dataList = _provider.GetDataFromApi<Customer>("Customers");
            if (dataList != null)
            {
                foreach (var data in dataList)
                {
                    ItemList.Add(new CustomerVm(data));
                }
            }
        }

        public override void AddItem()
        {
            // Create a new record to edit.
            SelectedItem = new CustomerVm();
        }

        public override void CancelItem()
        {
            SelectedItem = null;
        }

        public override void DeleteItem()
        {
            // Delete item in database.
            DeleteItemToProvider(SelectedItem);

            // Load the new records from database.
            LoadDataFromProvider();
        }

        public override void UpdateItem()
        {
            // If this is an existing item, Update it.
            if (SelectedItem.GetId() > -1)
            {
                var model = ItemList.FirstOrDefault(x => x.GetId() == SelectedItem.GetId());
                UpdateItemToProvider(SelectedItem);
            }
            // Else, Send a new one to the database.
            else
            {
                AddItemToProvider(SelectedItem);
            }

            // Clear Selected item.
            SelectedItem = null;

            // Load the new records from database.
            LoadDataFromProvider();
        }

        private void UpdateItemToProvider(CustomerVm item)
        {
            _provider.UpdateDataToApi("Customers", item.Id, item.GetDataObject);
        }

        private void AddItemToProvider(CustomerVm item)
        {
            _provider.AddDataToApi("Customers", item.GetDataObject);
        }

        private void DeleteItemToProvider(CustomerVm item)
        {
            _provider.DeleteDataToApi("Customers", item.Id);
        }
    }
}
