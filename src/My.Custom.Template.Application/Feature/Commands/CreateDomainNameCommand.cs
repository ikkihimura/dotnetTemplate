using MediatR;
using My.Custom.Template.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.Custom.Template.Application.Feature.Commands
{
    public record CreateDomainName(int id, string name) : IRequest<DomainNameDTO>;
}
