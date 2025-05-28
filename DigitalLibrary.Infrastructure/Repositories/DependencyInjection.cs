using DigitalLibrary.Core.Interfaces;
using DigitalLibrary.Data.Context;
using DigitalLibrary.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DigitalLibrary.Infrastructure.Repositories
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IBorrowRecordRepository, BorrowRecordRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IStatisticsService, StatisticsService>();
            services.AddScoped<IReviewRepository, ReviewRepository>();

            services.AddDbContext<LibraryDbContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }
    }
}
