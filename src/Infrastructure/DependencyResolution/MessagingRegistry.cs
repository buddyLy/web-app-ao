using System;
using System.Configuration;
using Apache.NMS;
using StructureMap.Configuration.DSL;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Interfaces;
using Walmart.Assortment.AssortmentOptimizationSystem.Infrastructure.Messaging.Impl;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Infrastructure.DependencyResolution
{
    public class MessagingRegistry : Registry
    {
        public MessagingRegistry()
        {
            For<IConnectionFactory>().Singleton().Use(() => CreateConnectionFactory());
            For<IConnection>().Transient()
                .Use(ctx => ctx.GetInstance<IConnectionFactory>()
                    .CreateConnection(ConfigurationManager.AppSettings["MqUser"],
                        ConfigurationManager.AppSettings["MqPassword"]));
            For<ISession>().Transient()
                .Use(ctx => ctx.GetInstance<IConnection>()
                    .CreateSession());
            For<IDestination>().Transient()
                .Use(ctx => ctx.GetInstance<ISession>()
                    .GetDestination(ConfigurationManager.AppSettings["MqQueue"]));
            For<IMessageProducer>().Transient()
                .Use(ctx => ctx.GetInstance<ISession>()
                    .CreateProducer(ctx.GetInstance<IDestination>()));
            For<IMessageService>().Transient().Use<MessageService>();
        }

        private static IConnectionFactory CreateConnectionFactory()
        {
            var connectionUri = ConfigurationManager.AppSettings["MqConnectionUri"];
            var temp = new Uri(connectionUri);
            return new NMSConnectionFactory(temp);
        }
    }
}