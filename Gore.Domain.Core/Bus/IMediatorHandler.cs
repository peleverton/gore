using Gore.Domain.Core.Commands;
using Gore.Domain.Core.Events;
using System.Threading.Tasks;

namespace Gore.Domain.Core.Bus
{
    public interface IMediatorHandler 
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
