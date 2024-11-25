using MediatR;
using My.Custom.Template.Application.Feature.Interfaces;
using My.Custom.Template.Application.Feature.Queries;
using My.Custom.Template.Application.Feature.Services;
using My.Custom.Template.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.Custom.Template.Application.Feature.QueryHandlers
{
    public class QueryDomainNameHandler : IRequestHandler<QueryDomainName, IList<ReadDomainName>>
    {
        private readonly IDomainNameService _DomainNameService;
        public QueryDomainNameHandler(IDomainNameService DomainNameService)
        {

            _DomainNameService = DomainNameService;
            // here goes all the services

        }
        public async Task<IList<ReadDomainName>> Handle(QueryDomainName request, CancellationToken cancellationToken)
        {
            return await _DomainNameService.GetDomainNameList();
        }
    }
}
