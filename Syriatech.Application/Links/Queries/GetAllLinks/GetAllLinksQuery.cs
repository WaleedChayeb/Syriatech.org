using MediatR; 

namespace Syriatech.Application.Links.Queries.GetAllLinks
{
    public class GetAllLinksQuery : IRequest<LinksListViewModel>
    {
        public string Username { get; set; }
    }
}
