using System;
using AskMeWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace AskMeWeb.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
        }

        public DbSet<Question> Question { get; set; }

        public DbSet<Answer> Answer { get; set; }
    }
}

