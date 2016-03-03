using System;
using System.Collections.Generic;
using PartyInvite.Domain.Entities;


namespace PartyInvite.Domain.Abstract
{
    public interface IRepository
    {
        IEnumerable<GuestResponse> GuestResponses { get; }
        bool AddResponse(GuestResponse guestResponse);
    }
}