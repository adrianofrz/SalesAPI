using Microsoft.AspNetCore.Mvc;
using SalesAPI.DbModel;
using System.Collections.Generic;

namespace SalesAPI.Services
{
    public interface IApplication<T>
    {
        IActionResult Delete([FromRoute] int id);
        IActionResult Atualizar([FromRoute] int id, T value);
        [HttpGet]
        IActionResult ListarTodos();
        ActionResult ListarDetalhado(int id);
        IActionResult Cadastrar([FromBody] T value);

    }
}
