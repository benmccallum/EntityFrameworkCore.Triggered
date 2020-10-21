using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EntityFrameworkCore.Triggered;
using EntityFrameworkCore.Triggered.Lifecycles.Extensions;
using EntityFrameworkCore.Triggered.Lifecycles.Tests.Stubs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Xunit;

namespace EntityFrameworkCore.Triggered.Lifecycles.Tests
{
    public class TriggerSessionExtensionsTests
    {
        class TestModel
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
        }

        class TestDbContext : DbContext
        {
            public TriggerStub TriggerStub { get; } = new TriggerStub();

            public DbSet<TestModel> TestModels { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                base.OnConfiguring(optionsBuilder);

                optionsBuilder.UseInMemoryDatabase("test");
                optionsBuilder.EnableServiceProviderCaching(false);
                optionsBuilder.UseTriggers(triggerOptions => {
                    triggerOptions
                        .AddTrigger(TriggerStub)
                        .UseLifecyleTriggers();
                });
            }
        }

        protected static ITriggerSession CreateSession(DbContext context)
            => context.Database.GetService<ITriggerService>().CreateSession(context);

        [Fact]
        public async Task RaiseBeforeSaveStartingTriggers_RaisesOnce()
        {
            using var context = new TestDbContext();
            var session = CreateSession(context);

            session.DiscoverChanges();
            await session.RaiseBeforeSaveStartingTriggers();

            Assert.Equal(1, context.TriggerStub.BeforeSaveStartingInvocations);
        }

        [Fact]
        public async Task RaiseBeforeSaveStartedTriggers_RaisesOnce()
        {
            using var context = new TestDbContext();
            var session = CreateSession(context);

            session.DiscoverChanges();
            await session.RaiseBeforeSaveStartedTriggers();

            Assert.Equal(1, context.TriggerStub.BeforeSaveStartedInvocations);
        }

        [Fact]
        public async Task RaiseAfterSaveStartingTriggers_RaisesOnce()
        {
            using var context = new TestDbContext();
            var session = CreateSession(context);

            session.DiscoverChanges();
            await session.RaiseAfterSaveStartingTriggers();

            Assert.Equal(1, context.TriggerStub.AfterSaveStartingInvocations);
        }

        [Fact]
        public async Task RaiseAfterSaveStartedTriggers_RaisesOnce()
        {
            using var context = new TestDbContext();
            var session = CreateSession(context);

            session.DiscoverChanges();
            await session.RaiseAfterSaveStartedTriggers();

            Assert.Equal(1, context.TriggerStub.AfterSaveStartedInvocations);
        }

        [Fact]
        public async Task RaiseBeforeSaveStartingTriggers_RaisesOnceOnSimpleAddition()
        {
            using var context = new TestDbContext();
            var session = CreateSession(context);

            context.TestModels.Add(new TestModel {
                Id = Guid.NewGuid(),
                Name = "test1"
            });

            session.DiscoverChanges();
            await session.RaiseBeforeSaveStartingTriggers();

            Assert.Equal(1, context.TriggerStub.BeforeSaveStartingInvocations);
        }


        [Fact]
        public async Task RaiseBeforeSaveStartedTriggers_RaisesOnceOnSimpleAddition()
        {
            using var context = new TestDbContext();
            var session = CreateSession(context);

            context.TestModels.Add(new TestModel {
                Id = Guid.NewGuid(),
                Name = "test1"
            });

            session.DiscoverChanges();
            await session.RaiseBeforeSaveStartedTriggers();

            Assert.Equal(1, context.TriggerStub.BeforeSaveStartedInvocations);
        }


        [Fact]
        public async Task RaiseAfterSaveStartingTriggers_RaisesOnceOnSimpleAddition()
        {
            using var context = new TestDbContext();
            var session = CreateSession(context);

            context.TestModels.Add(new TestModel {
                Id = Guid.NewGuid(),
                Name = "test1"
            });

            session.DiscoverChanges();
            await session.RaiseAfterSaveStartingTriggers();

            Assert.Equal(1, context.TriggerStub.AfterSaveStartingInvocations);
        }


        [Fact]
        public async Task RaiseAfterSaveStartedTriggers_RaisesOnceOnSimpleAddition()
        {
            using var context = new TestDbContext();
            var session = CreateSession(context);

            context.TestModels.Add(new TestModel {
                Id = Guid.NewGuid(),
                Name = "test1"
            });

            session.DiscoverChanges();
            await session.RaiseAfterSaveStartedTriggers();

            Assert.Equal(1, context.TriggerStub.AfterSaveStartedInvocations);
        }
    }
}
