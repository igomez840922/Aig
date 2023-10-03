using AuditoriaApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditoriaApp.Helper
{
   
    public static class SeedData
    {
        public static async Task SeedAll(IServiceProvider serviceProvider)
        {
            await SeedFirstData(serviceProvider);
        }
          
        
        private static async Task SeedFirstData(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var dalService = serviceScope.ServiceProvider.GetService<IDalService>();
                /*   
                   //Countries
                   if (dalService.Count<CountryTB>() <= 0)
                   {
                       List<CountryTB> lCountries = null;
                       using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("RuletRules.Server.Resources.countries.json"))
                       using (StreamReader reader = new StreamReader(stream))
                       {
                           var jsonFileContent = reader.ReadToEnd();
                           lCountries = JsonConvert.DeserializeObject<List<CountryTB>>(jsonFileContent);
                       }
                       if (lCountries != null)
                       {
                           foreach(var country in lCountries)
                           {
                               dalService.Save(country);
                           }
                       }                    
                   }

                   //Currencies
                   if (dalService.Count<CurrencyTB>() <= 0)
                   {
                       List<CurrencyTB> lCurrency = null;
                       using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("RuletRules.Server.Resources.currencies.json"))
                       using (StreamReader reader = new StreamReader(stream))
                       {
                           var jsonFileContent = reader.ReadToEnd();
                           lCurrency = JsonConvert.DeserializeObject<List<CurrencyTB>>(jsonFileContent);
                       }
                       if (lCurrency != null)
                       {
                           foreach (var currency in lCurrency)
                           {
                               dalService.Save(currency);
                           }
                       }
                   }

                   //Banks Type
                   if (dalService.Count<BankTB>() <= 0)
                   {
                       List<BankTB> ldata = new List<BankTB>();
                       ldata.Add(new BankTB() { Name = "General Bank"});
                       ldata.Add(new BankTB() { Name = "Scotia Bank" });
                       ldata.Add(new BankTB() { Name = "Tower Bank" });
                       foreach (var data in ldata)
                       {
                           dalService.Save(data);
                       }
                   }

                   //Business Type
                   if (dalService.Count<BusinessTypeTB>() <= 0)
                   {
                       List<BusinessTypeTB> lBusiness = new List<BusinessTypeTB>();
                       lBusiness.Add(new BusinessTypeTB() { Name= "Agriculture" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Embassy" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Import" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Professional" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Arts" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Employee" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Import and Export" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Publishing Editorial" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Automobile" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Entertainment" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Insurance" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Real Estate" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Banking" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Export" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "International Organization" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Retail" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Cattle and Farming" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Factoring" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Leasing" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Retiree" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Chemicals" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Fiduciary" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Machinery and Equipment" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Services" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Communications" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Financial" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Manufacturing" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Special Projects" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Computer IT" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Fishing" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Medical and Social Services" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Steel" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Construction" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Food and Beverage" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Mining and Minerals" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Student" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Consultant" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Government Official" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Non-Profit Organization" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Telecommunications" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Credit Cards" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Hardware" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Oil and Gas" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Textile" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Diplomatic" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Holding Company" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Personal" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Transportation and Warehousing" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Education" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Hotel and Tourism" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Pharmaceutical" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Travel Agency" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Electricity" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Housewife" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Printing" });
                       lBusiness.Add(new BusinessTypeTB() { Name = "Wholesale" });
                       if (lBusiness != null)
                       {
                           foreach (var business in lBusiness)
                           {
                               dalService.Save(business);
                           }
                       }
                   }
               */
            }
        }


    }

}
