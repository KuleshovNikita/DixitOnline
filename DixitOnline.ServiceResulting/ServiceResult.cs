using System;
using System.Text.Json.Serialization;

namespace DixitOnline.ServiceResulting
{
    public class ServiceResult : IServiceResult
    {
        private bool _continueCatching = true;

        public bool IsSuccessful { get; private set; } = true;

        [JsonIgnore]
        public Exception Exception { get; set; }

        public string ClientErrorMessage { get; private set; }

        public IServiceResult Success() => SetResultState(true);

        public IServiceResult Fail() => SetResultState(false);

        public IServiceResult Do(Func<IServiceResult> expression)
        {
            if (Exception != null || !IsSuccessful)
            {
                return this;
            }

            return expression();
        }

        public IServiceResult Catch<TException>(string errorMessage) where TException : Exception
        {   
            if(_continueCatching && Exception?.GetType() == typeof(TException))
            {
                ClientErrorMessage = errorMessage;
                _continueCatching = false;
            }

            return this;
        }

        protected IServiceResult SetResultState(bool state)
        {
            IsSuccessful = state;
            return this;
        }
    }
}
