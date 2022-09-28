using System;

namespace DixitOnline.ServiceResulting
{
    public interface IServiceResult
    {
        bool IsSuccessful { get; }

        Exception Exception { get; set; }

        string ClientErrorMessage { get; }

        IServiceResult Success();

        IServiceResult Fail();

        IServiceResult Do(Func<IServiceResult> expression);

        IServiceResult Catch<TException>(string errorMessage) where TException : Exception;
    }
}
