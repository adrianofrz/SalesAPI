using Microsoft.AspNetCore.Mvc;
using SalesAPI.DbModel;
using SalesAPI.Services.Response;
using SalesAPI.ViewModel.Request;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesAPI.Services
{
    public class SellerService
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

        public SellerResponse Atualizar(int id, Seller payload)
        {
            bool temDado = _context.Seller.Any(bd => bd.Id == id);
            if(temDado == false)
                return new SellerResponse { Status = "Nok", Message = "Nao consegui completar a sua solicitação! :(" };
            payload.Id = id;
            _context.Seller.Update(payload);
            _context.SaveChanges();
            return new SellerResponse { Status = "Ok", Message = "Cadastro atualizado!" };
        }

        public SellerResponse Cadastrar([FromBody] Seller payload)
        {
            bool temDado = _context.Seller.Any(bd => bd.Name == payload.Name);
            if (temDado == false)
                return new SellerResponse { Status = "Nok", Message = "Nao consegui completar a sua solicitação! :(" };
            _context.Seller.Add(payload);
            _context.SaveChanges();
            return new SellerResponse { Status = "Ok", Message = "Cadastro efetuado!" };
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

        public List<Seller> ListarTodos()
        {
            return _context.Seller.ToList();
        }
    }
}
