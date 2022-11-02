using Microsoft.EntityFrameworkCore;
using DRMusicRest.Model;

namespace DRMusicRest.DBContext
{
    public class RecordsContext : DbContext
    {
        public RecordsContext(DbContextOptions<RecordsContext> options)
            : base(options) { }

        public DbSet<Record> Classes { get; set; }
    }
}
