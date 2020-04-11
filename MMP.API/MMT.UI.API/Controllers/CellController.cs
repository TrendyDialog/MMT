using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMT.Domain.Core.Notifications;
using MMT.Service.Interfaces;
using MMT.Service.ViewModels;
using Serilog;
using System;
using System.Collections.Generic;

namespace MMT.UI.API.Controllers
{

    [Produces("application/json")]
    [Route("api/Cell")]
    public class CellController : ControllerBase
    {
        private readonly ICellService cellService;

        public CellController(ICellService cellService, IDomainNotificationHandler<DomainNotification> notifications)
        {
            this.cellService = cellService;
        }

        [HttpGet("DashBoard")]
        public ActionResult Index()
        {
            return Ok();
        }

        [HttpGet("Details")]
        public ActionResult Details(int id)
        {
            return Ok();
        }

        [HttpGet("CellList")]
        public IActionResult GetAll()
        {
            try
            {
                List<CellViewModel> cells;

                cells = new List<CellViewModel>(cellService.GetAll());

                return Ok(cells);
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public IActionResult GetCellByName(string cellName)
        {
            try
            {
                var cellData = cellService.GetCellByName(cellName);
                return Ok(cellData);
            }
            catch(Exception e)
            {
                Log.Error(e.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Route("AddCell")]
        public IActionResult AddCell([FromBody]CellViewModel cellViewModel)
        {
            try
            {
                cellService.Add(cellViewModel);
                return StatusCode(StatusCodes.Status201Created, cellViewModel);
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("UpdateCell")]
        public IActionResult UpdateCell([FromBody]CellViewModel cellViewModel)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            try
            {                
                cellService.Update(cellViewModel);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}