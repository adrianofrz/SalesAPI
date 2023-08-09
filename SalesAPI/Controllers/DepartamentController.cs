using Microsoft.AspNetCore.Mvc;
using SalesAPI.DbModel;
using SalesAPI.Services;
using SalesAPI.Services.Response;
using SalesAPI.ViewModel.Request;

namespace SalesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentController : ControllerBase
    {
        private DbSalesContext _context;
        public DepartamentController(DbSalesContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult Cadastrar([FromBody]VWDepartamentBase payload)
        {
            DepartmentService departament = new DepartmentService(_context);
            return Ok(new DepartmentServiceResponse { Id = departament.Cadastrar(payload) });
        }
        [HttpDelete ("{departamentoId}")]
        public ActionResult Deletar(int departamentoId)
        {
            DepartmentService departament = new DepartmentService(_context);
            DepartmentServiceResponse dsr = new DepartmentServiceResponse { Id = departament.Deletar(departamentoId) };
            return Ok(dsr);
        }
        [HttpPut("{departamentoId}")]
        public ActionResult Atualizar(int departamentoId, [FromBody]VWDepartamentBase payload)
        {
            DepartmentService departament = new DepartmentService(_context);
            return Ok(new DepartmentServiceResponse { Nome = payload.NomeDepartamento, Id = departament.Atualizar(departamentoId,payload) });
        }
        [HttpGet (Name = "listarTodos")]
        public ActionResult ListarTodos()
        {
            DepartmentService departments = new DepartmentService(_context);
            return Ok(departments.ListarTodos());
        }
        [HttpGet ("{departamentoId}")]
        public ActionResult ListarDetalhado(int departamentoId)
        {
            DepartmentService departments = new DepartmentService(_context);
            return Ok(departments.ListarDetalhado(departamentoId));
        }
    }
}