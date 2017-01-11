using System;
using System.Collections.Generic;

namespace Sample.Entities.Interfaces
{
    public interface IDataProvider
    {
        // Gets all records from the data provider
        IEnumerable<T> GetDataFromApi<T>(string table);
        // Gets all records from the data provider for a date
        IEnumerable<T> GetDataFromApi<T>(string table, string action, string dateId);
        // Gets a single record from the data provider
        T GetDataFromApi<T>(string table, int id);
        // Gets all records from the data provider from specific action and possibly id
        IEnumerable<T> GetDataFromApi<T>(string table, string action, int? id = null);
        // Gets all records from the data provider from specific action and possibly id
        IEnumerable<T> GetDataFromApi<T>(string table, string action, string id, int? atype = null);
        // Updates a single record 
        string UpdateDataToApi<T>(string table, int id, T value);
        // Empties the table
        string DeleteDataToApi(string table);
        // Deletes a single record
        string DeleteDataToApi(string table, int id);
        // Deletes a all records with this date
        string DeleteDataToApi(string table, string action, string dateId);
        // Deletes a all records with this date and type
        string DeleteDataToApi(string table, string action, string dateId, int type);
        // Deletes a all records with this date
        string DeleteDataToApi(string table, string action, DateTime dateId);
        // Inserts a single record and returns the id
        T AddDataToApi<T>(string table, T value);
    }
}
