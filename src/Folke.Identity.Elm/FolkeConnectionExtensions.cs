﻿using System;
using Folke.Elm;

namespace Folke.Identity.Elm
{
    public static class FolkeConnectionExtensions
    {
        /// <summary>
        /// Creates the table for a default identity with a string a the key
        /// </summary>
        /// <param name="folkeConnection"></param>
        public static void UpdateStringIdentityUserSchema(this IFolkeConnection folkeConnection)
        {
            folkeConnection.CreateOrUpdateTable<IdentityUser>();
            folkeConnection.CreateOrUpdateTable<IdentityUserClaim<IdentityUser, string>>();
            folkeConnection.CreateOrUpdateTable<IdentityUserLogin<IdentityUser, string>>();
        }

        /// <summary>
        /// Creates the table for an identity of type TUser
        /// </summary>
        /// <typeparam name="TUser"></typeparam>
        /// <param name="folkeConnection"></param>
        public static void UpdateStringIdentityUserSchema<TUser>(this IFolkeConnection folkeConnection) 
            where TUser : IdentityUser<TUser, string>, new()
        {
            folkeConnection.CreateOrUpdateTable<TUser>();
            folkeConnection.CreateOrUpdateTable<IdentityUserClaim<TUser, string>>();
            folkeConnection.CreateOrUpdateTable<IdentityUserLogin<TUser, string>>();
        }

        public static void UpdateStringIdentityRoleSchema(this IFolkeConnection folkeConnection)
        {
            folkeConnection.CreateOrUpdateTable<IdentityRole>();
            folkeConnection.CreateOrUpdateTable<IdentityUserRole<IdentityUser, string>>();
            folkeConnection.CreateOrUpdateTable<IdentityRoleClaim<string>>();
        }

        public static void UpdateIdentityUserSchema<TKey>(this IFolkeConnection folkeConnection)
            where TKey: IEquatable<TKey>
        {
            folkeConnection.CreateOrUpdateTable<IdentityUser<TKey>>();
            folkeConnection.CreateOrUpdateTable<IdentityUserClaim<IdentityUser<TKey>, TKey>>();
            folkeConnection.CreateOrUpdateTable<IdentityUserLogin<IdentityUser<TKey>, TKey>>();
        }

        public static void UpdateIdentityUserSchema<TKey, TUser>(this IFolkeConnection folkeConnection)
            where TUser: IdentityUser<TUser, TKey>, new()
            where TKey: IEquatable<TKey>
        {
            folkeConnection.CreateOrUpdateTable<TUser>();
            folkeConnection.CreateOrUpdateTable<IdentityUserClaim<TUser, TKey>>();
            folkeConnection.CreateOrUpdateTable<IdentityUserLogin<TUser, TKey>>();
        }

        public static void UpdateIdentityRoleSchema<TKey, TUser>(this IFolkeConnection folkeConnection)
            where TKey: IEquatable<TKey>
            where TUser: IdentityUser<TUser, TKey>
        {
            folkeConnection.CreateOrUpdateTable<IdentityRole<TKey>>();
            folkeConnection.CreateOrUpdateTable<IdentityUserRole<TUser, TKey>>();
            folkeConnection.CreateOrUpdateTable<IdentityRoleClaim<TKey>>();
        }

        public static void UpdateIdentityRoleSchema<TKey, TUser, TRole>(this IFolkeConnection folkeConnection)
            where TKey : IEquatable<TKey>
            where TUser : IdentityUser<TUser, TKey>
            where TRole : IdentityRole<TKey>, new()
        {
            folkeConnection.CreateOrUpdateTable<TRole>();
            folkeConnection.CreateOrUpdateTable<IdentityUserRole<TUser, TKey>>();
            folkeConnection.CreateOrUpdateTable<IdentityRoleClaim<TKey>>();
        }
    }
}
