using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bsa2er_MVC.Repositories
{
    public interface IRepository<T> where T:class
    {
         List<T> getAllItems();
         T FindById(int? id);
         void AddItem(T item);
         void EditItem(T item);
         void Remove(T item);
         int[] getInfo();
        void Dispose();
    }
}
