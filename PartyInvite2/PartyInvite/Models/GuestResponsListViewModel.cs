using System;
using System.Collections.Generic;
using PartyInvite.Domain.Entities;
using PartyInvite.WebUI.Models;

namespace PartyInvite.WebUI.Models
{
    public class GuestResponseListViewModel
    {
        public IEnumerable<GuestResponse> GuestResponses { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public bool? CurrentCategory { get; set; }
    }
}