using System;
namespace Propellerhead.Utils.BusinessValidation.Models
{
    public sealed class ValidationError
    {
        public string Message { get; }
        public int? TypeId { get; }

        public ValidationError(string message, int? typeId = null)
        {
            Message = message;
            TypeId = typeId;
        }
    }
}

