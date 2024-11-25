using My.Custom.Template.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.Custom.Template.Domain.Events
{
    public class DomainNameCreated : DomainNameModel
    {
        public DomainNameCreated(int id, string name) : base(id, name)
        {

        }
    }
}
