using Chilicki.StarWars.Data.Helpers.Exceptions;

namespace Chilicki.StarWars.Data.Helpers.Paging
{
    public class Pager
    {
        public Pager(int? currentPage, int? pageSize)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
        }

        public int? CurrentPage { get; }
        public int? PageSize { get; }
        public int? EntitiesToSkip
        {
            get
            {
                if (CurrentPage == null || PageSize == null)
                    return null;
                return (CurrentPage - 1) * PageSize;
            }
        }
    }
}
