using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkCore.Triggered.Infrastructure;
using EntityFrameworkCore.Triggered.Infrastructure.Internal;
using EntityFrameworkCore.Triggered.Lifecycles;
using EntityFrameworkCore.Triggered.Lifecycles.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Xunit;

namespace EntityFramework.Triggered.Lifecycles.Tests.Extensions
{
    public class TriggersContextOptionsBuilderExtensionsTests
    {
        [Fact]
        public void UseLifecyleBeforeSaveStartingTriggers_AddsTriggerType()
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder();
            var subject = new TriggersContextOptionsBuilder(dbContextOptionsBuilder);
            
            subject.UseLifecyleBeforeSaveStartingTriggers();

            var extension = dbContextOptionsBuilder.Options.GetExtension<TriggersOptionExtension>();
            Assert.NotNull(extension);
            Assert.Single(extension.TriggerTypes);
            Assert.Equal(typeof(IBeforeSaveStartingTrigger), extension.TriggerTypes.First());
        }

        [Fact]
        public void UseLifecyleBeforeSaveStartedTriggers_AddsTriggerType()
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder();
            var subject = new TriggersContextOptionsBuilder(dbContextOptionsBuilder);

            subject.UseLifecyleBeforeSaveStartedTriggers();

            var extension = dbContextOptionsBuilder.Options.GetExtension<TriggersOptionExtension>();
            Assert.NotNull(extension);
            Assert.Single(extension.TriggerTypes);
            Assert.Equal(typeof(IBeforeSaveStartedTrigger), extension.TriggerTypes.First());
        }

        [Fact]
        public void UseLifecyleAfterSaveStartingTriggers_AddsTriggerType()
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder();
            var subject = new TriggersContextOptionsBuilder(dbContextOptionsBuilder);

            subject.UseLifecyleAfterSaveStartingTriggers();

            var extension = dbContextOptionsBuilder.Options.GetExtension<TriggersOptionExtension>();
            Assert.NotNull(extension);
            Assert.Single(extension.TriggerTypes);
            Assert.Equal(typeof(IAfterSaveStartingTrigger), extension.TriggerTypes.First());
        }

        [Fact]
        public void UseLifecyleAfterSaveStartedTriggers_AddsTriggerType()
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder();
            var subject = new TriggersContextOptionsBuilder(dbContextOptionsBuilder);

            subject.UseLifecyleAfterSaveStartedTriggers();

            var extension = dbContextOptionsBuilder.Options.GetExtension<TriggersOptionExtension>();
            Assert.NotNull(extension);
            Assert.Single(extension.TriggerTypes);
            Assert.Equal(typeof(IAfterSaveStartedTrigger), extension.TriggerTypes.First());
        }

        [Fact]
        public void UseLifecyleTriggers_AddsTriggerTypes()
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder();
            var subject = new TriggersContextOptionsBuilder(dbContextOptionsBuilder);

            subject.UseLifecyleTriggers();

            var extension = dbContextOptionsBuilder.Options.GetExtension<TriggersOptionExtension>();
            Assert.NotNull(extension);
            Assert.Equal(4, extension.TriggerTypes.Count());
            Assert.Contains(typeof(IBeforeSaveStartingTrigger), extension.TriggerTypes);
            Assert.Contains(typeof(IBeforeSaveStartedTrigger), extension.TriggerTypes);
            Assert.Contains(typeof(IAfterSaveStartingTrigger), extension.TriggerTypes);
            Assert.Contains(typeof(IAfterSaveStartedTrigger), extension.TriggerTypes);
        }
    }
}
