using Microsoft.EntityFrameworkCore;
using SalesAPI.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public List<SalesRecord> ListaSimples(DateTime? dataMin, DateTime? dataMax)
        {
            List<SalesRecord> ret;// = new List<SalesRecord>();
            var result = from obj in _context.SalesRecord select obj;
            if (dataMin.HasValue)
            {
                result = result.Where(x => x.Date >= dataMin.Value);
            }
            if (dataMax.HasValue)
            {
                result = result.Where(x => x.Date <= dataMax.Value);
            }
            ret = result.Include(x => x.Sellers).Include(x => x.Sellers.Department).OrderByDescending(x => x.Date).ToList();            
            return ret;
        }

        public List<IGrouping<Department, SalesRecord>> ListarAgrupado(DateTime? dataMin, DateTime? dataMax)
        {
            if (!dataMin.HasValue)
            {
                dataMin = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!dataMax.HasValue)
            {
                dataMax = DateTime.Now;
            }
            
            
            var result = this.FindByDateGrouping(dataMin, dataMax);
            return result.ToList();
        }

        public List<IGrouping<Department, SalesRecord>> FindByDateGrouping(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }
            return result
                .Include(x => x.Sellers)
                .Include(x => x.Sellers.Department)
                .OrderByDescending(x => x.Date)
                .GroupBy(x => x.Sellers.Department)
                .ToList();
        }
    }
}
