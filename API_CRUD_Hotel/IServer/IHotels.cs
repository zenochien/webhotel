﻿using API_CRUD_Hotel.Repositories;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.IServer
{
    public interface IHotels:IRepository<Hotels>
    {
        IEnumerator<Hotels> GetHotels();
        Hotels GetHotels(Guid HotelID);
        Task<Hotels> AddHotels(Hotels hotels, CancellationToken cencellationToken = default);
        Task<bool> DeleteHotelsAsync(Hotels hotels, CancellationToken cencellationToken = default);
        Task<Hotels> UpdateHotelsAsync(Hotels hotels, CancellationToken cencellationToken = default);
    }
}
