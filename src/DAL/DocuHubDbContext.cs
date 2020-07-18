using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DocuHub.DAL
{

    public class DocuHubDbContext:DbContext
    {
        
        public DocuHubDbContext(DbContextOptions<DocuHubDbContext> options):base(options)
        {
            
        }

    }


}