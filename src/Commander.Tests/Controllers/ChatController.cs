using Commander.Attributes;
using NUnit.Framework;

namespace Commander.Tests.Controllers
{
    [Command("chat")]
    public class ChatController : Controller
    {
        [Command("new room")]
        public void NewRoom(string name, string description)
        {
            Assert.IsNotEmpty(name);
            Assert.IsNotEmpty(description);
        }
    }
}
