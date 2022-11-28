﻿namespace Hamroh_V2.Domain.Configurations
{
    public class PaginationParameters
    {
        private int _pageIndex;
        private int _pageSize;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value is < 0 or > 100 ? 100 : value;
        }

        public int PageIndex
        {
            get => _pageIndex;
            set => _pageIndex = value < 1 ? 1 : value;
        }
    }
}
