using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartyInvites.Models
{
    public interface IGuestRepository
    {
        IEnumerable<GuestResponse> GetAllResponses();

        bool AddResponse(GuestResponse guestResponse);
    }
}