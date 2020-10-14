using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutofacAspNetCore3_0.MiddleLayer
{
    public class events
    {
        private TestAutofacBLL testAutofac;

        public events(BLL.TestAutofacBLL testAutofacBLL)
        {
            this.testAutofac = testAutofacBLL;
        }

        public override string ToString()
        {
            return " events = " + testAutofac.ToString();

        }
    }
}
