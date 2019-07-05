using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidateConfigItems
{
    public class configuration
    {
        public List<configItems> configItems;
    }

    public class configItems
    {
        public int item;
        public List<int> lstDeduction;
        public List<int> lstYear;
        public List<int> lstPostal;
    }
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new configuration()
            {
                configItems = new List<configItems>()
                {
                    new configItems() { item=1, lstDeduction = new List<int>{ 300}, lstYear = new List<int>(),lstPostal = new List<int>()},
                    new configItems() { item=2, lstDeduction = new List<int>{ 2500}, lstYear = new List<int>{ 1982 },lstPostal = new List<int>()},
                    new configItems() { item=3, lstDeduction = new List<int>{ 1000}, lstYear = new List<int>{ 1966,1963 },lstPostal = new List<int>{ 8000} },
                    new configItems() { item=4, lstDeduction = new List<int>{ 2000}, lstYear = new List<int>{ 1990},lstPostal = new List<int>{ 8112,8113}},
                },
            };

            int deduction = 1000;
            int year = 1960;
            int postal = 8000;
            string strDeduction = "",strPostal = "", strYear = "", Showbutton = "yes"; 

            foreach(var items in configuration.configItems)
            {
                //Console.WriteLine(items.item);
                if(items.lstDeduction.Count > 0 && items.lstDeduction.Contains(deduction)){
                    strDeduction = "yes";
                }
                else{
                    strDeduction = "no";
                }

                if (items.lstYear.Count > 0 && items.lstYear.Contains(year)){
                    strPostal = "yes";
                }
                else {
                    strPostal = "no";
                }

                if (items.lstPostal.Count > 0 && items.lstPostal.Contains(postal)) {
                    strYear = "yes";
                }
                else {
                    strYear = "no";
                }

                if ((strDeduction == "" || strDeduction == "yes") && (strPostal == "" || strPostal == "yes") && (strYear == "" || strYear == "yes")) {
                    Showbutton ="no"; break;
                }                
            }
            Console.WriteLine(Showbutton);
            Console.ReadLine();
        }                
    }
}
