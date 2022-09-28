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

        /// <summary>
        ///     Marks the ServiceResult object as successful. 
        /// </summary>
        /// <returns>
        ///     ServiceResult object which invoked the method
        /// </returns>
        public ServiceResult<TValue> Success() => SetResultState(true);

        /// <summary>
        ///     Marks the ServiceResult object as failed. 
        ///     That will make all next Do() methods to be skipped
        /// </summary>
        /// <returns>
        ///     ServiceResult object which invoked the method
        /// </returns>
        public ServiceResult<TValue> Fail() => SetResultState(false);

        /// <summary>
        ///     Produces an action that was passed in. 
        ///     Makes the ServiceResult object to skip all the next Do's if ServiceResult already contains an exception.
        /// </summary>
        /// <returns>
        ///     ServiceResult object which invoked the method
        /// </returns>
        public ServiceResult<TValue> Do(Func<ServiceResult<TValue>> expression)
        {
            if (Exception == null && IsSuccessful)
            {
                return expression();
            }

            return this;
        }

        /// <summary>
        ///     Checks is ServiceResult contains previously catched exception of type <paramref name="TException"/>.
        ///     Makes the ServiceResult object to skip all the next catches.
        /// </summary>
        /// <typeparam name="TException"></typeparam>
        /// <returns>
        ///     ServiceResult object which invoked the method
        /// </returns>
        public ServiceResult<TValue> Catch<TException>(string errorMessage) where TException : Exception
        {   
            if(_continueCatching && Exception?.GetType() == typeof(TException))
            {
                ClientErrorMessage = errorMessage;
                _continueCatching = false;
            }

            return this;
        }

        /// <summary>
        ///     Maps ServiceResult instance to an appropriate type with value inside
        /// </summary>
        /// <typeparam name="TOut"></typeparam>
        /// <returns>
        ///     ServiceResult object which was mapped to <paramref name="TOut"/> type
        /// </returns>
        public ServiceResult<TOut> MapToResult<TOut>(TOut data)
            => Map(new ServiceResult<TOut>(data));


        /// <summary>
        ///     Maps ServiceResult instance to an appropriate type 
        ///     without value in case when an error occured and no data was returned
        /// </summary>
        /// <typeparam name="TOut"></typeparam>
        /// <returns>
        ///     ServiceResult object which was mapped to <paramref name="TOut"/> type
        /// </returns>
        public ServiceResult<TOut> MapToResult<TOut>()
            => Map(new ServiceResult<TOut>());

        private ServiceResult<TValue> SetResultState(bool state)
        {
            IsSuccessful = state;
            return this;
        }

        private ServiceResult<TOut> Map<TOut>(ServiceResult<TOut> outResult)
        {
            outResult.Exception = Exception;
            outResult.ClientErrorMessage = ClientErrorMessage;
            outResult.IsSuccessful = IsSuccessful;

            return outResult;
        }
    }
}
