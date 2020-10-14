using System.Collections.Generic;

namespace AutofacAspNetCore3_0.Services
{
    public interface IValuesService
    {
        IEnumerable<string> FindAll();

        string Find(int id);
    }
}