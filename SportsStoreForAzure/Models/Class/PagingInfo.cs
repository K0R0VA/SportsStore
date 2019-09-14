using System;

namespace SportsStoreForAzure.Models.Class
{
    public class PagingInfo
    {
        public int TotalItes { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages =>
            (int)Math.Ceiling((decimal)TotalItes / ItemsPerPage);
    }
}
