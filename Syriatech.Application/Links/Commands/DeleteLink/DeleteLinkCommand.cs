

using MediatR;

namespace Syriatech.Application.Links.Commands.DeleteLink
{
    public class DeleteLinkCommand : IRequest
    {
        public int Id { get; set; }
    }
}
