using System;

namespace BLL
{
    public class TestAutofacBLL
    {

        readonly TestAutofac2BLL testAutofac2;

        public TestAutofacBLL(TestAutofac2BLL testAutofac2BLL)
        {
            this.testAutofac2 = testAutofac2BLL;
        }
        public override string ToString()
        {
            return this.testAutofac2.ToString() + " TestAutofacBLL.ToString()";
        }
    }
}
