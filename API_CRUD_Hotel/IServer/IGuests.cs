﻿using API_CRUD_Hotel.Repositories;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.IServer
{
    public interface IGuests : IRepository<Guests>
    {
        IEnumerable<Guests> GetAllGuests();
        Guests GetGuests(Guid GuestID);
        Task<Guests> AddGuestsAsync(Guests guests, CancellationToken cencellationToken = default);
        Task<bool> DeleteGuestsAsync(Guests guests, CancellationToken cencellationToken = default);
        Task<Guests> UpdateGuests(Guests guests, CancellationToken cencellationToken = default);
    }
}
