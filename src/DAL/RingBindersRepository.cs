using System;
using System.Collections.Generic;
using System.Linq;
using DocuHub.BOL;

namespace DocuHub.DAL
{
    public class RingBindersRepository:IRingBindersRepository
    {
        private readonly DocuHubDbContext _db;
        public RingBindersRepository(DocuHubDbContext dbContext)
        {
            _db = dbContext;
        }

        public List<RingBinder> GetAllRingBinders()
        {
            return _db.RingBinders.OrderByDescending(b => b.Pinned).ThenBy(b => b.Name).ToList();
        }
    }
}