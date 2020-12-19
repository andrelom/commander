using System.Threading.Tasks;

namespace Commander
{
    public interface ICommander
    {
        Task InvokeAsync(string input);
    }
}
