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

        [HttpPost]
        public IActionResult Cadastrar([FromBody] SalesRecord value)
        {
            SalesRecordService sale = new SalesRecordService(_context);
            return Ok(sale.Cadastrar(value));
        }

        public IActionResult Delete([FromRoute] int id)
        {
            throw new NotImplementedException();
        }
        [HttpGet("{Id}")]
        public ActionResult ListarDetalhado(int id)
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
            return Ok(sales.ListarAgrupado(dataMin, dataMax));
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
            return Ok(sales.ListaSimples(dataMin, dataMax));            
        }
    }
}