using System;
using System.Collections.Generic;
using System.Linq;

namespace DixitOnline.ServiceResulting
{
    public class GenericServiceResult<TValue> : ServiceResult
    {
        public GenericServiceResult(TValue value) => Value = value;

        public TValue Value { get; }
    }
}
