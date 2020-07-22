using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bsa2er_MVC.Models;

namespace Bsa2er_MVC.Repositories
{
    
    public class VisitorRepository
    {
        private  static ApplicationDbContext db = new ApplicationDbContext();
        public static void AddVisitor(Visitor visitor)
        {
            var today = DateTime.Now.Date;
            //check visitor by day
            var v = db.Visitors.AsEnumerable().Any(a => a.IpAddress == visitor.IpAddress && a.DateTimeOfVisit.Date == today);
            if (!v)
            {
                db.Visitors.Add(visitor);
                db.SaveChanges();
            }
        }

        public static int[] getVisitors()
        {
            int[] arr = new int[2];
            var today = DateTime.Now.Date;
            var TodayVistors = db.Visitors.AsEnumerable().Where(v => v.DateTimeOfVisit.Date == today).Count();
            var AllVisitors = db.Visitors.Count();
            arr[0] = TodayVistors;
            arr[1] = AllVisitors;
            return arr;
        }
    }
}