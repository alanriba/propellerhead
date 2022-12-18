using System;
using Propellerhead.Utils.BusinessValidation.Models;
using System.Collections.Generic;
using System.Linq;

namespace propellerhead.utils.BusinessValidation.Models
{
    public class BusinessResult<T> : IBusinessResult<T>
    {
        private readonly List<ValidationError> validationErrors = new List<ValidationError>();
        private T value;

        public bool IsValid()
        {
            return validationErrors.Count == 0;
        }

        public bool HasValue()
        {
            return value != null;
        }

        public void AddError(string errorMessage)
        {
            if (IsValidErrorMessage(errorMessage))
            {
                validationErrors.Add(new ValidationError(errorMessage));
            }
        }

        public void AddError(string errorMessage, int? errorTypeId = null)
        {
            if (IsValidErrorMessage(errorMessage))
            {
                validationErrors.Add(new ValidationError(errorMessage, errorTypeId));
            }
        }

        public void AddErrors(IEnumerable<string> errorMessages)
        {
            validationErrors.AddRange(
                errorMessages
                .ToList()
                .FindAll(errorMessage => IsValidErrorMessage(errorMessage))
                .Select(errorMessage => new ValidationError(errorMessage)));
        }

        public void AddErrors(IEnumerable<ValidationError> errors)
        {
            validationErrors.AddRange(
                errors
                .ToList()
                .FindAll(error => IsValidErrorMessage(error.Message)));
        }

        /// <summary>
        /// Adds the value and returns the complete result.
        /// </summary>
        /// <param name="newValue"></param>
        /// <returns></returns>
        public IBusinessResult<T> SetValue(T newValue)
        {
            value = newValue;
            return this;
        }

        public T Value()
        {
            return value;
        }

        public IEnumerable<string> Errors()
        {
            return validationErrors.Select(errors => errors.Message);
        }

        public IEnumerable<ValidationError> FullErrors()
        {
            return validationErrors;
        }

        private bool IsValidErrorMessage(string errorMessage)
        {
            return !string.IsNullOrWhiteSpace(errorMessage);
        }
    }
}

