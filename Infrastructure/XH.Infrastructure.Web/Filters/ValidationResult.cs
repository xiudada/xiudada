using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;

namespace XH.Infrastructure.Web.Filters
{
    public class ValidationResult
    {
        private ICollection<FieldError> _fieldErrors;

        public bool Success { get; set; }

        public IEnumerable<FieldError> FieldErrors
        {
            get
            {
                return _fieldErrors;
            }
        }

        private ValidationResult()
        {
            Success = true;
            _fieldErrors = new List<FieldError>();
        }

        public ValidationResult(ModelStateDictionary modelState) : this()
        {
            InitValidateionResultFromsModelState(modelState);
        }

        private void InitValidateionResultFromsModelState(ModelStateDictionary modelState)
        {
            if (modelState.IsValid)
            {
                Success = true;
            }
            else
            {
                foreach (var state in modelState)
                {
                    foreach (var fieldError in state.Value.Errors)
                    {
                        this.AddFieldError(new FieldError { FieldName = state.Key, ErrorMessage = fieldError.ErrorMessage });
                    }
                }
            }
        }

        public void AddFieldError(FieldError error)
        {
            Success = false;
            _fieldErrors.Add(error);
        }
    }

    public class FieldError
    {
        public string FieldName { get; set; }

        public string ErrorMessage { get; set; }
    }
}
