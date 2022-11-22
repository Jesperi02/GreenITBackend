using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace GreenITASPNetCore.Models
{
    public class FileContext : DbContext
    {
        public FileContext(DbContextOptions<FileContext> options)
            : base(options)
        {
        }

        public DbSet<TextFile> TextFiles { get; set; } = null!;
    }
}