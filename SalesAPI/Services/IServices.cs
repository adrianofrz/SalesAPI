using SalesAPI.DbModel;
using System.Collections.Generic;

namespace SalesAPI.Services
{
    public interface IServices
    {        
        int Deletar(int id);
        List<Department> ListarTodos();
        Department ListarDetalhado(int department);
    }
}
