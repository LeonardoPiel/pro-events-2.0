using pro_events.Persistence.Helpers;


namespace pro_events.Persistence.Extensions
{
    public static class PageListExtensions
    {
        public static PageList<TSource> GetToSet<TSource, TDestination>(this PageList<TSource> source, PageList<TDestination> destination) where TSource : class where TDestination : class
        {
            destination.CurrentPage = source.CurrentPage;
            destination.TotalCount = source.TotalCount;
            destination.PageSize = source.PageSize;
            destination.TotalPages = source.TotalPages;
            return source;
        }
    }
}
