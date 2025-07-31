using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace medical
{
    interface IRepository<T>
    {
        int Delete(T entity);

        int Update(T entity);

        int Add(T entity);

        ObservableCollection<T> GetAll();

    }
}
