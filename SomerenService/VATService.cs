using SomerenDAL;
using SomerenModel;
using SomerenService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenService
{
    public class VATService
    {
        private VATDao vatdb;

        public VATService()
        {
            vatdb = new VATDao();
        }


        public List<VATInformation> GetAllVATInformation()
        {
            List<VATInformation> VATInformation = vatdb.GetAllVATInformation();
            return VATInformation;
        }















    }
}
