namespace RealEstateOfficeMvc
{
    public class SearchSettings
    {
        public SearchSettings()
        {
            PageNumber = 0;
            PageSize = 50;
            IsDescending = true;
        }

        public ListSortOrder listSortOrder;
        public int PageCount;
        public int PageNumber;
        public int PageSize;
        public int TableSize;
        public bool IsDescending;

        public enum ListSortOrder
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