using Microsoft.AspNetCore.Mvc;
using MMT.UI.Site.Areas.CellManagement.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MMT.UI.Site.Areas.CellManagement.ViewComponents.CellData
{
    public class CellDataViewComponent : ViewComponent
    {
        public CellDataViewComponent()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync(string tabName)
        {
            IEnumerable<CellDataViewModel> cellResults = null;
            using (var httpClient = new HttpClient())
            {
                using(var response = await httpClient.GetAsync("http://localhost:5000" + "/api/Cell?cellName=" + tabName))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    cellResults = JsonConvert.DeserializeObject<IEnumerable<CellDataViewModel>>(apiResponse);
                }
            }
            return View("CellData", cellResults);
        }
    }
}
