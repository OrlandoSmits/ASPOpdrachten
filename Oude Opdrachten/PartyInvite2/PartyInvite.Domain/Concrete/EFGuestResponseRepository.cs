using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using PartyInvite.Domain.Abstract;
using PartyInvite.Domain.Entities;

namespace PartyInvite.Domain.Concrete
{
    public class EFGuestResponseRepository : IRepository
    {
        private EFDbContext _dbContext = new EFDbContext();
        public IEnumerable<GuestResponse> GuestResponses
        {
            get { return _dbContext.GuestResponses; }
        }

        public bool AddResponse(GuestResponse guestResponse)
        {
            //Set result to false
            bool result = false;

            //Check if email already used
            GuestResponse dbResponse = _dbContext.GuestResponses.FirstOrDefault(x => x.Email == guestResponse.Email);
            if (dbResponse != null)
            {
                //if guestResponse is the same the return wil be false 
                if (dbResponse.WillAttend != guestResponse.WillAttend)
                {
                    dbResponse.WillAttend = guestResponse.WillAttend;

                    //Tell EF that state is modified
                    _dbContext.Entry(dbResponse).State = EntityState.Modified;

                    result = true;
                }
            }
            else
            {
                _dbContext.GuestResponses.Add(guestResponse);
                result = true;
            }
            _dbContext.SaveChanges();

            return result;
        }
    }
}
