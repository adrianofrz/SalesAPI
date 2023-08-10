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
            _context.Seller.Add(payload);
            _context.SaveChanges();            
        }

        public int Deletar(int id)
        {
            var seller = _context.Seller.Find(id);
            if (seller == null)
                return -1;

            _context.Remove(seller);
            _context.SaveChanges();
            return id;
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
