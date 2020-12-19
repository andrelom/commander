using Commander.Extensions;
using Commander.Tests.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace Commander.Tests
{
    [TestFixture]
    public class HostBuilderExtensionsTestFixture
    {
        private IHost _host;

        [SetUp]
        public void Setup()
        {
            _host = new HostBuilder().UseCommander().Build();
        }

        [Test]
        public void UseCommanderTest()
        {
            _host.Services.GetService<ICommander>();
            _host.Services.GetService<EmptyController>();

            Assert.Pass();
        }
    }
}
