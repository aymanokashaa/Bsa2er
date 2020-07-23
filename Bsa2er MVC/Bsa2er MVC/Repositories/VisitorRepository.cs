using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bsa2er_MVC.Models;
using Microsoft.Ajax.Utilities;

namespace Bsa2er_MVC.Repositories
{
    
    public class VisitorRepository:IRepository<Visitor>
    {
        private readonly ApplicationDbContext db;// = new ApplicationDbContext();
        public VisitorRepository(ApplicationDbContext _db)
        {
            db = _db;
        }

        public int[] getInfo()
        {
            int[] arr = new int[2];
            var today = DateTime.Now.Date;
            var TodayVistors = db.Visitors.AsEnumerable().Where(v => v.DateTimeOfVisit.Date == today).Count();
            var AllVisitors = db.Visitors.Count();
            arr[0] = TodayVistors;
            arr[1] = AllVisitors;
            return arr;
        }

        public void AddItem(Visitor visitor)
        {
            var today = DateTime.Now.Date;
            //check visitor by day
            var v = db.Visitors.AsEnumerable().First(a => a.IpAddress == visitor.IpAddress && a.DateTimeOfVisit.Date == today);
            if (v==null)
            {
                db.Visitors.Add(visitor);
                db.SaveChanges();
            }
            if (db.Visitors.Count() > 10000)
            {
                db.Visitors.RemoveRange(db.Visitors.ToList());
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void EditItem(Visitor item)
        {
            throw new NotImplementedException();
        }

        public Visitor FindById(int? id)
        {
            throw new NotImplementedException();
        }

        public List<Visitor> getAllItems()
        {
            throw new NotImplementedException();
        }

        public void Remove(Visitor item)
        {
            throw new NotImplementedException();
        }
    }
}