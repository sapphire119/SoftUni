﻿using Forum.Data;
using Forum.Services.Contracts;

using Microsoft.EntityFrameworkCore;

namespace Forum.Services
{
    public class DatabaseInitializerService : IDatabaseInitializerService
    {
        private readonly ForumDbContext context;

        public DatabaseInitializerService(ForumDbContext context)
        {
            this.context = context;
        }

        public void InitializerDatabase()
        {
            context.Database.Migrate();
        }
    }
}
