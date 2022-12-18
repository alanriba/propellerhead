using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace propellerhead.utils.BusinessValidation.Models
{
	 
        [ExcludeFromCodeCoverage]
        public class SimpleErrorResponse
        {
            public int Status { get; set; }
            public string Message { get; set; }
            public IEnumerable<string> ValidationErrors { get; set; }
        }
    
}

