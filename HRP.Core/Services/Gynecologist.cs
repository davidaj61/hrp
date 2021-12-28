using HRP.Core.Interfaces;
using HRP.DAL.Context;
using System;
using System.Collections.Generic;
using System.Text;
using HRP.DAL.Entities;

namespace HRP.Core.Services
{
    public class Gynecologist : IGynecologist
    {
        DatabaseContext _context;
        public Gynecologist(DatabaseContext context)
        {
            _context = context;
        }

        public bool Add(DAL.Entities.Gynecologist gynecologist)
        {
            _context.Entry(gynecologist).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _context.SaveChanges();
            return true;
        }

        public bool Update(DAL.Entities.Gynecologist gynecologist)
        {
            gynecologist.IsActive = false;
            _context.Entry(gynecologist).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
        }

        public IList<DAL.Entities.Gynecologist> GetAll()
        {
            throw new NotImplementedException();
        }

        
    }
}
