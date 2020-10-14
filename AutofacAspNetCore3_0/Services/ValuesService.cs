using System.Collections.Generic;
using BLL;
using Microsoft.Extensions.Logging;

namespace AutofacAspNetCore3_0.Services
{
    public class ValuesService : IValuesService
    {
        private readonly ILogger<ValuesService> _logger;
        private readonly BLL.TestAutofacBLL testAutofac;

        public ValuesService(ILogger<ValuesService> logger, TestAutofacBLL testAutofacBLL)
        {
            this._logger = logger;
            this.testAutofac = testAutofacBLL;
        }

        public IEnumerable<string> FindAll()
        {
            this._logger.LogDebug("{method} called", nameof(this.FindAll));

            return new[] { "value1", "value2" };
        }

        public string Find(int id)
        {
            this._logger.LogDebug("{method} called with {id}", nameof(this.Find), id);

            return $"value{id} " + this.testAutofac.ToString();
        }
    }
}
