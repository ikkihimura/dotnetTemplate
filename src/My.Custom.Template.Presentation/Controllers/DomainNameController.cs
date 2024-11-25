using MediatR;
using Microsoft.AspNetCore.Mvc;
using My.Custom.Template.Application.DTOs;
using My.Custom.Template.Application.Feature.Commands;
using My.Custom.Template.Application.Feature.Queries;
using My.Custom.Template.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.Custom.Template.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DomainNameController : ControllerBase

    {
        private readonly IMediator _mediator;

        public DomainNameController(IMediator mediator)
        {

            _mediator = mediator;

        }

        [HttpGet]
        [Route("/")]

        public async Task<IList<ReadDomainName>> TestGetDomainName()
        {

            return await _mediator.Send(new QueryDomainName());

        }

        [HttpPost]
        public async Task<DomainNameDTO> TestCreateDomainName(CreateDomainName command)
        {
            var DomainNameT = await _mediator.Send(command);
            return DomainNameT;
        }
    }
   
}
