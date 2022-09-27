using System;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DixitOnline.ServiceResulting
{
    public class ServiceResult
    {
        private bool _continueCatching = true;

        public bool IsSuccessful { get; private set; } = true;

        [JsonIgnore]
        public Exception Exception { get; set; }

        public string ClientErrorMessage { get; set; }

        public ServiceResult Success() => SetResultState(true);

        public ServiceResult Fail() => SetResultState(false);

        public ServiceResult Do(Func<ServiceResult> expression)
        {
            if (Exception != null || !IsSuccessful)
            {
                return this;
            }

            return expression();
        }

        public ServiceResult Catch<TException>(string errorMessage) where TException : Exception
        {   
            if(_continueCatching && Exception?.GetType() == typeof(TException))
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
