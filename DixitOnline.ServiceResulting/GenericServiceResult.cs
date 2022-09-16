using System;
using System.Collections.Generic;
using System.Linq;

namespace DixitOnline.ServiceResulting
{
    public class GenericServiceResult<TValue> : ServiceResult
    {
        public TValue Value { get; set; }
    }
}
