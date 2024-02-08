// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.SecurityCompatiblity53.DataAccess.Contexts;
using EdFi.SecurityCompatiblity53.DataAccess.Repositories;
using FakeItEasy;
using Microsoft.Extensions.Configuration;
using Npgsql;
using NUnit.Framework;
using Shouldly;
using System.Data.Entity;

namespace EdFi.SecurityCompatibility53.DataAccess.IntegrationTests.Repositories.PostgreSQL
{
    public class DatabaseEngineDbConfiguration : DbConfiguration
    {
        public DatabaseEngineDbConfiguration()
        {
            const string name = "Npgsql";

            SetProviderFactory(
                providerInvariantName: name,
                providerFactory: NpgsqlFactory.Instance);

            SetProviderServices(
                providerInvariantName: name,
                provider: NpgsqlServices.Instance);

            SetDefaultConnectionFactory(connectionFactory: new NpgsqlConnectionFactory());
        }
    }

    /// <summary>
    /// This is a light-weight set of integration tests that only tries to prove
    /// that there is database connectivity without trying to carefully validate
    /// business logic.
    /// </summary>
    [TestFixture]
    public class SecurityRepositoryTests
    {
        private SecurityRepository _repository;

        [SetUp]
        public void Setup()
        {
            DbConfiguration.SetConfiguration(new DatabaseEngineDbConfiguration());

            var builder = new ConfigurationBuilder()
               .AddJsonFile($"appSettings.json", true, true);

            var config = builder.Build();
            var connectionString = config.GetConnectionString("PostgreSQL");

            var contextFactory = A.Fake<ISecurityContextFactory>();
            A.CallTo(() => contextFactory.CreateContext()).Returns(new PostgresSecurityContext(connectionString));

            _repository = new SecurityRepository(contextFactory);
        }

        [TestCase("GET", "Read")]
        [TestCase("POST", "Create")]
        [TestCase("PUT", "Update")]
        [TestCase("DELETE", "Delete")]
        public void GetActionByHttpVerb(string verb, string expected)
        {
            _repository.GetActionByHttpVerb(verb).ActionName.ShouldBe(expected);
        }

        [Test]
        public void GetAuthorizationStrategyByName()
        {
            _repository.GetAuthorizationStrategyByName("NoFurtherAuthorizationRequired").AuthorizationStrategyName.ShouldBe("NoFurtherAuthorizationRequired");
        }
    }
}