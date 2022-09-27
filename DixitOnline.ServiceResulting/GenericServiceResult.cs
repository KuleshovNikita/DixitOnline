using System;
using System.Text.Json.Serialization;

namespace DixitOnline.ServiceResulting
{
    public class GenericServiceResult<TValue>
    {
        private bool _continueCatching = true;

        public GenericServiceResult() { }

        public GenericServiceResult(TValue value) => Value = value;

        public TValue Value { get; }

        public bool IsSuccessful { get; private set; } = true;

        [JsonIgnore]
        public Exception Exception { get; set; }

        public string ClientErrorMessage { get; private set; }

        public GenericServiceResult<TValue> Success() => SetResultState(true);

        public GenericServiceResult<TValue> Fail() => SetResultState(false);

        public ServiceResult Do(Func<ServiceResult> expression)
        {
            if (Exception != null || !IsSuccessful)
            {
                return new ServiceResult
                {
                    Exception = this.Exception,
                    ClientErrorMessage = this.ClientErrorMessage
                }.Fail();
            }

            return expression();
        }

        public GenericServiceResult<TValue> Do(Func<GenericServiceResult<TValue>> expression)
        {
            if (Exception != null || !IsSuccessful)
            {
                return this;
            }

            return expression();
        }

        public GenericServiceResult<TValue> Catch<TException>(string errorMessage) where TException : Exception
        {
            if (_continueCatching && Exception?.GetType() == typeof(TException))
            {
                ClientErrorMessage = errorMessage;
                _continueCatching = false;
            }

            return this;
        }

        protected GenericServiceResult<TValue> SetResultState(bool state)
        {
            IsSuccessful = state;
            return this;
        }
    }
}
