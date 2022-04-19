using EtsErosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EtsErosApi.Data
{
    public class DataContext : DbContext
    {
        public DbSet<TreeNode> TreeNodes { get; set; }
        public DataContext(DbContextOptions opts) : base(opts)
        { }
    }
}
