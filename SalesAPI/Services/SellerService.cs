using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesAPI.DbModel;
using SalesAPI.ViewModel.Request;

namespace SalesAPI.Services
{
    public class SellerService : IServices
    {
        public int Atualizar(int id, [FromBody] VWDepartamentBase payload)
        {
            throw new NotImplementedException();
        }

        public int Cadastrar([FromBody] VWDepartamentBase payload)
        {
            throw new NotImplementedException();
        }

        public int Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public Department ListarDetalhado(int department)
        {
            throw new NotImplementedException();
        }

        public List<Department> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
