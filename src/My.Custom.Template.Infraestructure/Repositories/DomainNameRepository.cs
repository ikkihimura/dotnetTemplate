using Intertech.Facade.DapperParameters;
using Microsoft.Extensions.Logging;
using My.Custom.Template.Infraestructure.Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.Custom.Template.Infraestructure.Repositories
{
    public class DomainNameRepository// Replace for name to use
    {
        private readonly ILogger<DomainNameRepository> _log;// Replace for name to use
        private readonly IConnectionWrapper _connectionWrapper;
        private IDapperParameters _parameters;
        public DomainNameRepository(ILogger<DomainNameRepository> logger,
                                   IDapperParameters parameters,
                                   IConnectionWrapper connectionWrapper)
        {
            _log = logger;
            _parameters = parameters;
            _connectionWrapper = connectionWrapper;

        }
    }
}
