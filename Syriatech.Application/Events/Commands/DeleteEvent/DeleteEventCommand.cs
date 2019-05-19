

using MediatR;

namespace Syriatech.Application.Events.Commands.DeleteEvent
{
    public class DeleteEventCommand : IRequest
    {
        public int Id { get; set; }
    }
}
