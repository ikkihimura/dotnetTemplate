using My.Custom.Template.Application.DTOs;
using My.Custom.Template.Application.Feature.Interfaces;
using My.Custom.Template.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.Custom.Template.Application.Feature.Services
{
    public class DomainNameService : IDomainNameService
    {
       public Task<DomainNameDTO> CreateDomainName(DomainNameDTO DomainNamedto)
        {
            return Task.FromResult(DomainNamedto);
        }

       public Task<IList<ReadDomainName>> GetDomainNameList()
        {
            IList<ReadDomainName> list = new List<ReadDomainName>() {

                new ReadDomainName(1,"Bas1"),
                new ReadDomainName(2,"Bas2")

            };

            return Task.FromResult(list);

        }
    }
}
