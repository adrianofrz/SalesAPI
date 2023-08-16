using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesAPI.DbModel;
using SalesAPI.Services;

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
            DateTime dataMin = DateTime.Parse(Request.Query["dataMinima"]);
            DateTime dataMax = DateTime.Parse(Request.Query["dataMaxima"]);

            SalesRecordService sales = new SalesRecordService(_context);
            return Ok(sales.ListarTodos(dataMin, dataMax));
        }
    }
}