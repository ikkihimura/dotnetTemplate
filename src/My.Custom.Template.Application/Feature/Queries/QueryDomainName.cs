using MediatR;
using My.Custom.Template.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.Custom.Template.Application.Feature.Queries
{
    public record QueryDomainName() : IRequest<IList<ReadDomainName>>;
}
