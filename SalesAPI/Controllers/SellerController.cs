using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using SalesAPI.DbModel;
using SalesAPI.Services;
using SalesAPI.Services.Response;


namespace SalesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase, IApplication<Seller>
    {
        private readonly DbSalesContext _context;

        public SellerController(DbSalesContext context)
        {
            _context = context;
        }

        // POST: api/Seller
        [HttpPost]
        public IActionResult Cadastrar([FromBody] Seller seller)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            SellerService sellerDB = new SellerService(_context);
            sellerDB.Cadastrar(seller);
            return Ok(new SellerResponse { Status = "Ok", Message = "Vendedor cadastrado!" });
        }

        // DELETE: api/Seller/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SellerService sellerDB = new SellerService(_context);
            int idDeletado = sellerDB.Deletar(id);
            if (idDeletado == -1)
                return BadRequest(ModelState);

            return Ok(new SellerResponse { Status = "Ok", Message = "Vendedor removido" });
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar([FromRoute] int id, Seller paylod)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SellerService sellerDB = new SellerService(_context);
            return Ok(sellerDB.Atualizar(id, paylod));
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SellerService sellerDB = new SellerService(_context);
            return Ok(sellerDB.ListarTodos());
        }
        [HttpGet("{id}")]
        public ActionResult ListarDetalhado(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            SellerService sellerDB = new SellerService(_context);
            return Ok(sellerDB.ListarDetalhado(id));
        }
    }
}