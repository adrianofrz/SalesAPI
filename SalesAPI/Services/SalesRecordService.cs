using SalesAPI.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesAPI.Services
{
    public class SalesRecordService
    {
        private DbSalesContext _context;

        public SalesRecordService(DbSalesContext context)
        {
            _context = context;
        }

        public SalesRecordService()
        {
        }

        public List<SalesRecord> ListarTodos()
        {
            return _context.SalesRecord.ToList();
        }
    }
}
