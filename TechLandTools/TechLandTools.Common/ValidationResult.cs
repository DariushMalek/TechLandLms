using System;
using System.Collections.Generic;
using System.Text;

namespace TechLandTools.Common
{
    public class ValidationResult
    {
        public TechLandException Exception { get; set; }
        public ValidationResultState State { get; set; }
        public object Entity { get; set; }
        public ValidationResult(string errorMessage)
        {
            Exception = new TechLandException(errorMessage);
            State = ValidationResultState.HasError;
        }

        public ValidationResult(string errorMessage, string exceptionHint)
        {
            Exception = new TechLandException(errorMessage, exceptionHint);
            State = ValidationResultState.HasError;
        }

        public ValidationResult(string errorMessage, int exceptionNo)
        {
            Exception = new TechLandException(errorMessage, exceptionNo);
            State = ValidationResultState.HasError;
        }

        public ValidationResult()
        {
            State = ValidationResultState.IsValid;
        }

        public bool IsOk()
        {
            return State == ValidationResultState.IsValid;
        }
    }

    public enum ValidationResultState
    {
        IsValid = 100,
        HasError = 101
    }
}
