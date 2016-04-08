using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstMVC5App.Component
{
    public class Paging
    {
        public int CurrentNumberPage { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPage { get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); } }
    }

    public class PaginatorModel<T> where T : class
    {
        public T Element { get { return Items.FirstOrDefault(); } }
        public IEnumerable<T> Items { get; set; }
        public Paging Paginator { get; set; }

        public PaginatorModel(int pageSize, int currentPage, IEnumerable<T> items)
        {
            Items = items.Skip((currentPage - 1) * pageSize).Take(pageSize);
            //todo: пердусмотреть null
            Paginator = new Paging()
            {
                CurrentNumberPage = currentPage,
                PageSize = pageSize,
                TotalItems = items.Count()
            };
        }
    }
}