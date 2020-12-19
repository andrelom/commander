using System.Threading.Tasks;
using Commander.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace Commander.Tests
{
    [TestFixture]
    public class CommanderTestFixture
    {
        private IHost _host;
        private ICommander _commander;

        [SetUp]
        public void Setup()
        {
            _host = new HostBuilder().UseCommander().Build();
            _commander = _host.Services.GetService<ICommander>();
        }

        [Test]
        public async Task InvokeAsyncTest()
        {
            await _commander.InvokeAsync("chat new room chiral \"The Chiral discussion room.\"");

            Assert.Pass();
        }
    }
}
