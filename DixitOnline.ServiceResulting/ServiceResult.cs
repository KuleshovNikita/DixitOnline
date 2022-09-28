using System;
using System.Text.Json.Serialization;

namespace DixitOnline.ServiceResulting
{
    public class ServiceResult<TValue>
    {
        private bool _continueCatching = true;

        public bool IsSuccessful { get; private set; } = true;

        public TValue Value { get; }

        public ServiceResult() { }

        public ServiceResult(TValue value) => Value = value;

        [JsonIgnore]
        public Exception Exception { get; set; }

        public string ClientErrorMessage { get; private set; }

        public ServiceResult<TValue> Success() => SetResultState(true);

        public ServiceResult<TValue> Fail() => SetResultState(false);

        public ServiceResult<TValue> Do(Func<ServiceResult<TValue>> expression)
        {
            if (Exception != null || !IsSuccessful)
            {
                return this;
            }

            return expression();
        }

        public ServiceResult<TValue> Catch<TException>(string errorMessage) where TException : Exception
        {   
            if(_continueCatching && Exception?.GetType() == typeof(TException))
            {
                ClientErrorMessage = errorMessage;
                _continueCatching = false;
            }

            return this;
        }

        protected ServiceResult<TValue> SetResultState(bool state)
        {
            IsSuccessful = state;
            return this;
        }
    }
}
