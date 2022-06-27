#nullable enable

using System.Reflection;
using Autofac;
using MediatR.Extensions.Autofac.DependencyInjection;
using Module = Autofac.Module;

namespace FPCS.Business.Autofac
{
    public class FpcsBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
