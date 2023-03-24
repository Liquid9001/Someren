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



        public List<VATInformation> GetQuarterData(List<VATInformation>VATInformation, int quarter)
        {
            List<VATInformation> quarterList = new List<VATInformation>(); 
            foreach (VATInformation VATRow in VATInformation)
            {
                int maand = VATRow.DrinkBought.Month;
                if ((maand - 1) / 3 == (quarter - 1))
                {
                    quarterList.Add(VATRow);
                }
            }        
            
            return quarterList;
        }

        public List<VATInformation> GetTypeOfDrinkData(List<VATInformation> VATInformation, bool isAlcoholic)
        {
            List<VATInformation> typeOfDrinkList = new List<VATInformation>();
            foreach (VATInformation VATRow in VATInformation)
            {
                if (VATRow.DrinkType == isAlcoholic)
                {
                    typeOfDrinkList.Add(VATRow);
                }
            }

            return typeOfDrinkList;
        }

           

        public double GetDrinkAmount ( int quarter, bool isAlcoholic)
        {
            double drinkAmount = 0;
            List<VATInformation> VATInformation = GetAllVATInformation();
            List<VATInformation> VATList = GetTypeOfDrinkData(GetQuarterData(VATInformation, quarter), isAlcoholic);
            foreach (VATInformation VATRow in VATList)
            {
                drinkAmount += (VATRow.Price*VATRow.SoldAmount);
                
            }

            return drinkAmount;
        }





        public VATData getVATData(int quarter)
        {
            double lowVATRate = 0.06;
            double highVATRate = 0.21;
        
            VATData VAT = new VATData()
            {
                High = (GetDrinkAmount(quarter, true)*highVATRate),
                Low = (GetDrinkAmount(quarter, false)*lowVATRate)
            };

            return VAT;

        }



    }
     public class VATData
    {
        public double High;
        public double Low;
        

        
    }
    
    
}
