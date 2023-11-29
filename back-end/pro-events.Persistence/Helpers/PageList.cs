using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pro_events.Persistence.Helpers
{
    public class PageList<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public PageList(){}
        public PageList(List<T> items, int totalCount, int pageNumber, int pageSize)
        {
            CurrentPage = pageNumber;
            TotalCount = totalCount;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(totalCount / (double) pageSize);
            this.AddRange(items);
        }
        public static async Task<PageList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int PageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip(pageNumber - 1) .Take(PageSize).ToListAsync();
            return new PageList<T>(items, count, pageNumber, PageSize);
        }
    }
}
