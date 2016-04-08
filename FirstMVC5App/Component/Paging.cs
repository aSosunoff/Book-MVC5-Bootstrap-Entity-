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

    //Специально добавленная модель для сортировки книг вместе с постраничным выводом
    public class Sort
    {
        public int sName { get; set; }
        public int sGanre { get; set; }
        public int sPrice { get; set; }
    }

    
    
    public static class SortRevers
    {
        public enum SortFormat
        {
            Asc = 0,
            Desc = 1
        }
        public static int Revers(this int sort)
        {
            return (int) (sort == (int) SortFormat.Asc ? SortFormat.Desc : SortFormat.Asc);
        }
    }

    public class PaginatorModelSort<T> : PaginatorModel<T> where T : class
    {
        public Sort Sortable { get; set; }
        public PaginatorModelSort(int pageSize, int currentPage, Sort sortModel, IEnumerable<T> items) : base(pageSize, currentPage, items)
        {
            if (sortModel == null)
            {
                Sortable = new Sort()
                {
                    sName = (int) SortRevers.SortFormat.Asc,
                    sGanre = (int) SortRevers.SortFormat.Asc,
                    sPrice = (int) SortRevers.SortFormat.Asc
                    //todo: сделать не принадлежащей к определённому типу
                };
            }
            else
                Sortable = sortModel;

        }
    }
}