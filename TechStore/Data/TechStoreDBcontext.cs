using Microsoft.EntityFrameworkCore;

namespace TechStore.Data
{
    public class AppDBcontext : DbContext
    {
        public AppDBcontext(DbContextOptions<AppDBcontext> options)
            : base(options)
        {
        }
    }
}
