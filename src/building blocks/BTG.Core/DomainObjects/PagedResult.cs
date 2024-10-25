using System.Collections.Generic;

namespace BTG.Core.DomainObjects
{
    public class PagedResult<T> where T : class
    {
        public IEnumerable<T> List { get; set; }
        public int TotalResults { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Nome { get; set; }
        public double TotalPages => Math.Ceiling((double)TotalResults / PageSize);
        public PagedResult()
        {
            TotalResults = 0;
            PageIndex = 1;
            PageSize = 0;
        }
    }
}
