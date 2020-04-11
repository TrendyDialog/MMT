using Microsoft.AspNetCore.Mvc;
using MMT.UI.Site.Areas.CellManagement.Models;

namespace MMT.UI.Site.Areas.CellManagement.Controllers
{
    [Area("cellmanagement")]
    [Route("cellmanagement/cell")]
    public class CellController : Controller
    {
        [Route("index")]
        public IActionResult Index(CellTabViewModel cellTabViewModel)
        {
            if(cellTabViewModel == null)
            {
                cellTabViewModel = new CellTabViewModel
                {
                    ActiveTab = Tab.Tab11
                };
            } 

            return View(cellTabViewModel);
        }

        public IActionResult SwitchTabs(string tabName)
        {
            var cellTab = new CellTabViewModel();

            switch (tabName)
            {
                case "11":
                    cellTab.ActiveTab = Tab.Tab11;
                    break;

                case "12":
                    cellTab.ActiveTab = Tab.Tab12;
                    break;

                case "13":
                    cellTab.ActiveTab = Tab.Tab13;
                    break;

                case "14":
                    cellTab.ActiveTab = Tab.Tab14;
                    break;

                case "15":
                    cellTab.ActiveTab = Tab.Tab15;
                    break;

                case "16":
                    cellTab.ActiveTab = Tab.Tab16;
                    break;

                case "17":
                    cellTab.ActiveTab = Tab.Tab17;
                    break;

                case "21":
                    cellTab.ActiveTab = Tab.Tab21;
                    break;

                case "22":
                    cellTab.ActiveTab = Tab.Tab22;
                    break;

                case "23":
                    cellTab.ActiveTab = Tab.Tab23;
                    break;

                case "24":
                    cellTab.ActiveTab = Tab.Tab24;
                    break;

                case "25":
                    cellTab.ActiveTab = Tab.Tab25;
                    break;

                case "26":
                    cellTab.ActiveTab = Tab.Tab26;
                    break;

                case "27":
                    cellTab.ActiveTab = Tab.Tab27;
                    break;

                case "31":
                    cellTab.ActiveTab = Tab.Tab31;
                    break;

                case "32":
                    cellTab.ActiveTab = Tab.Tab32;
                    break;

                case "33":
                    cellTab.ActiveTab = Tab.Tab33;
                    break;

                case "34":
                    cellTab.ActiveTab = Tab.Tab34;
                    break;

                case "35":
                    cellTab.ActiveTab = Tab.Tab35;
                    break;

                case "36":
                    cellTab.ActiveTab = Tab.Tab36;
                    break;

                case "37":
                    cellTab.ActiveTab = Tab.Tab37;
                    break;

                case "41":
                    cellTab.ActiveTab = Tab.Tab41;
                    break;

                case "42":
                    cellTab.ActiveTab = Tab.Tab42;
                    break;

                case "43":
                    cellTab.ActiveTab = Tab.Tab43;
                    break;


                case "44":
                    cellTab.ActiveTab = Tab.Tab44;
                    break;


                case "45":
                    cellTab.ActiveTab = Tab.Tab45;
                    break;


                case "46":
                    cellTab.ActiveTab = Tab.Tab46;
                    break;


                case "47":
                    cellTab.ActiveTab = Tab.Tab47;
                    break;

                default:
                    cellTab.ActiveTab = Tab.Tab11;
                    break;
            }

            return RedirectToAction(nameof(CellController.Index), cellTab);
        }
    }
}