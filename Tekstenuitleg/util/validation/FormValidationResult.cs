using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CursusIndex.util.validation
{
    
    public class FormValidationResult
    {
        private readonly Dictionary<string, FieldValidationResult> _validationResult = new Dictionary<string, FieldValidationResult>();
        private int _totalErrors = 0;

        public void AddResult(string fieldName, FieldValidationResult result)
        {
            _validationResult.Add(fieldName, result);

            if (!result.Valid)
            {
                _totalErrors++;
            }
        }

        public void ClearResults()
        {
            _validationResult.Clear();
        }

        public List<FieldValidationResult> GetAllResults()
        {
            return _validationResult.Values.ToList();
        }

        public List<FieldValidationResult> GetErronousResults()
        {
            var erronousResults = new List<FieldValidationResult>();
            foreach (var result in _validationResult.Values.ToList())
            {
                if (!result.Valid)
                {
                    erronousResults.Add(result);
                }
            }
            return erronousResults;
        } 

        public FieldValidationResult GetResult(string fieldName)
        {
            return _validationResult[fieldName];
        }

        public int GetTotalErrors()
        {
            return _totalErrors;
        }

        public bool FormIsValid()
        {
            return _totalErrors == 0;
        }

    }
}