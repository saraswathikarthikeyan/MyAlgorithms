using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidateConfigItems
{
    //Class to hold the List of Configuration 
    public class Configuration
    {
        public List<ConfigItems> configItems;
    }

    //Class contains the Properties of the Configuration
    public class ConfigItems
    {
        public int item;
        public List<int> lstDeduction;
        public List<int> lstYear;
        public List<int> lstPostal;
    }
    class Program
    {
        //Method fetches the Configuration Items from DB and Stores in the Class
        public static Configuration FetchConfigItems()
        {
              var  configuration = new Configuration()
              {
                configItems = new List<ConfigItems>()
                {
                    new ConfigItems() { item=1, lstDeduction = new List<int>{ 300}, lstYear = new List<int>(),lstPostal = new List<int>()},
                    new ConfigItems() { item=2, lstDeduction = new List<int>{ 2500}, lstYear = new List<int>{ 1982 },lstPostal = new List<int>()},
                    new ConfigItems() { item=3, lstDeduction = new List<int>{ 1000}, lstYear = new List<int>{ 1966,1963 },lstPostal = new List<int>{ 8000} },
                    new ConfigItems() { item=4, lstDeduction = new List<int>{ 2000}, lstYear = new List<int>{ 1990},lstPostal = new List<int>{ 8112,8113}},
                }
              };
            return configuration;
        }

        //Method checks the Configuration Items and returns "YES" or "NO" to showthe button
        public static string CheckShowButton(int deduction, int year, int postal)
        {
           
            string strDeduction = "", strPostal = "", strYear = "", showbutton = "yes";

            try {
                    var objConfiguraion = FetchConfigItems();
                    foreach (var items in objConfiguraion.configItems)
                    {
                        //Console.WriteLine(items.item);
                        if (items.lstDeduction.Count > 0) {
                            if (items.lstDeduction.Contains(deduction)) {
                                strDeduction = "yes";
                            }
                            else { 
                                strDeduction = "no";
                            }
                        }

                        if (items.lstYear.Count > 0) {
                            if (items.lstYear.Contains(year)){
                                strPostal = "yes";
                            }
                            else {
                                strPostal = "no";
                            }
                        }
                       

                        if (items.lstPostal.Count > 0 ) {
                            if(items.lstPostal.Contains(postal)) { 
                                strYear = "yes";
                            }
                            else {
                                strYear = "no";
                            }
                        }
                        
                        //Console.WriteLine("ded: {0}, year: {1}, postal:{2}", strDeduction, strPostal, strYear);
                        if ((strDeduction == "" || strDeduction == "yes") && (strPostal == "" || strPostal == "yes") && (strYear == "" || strYear == "yes"))
                        {
                            showbutton = "no"; break;
                        }
                    }
                }   
                catch(Exception ex)
                {
                    throw ex;
                }

            return showbutton;
        }

        static void Main(string[] args)
        {      
            //Input Items
            int ip_deduction = 3001;
            int ip_year = 1990;
            int ip_postal = 8112;

            Console.WriteLine(CheckShowButton(ip_deduction, ip_year, ip_postal));
            Console.ReadLine();
        }                
    }
}
