using blog.Models;
using Microsoft.EntityFrameworkCore;

namespace blog.Data;

public class ApplicationDBContext: DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
    {
        
    }
    
    public DbSet<Algorithm> Algorithms { get; set; }
    public DbSet<AlgoTag> AlgoTags { get; set; }
    public DbSet<Swallow> Swallow { get; set; }
    public DbSet<SwallowLink> SwallowLinks { get; set; }

}