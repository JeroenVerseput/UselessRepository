using System;
using System.Linq.Expressions;

namespace UselessProject
{
    /// <summary>
    ///     Assumptions are the mother of all f*ck-ups! This class observes constant strings, just in case.
    /// </summary>
    [Obsolete]
    public sealed class ConstantStringObserver : ConstantObserver<string>
    {
        [Obsolete]
        public ConstantStringObserver(Expression<Func<string>> stringToObserve) : base(stringToObserve)
        {
        }
    }
}