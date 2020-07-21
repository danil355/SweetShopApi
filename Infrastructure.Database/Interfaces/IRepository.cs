using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Database.Interfaces
{
    public interface IRepository<T> where T: class
    {
        T Get(int id);

        IList<T> GetAll();

        T Create(T entity);

        T Edit(T entity);
    }
}