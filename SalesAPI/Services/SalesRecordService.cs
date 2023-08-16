using SalesAPI.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

        public List<SalesRecord> ListarTodos(DateTime? dataMin, DateTime? dataMax)
        {
            List<SalesRecord> ret = new List<SalesRecord>();
            var result = from obj in _context.SalesRecord select obj;
            if (dataMin.HasValue)
            {
                result = result.Where(x => x.Date >= dataMin.Value);
            }
            if (dataMax.HasValue)
            {
                result = result.Where(x => x.Date <= dataMax.Value);
            }
            ret = result
                .Include(x => x.Sellers)
                .Include(x => x.Sellers.Department)
                .OrderByDescending(x => x.Date)
                .ToList();
            return ret;
        }
    }
}
