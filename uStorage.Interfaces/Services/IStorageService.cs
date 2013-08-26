using System;
using System.Collections.Generic;
using uStorage.Interfaces.DTO;

namespace uStorage.Interfaces.Services
{
    public interface IStorageService
    {
        Tuple<bool, string> TestConnection();
        string AddObject(string collectionName, object obj);
        IEnumerable<Collection> GetCollections();
        string AddCollection(Collection collection);
        string DeleteCollection(Collection collection);
    }
}
