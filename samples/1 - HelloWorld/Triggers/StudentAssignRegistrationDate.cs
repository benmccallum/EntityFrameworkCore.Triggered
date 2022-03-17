﻿using System;
using System.Threading;
using System.Threading.Tasks;
using EntityFrameworkCore.Triggered;

namespace PrimarySchool.Triggers
{
    public class StudentAssignRegistrationDate : IBeforeSaveTrigger<Student>
    {
        public Task BeforeSave(ITriggerContext<Student> context, CancellationToken cancellationToken)
        {
            if (context.ChangeType == ChangeType.Added)
            {
                context.Entity.RegistrationDate = DateTime.Today;
            }

            return Task.CompletedTask;
        }
    }
}
