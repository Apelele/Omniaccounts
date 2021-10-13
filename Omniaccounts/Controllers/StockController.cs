using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Omniaccounts.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Omniaccounts.Controllers
{
    public class StockController : Controller
    {
        // GET: Stock
        public ActionResult Index()
        {
          
            return View();
        }
        public ActionResult SearchStock()
        {
           
            return View();
        }
        public async Task<ActionResult> GetStock(BarCodeViewModel barCodeViewModel)
        {
            barCodeViewModel.Company = "SA Example Company [Demo]";
            barCodeViewModel.Username = "Guest";
            barCodeViewModel.Password = "Dev2021";
            string url = "http://st.omniaccounts.co.za:55683/Report/Stock Export";
            string query = string.Format(url +"?CompanyName={0}&UserName={1}&password={2}&IBarCode={3}", barCodeViewModel.Company.ToString(), barCodeViewModel.Username.ToString(), barCodeViewModel.Password.ToString(), barCodeViewModel.Barcode);
            var response = GlobalVariables.WebApiClient.GetAsync(query).Result;
            var content = await response.Content.ReadAsStringAsync();
            var stock = JsonConvert.DeserializeObject<Rootobject>(content);
            Stock_Export model = new Stock_Export
            {
                stock_list = stock.stock_export.ToList()
            };
            return View(model.stock_list);
        }
        
    }
}