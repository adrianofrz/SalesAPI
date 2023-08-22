using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesAPI.DbModel;
using SalesAPI.Services;
using Newtonsoft.Json;

namespace SalesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesRecordController : ControllerBase, IApplication<SalesRecord>
    {
        private DbSalesContext _context;

        public SalesRecordController(DbSalesContext context)
        {
            _context = context;
        }

        public IActionResult Atualizar([FromRoute] int id, SalesRecord value)
        {
            throw new NotImplementedException();
        }

        public IActionResult Cadastrar([FromBody] SalesRecord value)
        {
            throw new NotImplementedException();
        }

        public IActionResult Delete([FromRoute] int id)
        {
            throw new NotImplementedException();
        }

        public ActionResult ListarDetalhado(int id)
        {
            throw new NotImplementedException();
        }
        
        [HttpGet]
        public IActionResult ListarTodos()
        {
            DateTime dataMin;
            DateTime dataMax;
            if (DateTime.TryParse(Request.Query["dataMinima"], out dataMin))
            {
                // Data é válida.
                dataMin = DateTime.Parse(Request.Query["dataMinima"]);
            }
            else
            {
                // Data é inválida.
                dataMin = new DateTime(DateTime.Now.Year, 1, 1);
            }

            if (DateTime.TryParse(Request.Query["dataMaxima"], out dataMax))
            {
                // Data é válida.
                dataMax = DateTime.Parse(Request.Query["dataMaxima"]);
            }
            else
            {
                // Data é inválida.
                dataMax = DateTime.Now;
            }

            SalesRecordService sales = new SalesRecordService(_context);
            //return Ok(JsonConvert.SerializeObject(sales.ListarTodos(dataMin, dataMax)));
            return Ok(sales.ListarTodos(dataMin, dataMax));
            //return Ok();
        }
    }
}