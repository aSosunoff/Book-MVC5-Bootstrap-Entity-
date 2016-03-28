using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstMVC5App.Model.Models;
using FirstMVC5App.Model.Repository.Interface;

namespace FirstMVC5App.Model.Repository.Entity
{
    public class HistoryRepository : CRUDRepository<APP_HISTORY, Entities>, IHistoryRepository
    {
        public HistoryRepository(Entities entities) : base(entities)
        {
        }
    }
}
