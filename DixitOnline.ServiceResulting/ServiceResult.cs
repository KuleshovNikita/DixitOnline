using System;
using System.Text.Json.Serialization;

namespace DixitOnline.ServiceResulting
{
    public class ServiceResult
    {
        private bool _continueCatching = true;

        public bool IsSuccessful { get; private set; } = true;

        [JsonIgnore]
        public Exception ErrorData { get; set; }

        public string ClientErrorMessage { get; private set; }

        public ServiceResult Success() => SetResultState(true);

        public ServiceResult Fail() => SetResultState(false);

        public ServiceResult Do(Func<ServiceResult> expression)
        {
            if (ErrorData != null || !IsSuccessful)
            {
                return this;
            }

            return expression();
        }

        public ServiceResult Catch<TException>(string errorMessage) where TException : Exception
        {   
            if(_continueCatching && ErrorData.GetType() == typeof(TException))
            {
                ClientErrorMessage = errorMessage;
                _continueCatching = false;
            }

            return this;
        }

        protected ServiceResult SetResultState(bool state)
        {
            IsSuccessful = state;
            return this;
        }
    }
}
