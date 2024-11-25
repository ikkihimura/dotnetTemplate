using MediatR;
using My.Custom.Template.Application.DTOs;
using My.Custom.Template.Application.Feature.Commands;
using My.Custom.Template.Application.Feature.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.Custom.Template.Application.Feature.CommandHandlers
{
    public class CreateDomainNameHandler : IRequestHandler<CreateDomainName, DomainNameDTO>
    {
        private readonly IDomainNameService _DomainNameService;
        public CreateDomainNameHandler(IDomainNameService DomainNameService)
        {

            _DomainNameService = DomainNameService;
            //here goes all dependencies as services

        }
        public async Task<DomainNameDTO> Handle(CreateDomainName request, CancellationToken cancellationToken)
        {
            return await _DomainNameService.CreateDomainName(new DomainNameDTO(request.id, request.name));
        }
    }
}
