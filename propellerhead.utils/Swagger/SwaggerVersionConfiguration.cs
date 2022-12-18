using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Propellerhead.Utils.Swagger
{
    [ExcludeFromCodeCoverage]
    internal class SwaggerVersionConfiguration
    {
        public string Version { get; set; }
        public string EndpointUrl { get; set; }
        public string EndpointDescription { get; set; }
    }
}
