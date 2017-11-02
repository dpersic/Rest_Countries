using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace Rest_countries
{

    class Program
    {
        static void Main(string[] args)
        {
            StreamReader oSr = new StreamReader("Countries.json");
            string sJson = "";
            using (oSr)
            {
                sJson = oSr.ReadToEnd();
            }
            JObject oJson = JObject.Parse(sJson);
            var oCountries = oJson["countries"].ToList();
            List<Country> lCountry = new List<Country>();
            for (int i = 0; i < oCountries.Count; i++)
            {
                lCountry.Add(new Country
                {
                    sName = (string)oCountries[i]["name"],
                    sCode = (string)oCountries[i]["alpha2Code"],
                    sCapital = (string)oCountries[i]["capital"],
                    nPopulation = (int)oCountries[i]["population"],
                    fArea = (long)oCountries[i]["area"]
                });
                }
            /*  for(int i=0;i<lCountry.Count;i++)
              {
                  Console.WriteLine("Država:" + lCountry[i].sName + ' '+ "Glavni grad:" + lCountry[i].sCapital);
              }*/

            var OrderByQuery = from c in lCountry.OrderBy(o => o.nPopulation) select c;
            List<Country> lSortedCountries = OrderByQuery.ToList();
            for (int i=0;i < lSortedCountries.Count;i++)
            {
                
                Console.WriteLine(lSortedCountries[i].sName + ' ' + lSortedCountries[i].sCapital+ ' '+ lSortedCountries[i].nPopulation);
            }
            Console.ReadKey();
            }
        }
    }
