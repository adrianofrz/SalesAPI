using Microsoft.AspNetCore.Mvc;
using SalesAPI.DbModel;
using SalesAPI.ViewModel.Request;
using System.Collections.Generic;
using System.Linq;

namespace SalesAPI.Services
{
    public class DepartmentService
    {
        private readonly DbSalesContext _context;
        public DepartmentService(DbSalesContext context)
        {
            _context = context;
        }

        public DepartmentService()
        {
        }

        public int Cadastrar([FromBody] VWDepartamentBase payload)
        {
            //throw new NotImplementedException();
            Department departmentDb = new Department { Name = payload.NomeDepartamento};
            _context.Department.Add(departmentDb);
            _context.SaveChanges();

            return departmentDb.Id;
        }

        public int Deletar(int id)
        {
            var department = _context.Department.Find(id);
            _context.Department.Remove(department);
            _context.SaveChanges();
            return department.Id;
        }

        public int Atualizar(int id, [FromBody] VWDepartamentBase payload)
        {
            //var department = _context.Department.Find(id);
            var department = new Department { Id = id, Name = payload.NomeDepartamento };
            _context.Department.Update(department);
            _context.SaveChanges();
            return department.Id;
        }

        public List<Department> ListarTodos()
        {
            return _context.Department.ToList();
        }

        public Department ListarDetalhado(int id)
        {
            Department department = new Department();
            department = _context.Department.FirstOrDefault(departamento => departamento.Id == id);

            if(department == null)
            {
                return new Department { Id = -1, Name = "Departamento Invalido" };
            }

            return department;
        }
    }
}
