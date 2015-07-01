﻿/// A PostgreSQL provider for (version 3 of) the ASP.NET Identity membership system
// For credits, copyright an license information refer to LICENSE.txt

using Microsoft.AspNet.Identity;
using AspNet.Identity.PostgreSQL;
using System;

namespace Microsoft.Framework.DependencyInjection
{
    public static class IdentityPostgreSQLBuilderExtensions
    {
        public static IdentityBuilder AddPostgreSQLStores<TDatabase>(this IdentityBuilder builder)
                    where TDatabase : PostgreSQLDatabase
        {
            builder.Services.TryAdd(IdentityPostgreSQLServices.GetDefaultServices(builder.UserType, builder.RoleType, typeof(TDatabase)));
            return builder;
        }

        public static IdentityBuilder AddPostgreSQLStores<TContext, TKey>(this IdentityBuilder builder)
            where TContext : PostgreSQLDatabase
            where TKey : IEquatable<TKey>
        {
            builder.Services.TryAdd(IdentityPostgreSQLServices.GetDefaultServices(builder.UserType, builder.RoleType, typeof(TContext), typeof(TKey)));
            return builder;
        }
    }
}