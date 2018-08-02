using HotelManagement.Common;
using System;
using System.Collections.Generic;

namespace HotelManagement.Contracts
{
    public interface IAccomodationProperty
    {
        int Capacity { get; }
        int Beds { get; }
        decimal BasePrice { get; }
        bool ForSmokers { get; }
        ViewType View { get; }
        List<DateTime> NotAvailable { get; }
        List<IExtra> ListOfExtras { get; }
        decimal CalculatePrice();
        void AddExtra(IExtra extra);

    }
}
