using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace FractalBookStore.Data.EF
{
    public class DbContextFactory
    {  // to get http scope
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DbContextFactory(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public StoreDBContext Create(Type reposytoryType)
        {   // request container
            var services = _httpContextAccessor.HttpContext.RequestServices;

            var dbContexts = services.GetService<Dictionary<Type, StoreDBContext>>();

            if(!dbContexts.ContainsKey(reposytoryType))
                dbContexts[reposytoryType] = services.GetService<StoreDBContext>();

            return dbContexts[reposytoryType];
        }
    }
}
