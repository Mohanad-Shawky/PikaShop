namespace PikaShop.Admin.Helpers.Pagination
{
    public static class PaginationUtility
    {
        public static PaginatedList<T>? ToPaginatedList<T>(
            this IQueryable<T> query,
            int pageNumber,
            int pageSize) where T : class
        {
            var totalCount = query.Count();

            var entities = query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            return new PaginatedList<T>([.. entities],
                                   totalCount,
                                   pageNumber,
                                   pageSize);
        }
    }
}
