using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeAssignment.Models
{
    public class LeadDetailsContext: DbContext
    {
        public LeadDetailsContext(DbContextOptions<LeadDetailsContext> options):base(options)
        {

        }

        public DbSet<LeadDetails> LeadDetails{ get; set; }
    }
}
