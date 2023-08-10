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
        private DbSalesContext _context;
        public Seller Resposta;

        public SellerService(DbSalesContext context)
        {
            _context = context;
        }

        public SellerService()
        {
        }

        public int Atualizar(int id, [FromBody] VWDepartamentBase payload)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar([FromBody] Seller payload)
        {
            //Seller seller = new Seller { 
            //    Id = payload.Id, 
            //    Name = payload.Name,
            //    Email = payload.Email,
            //    Date = payload.Date,
            //    BaseSalary = payload.BaseSalary,
            //    DepartmentId = payload.DepartmentId
            //};

            _context.Seller.Add(payload);
            _context.SaveChanges();
            //this.Resposta = _context.Seller;
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

        public int Cadastrar([FromBody] VWDepartamentBase payload)
        {
            throw new NotImplementedException();
        }
    }
}
