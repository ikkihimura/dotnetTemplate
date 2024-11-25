using My.Custom.Template.Application.DTOs;
using My.Custom.Template.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.Custom.Template.Application.Feature.Interfaces
{
    public interface IDomainNameService
    {
        public Task<DomainNameDTO> CreateDomainName(DomainNameDTO DomainNamedto);

        public Task<IList<ReadDomainName>> GetDomainNameList();

    }
}
