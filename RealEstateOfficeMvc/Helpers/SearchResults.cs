namespace RealEstateOfficeMvc
{
    public class SearchResults
    {
        public SearchResults()
        {
            PageNumber = 0;
            PageSize = 50;
            IsDescending = true;
        }

        public ResultsSortOrder resultsSortOrder;
        public int PageCount;
        public int PageNumber;
        public int PageSize;
        public int TableSize;
        public bool IsDescending;

        public enum ResultsSortOrder
        {
            Id = 0,
            Data = 1,
            Typ = 2,
            Nazwisko = 4,
            Adres = 5,
            Cena = 6,
            Powierzchnia = 7

        }
    }
}