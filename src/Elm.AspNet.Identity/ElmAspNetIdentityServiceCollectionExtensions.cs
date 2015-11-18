﻿using System;
using Elm.AspNet.Identity;
using Microsoft.AspNet.Identity;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ElmAspNetIdentityServiceCollectionExtensions
    {
        public static IServiceCollection AddElmIdentity<TUser, TKey>(this IServiceCollection services)
            where TUser : IdentityUser<TUser, TKey>, new()
            where TKey : IEquatable<TKey>
        {
            services.AddScoped<IUserStore<TUser>, UserStore<TUser, TKey>>();
            services.AddScoped<IRoleStore<IdentityRole<TKey>>, RoleStore<IdentityRole<TKey>, TKey>>();
            return services;
        }

        public static IServiceCollection AddElmIdentity<TUser>(this IServiceCollection services)
            where TUser : IdentityUser<TUser, string>, new()
        {
            services.AddScoped<IUserStore<TUser>, UserStore<TUser>>();
            services.AddScoped<IRoleStore<IdentityRole>, RoleStore<IdentityRole>>();
            return services;
        }

        public static IServiceCollection AddElmIdentity(this IServiceCollection services)
        {
            services.AddScoped<IUserStore<IdentityUser>, UserStore<IdentityUser>>();
            services.AddScoped<IRoleStore<IdentityRole>, RoleStore<IdentityRole>>();
            return services;
        }
    }
}
