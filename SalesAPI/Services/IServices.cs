using Microsoft.AspNetCore.Mvc;
using SalesAPI.DbModel;
using SalesAPI.ViewModel.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesAPI.Services
{
    public interface IServices
    {
        int Cadastrar([FromBody]VWDepartamentBase payload);
        int Deletar(int id);
        int Atualizar(int id, [FromBody]VWDepartamentBase payload);
        List<Department> ListarTodos();
        Department ListarDetalhado(int department);
    }
}
