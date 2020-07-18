using System;
using System.Collections.Generic;
using DocuHub.BOL;

namespace DocuHub.DAL
{

    public interface IRingBindersRepository
    {
        public List<RingBinder> GetAllRingBinders();
    }


}