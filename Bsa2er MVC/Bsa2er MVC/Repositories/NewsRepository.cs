using Bsa2er_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Bsa2er_MVC.Repositories
{
    public class NewsRepository:IRepository<news>
    {
        readonly ApplicationDbContext _db;
        public NewsRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public List<news> getAllItems()
        {
            return _db.News.ToList();
        }
        public news FindById(int? id)
        {
            return _db.News.Find(id);
        }
        public void AddItem(news news)
        {
            _db.News.Add(news);
            _db.SaveChanges();
        }
        public void EditItem(news news)
        {
            _db.Entry(news).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Remove(news item)
        {
            _db.News.Remove(item);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public int[] getInfo()
        {
            throw new NotImplementedException();
        }
    }
}