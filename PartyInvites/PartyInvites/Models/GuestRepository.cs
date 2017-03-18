using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartyInvites.Models
{
    public class GuestRepository : IGuestRepository
    {
        private List<GuestResponse> _guestResponses = new List<GuestResponse>();
        public IEnumerable<GuestResponse> GetAllResponses()
        {

            return _guestResponses;
        }

        public bool AddResponse(GuestResponse guestResponse)
        {
            _guestResponses.Add(guestResponse);
            return true;
        }
    }
}