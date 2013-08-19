using System;
using System.Collections.Generic;

namespace uStorage.Interfaces.Services
{
    public interface ISqlCRUDService
    {
        Tuple<bool, string> TestConnection();
    }
}
