using System;
using System.Linq.Expressions;

namespace UselessProject
{
    /// <summary>
    ///     A useless class for the paranoid few.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Obsolete]
    public abstract class ConstantObserver<T>
    {
        private readonly Func<T> _constantToObserve;

        protected ConstantObserver(Expression<Func<T>> constantToObserve)
        {
            if (constantToObserve == null) throw new ArgumentNullException(nameof(constantToObserve));
            if (!(constantToObserve.Body is ConstantExpression c))
                throw new ArgumentException("Not a constant", nameof(constantToObserve));
            _constantToObserve = constantToObserve.Compile();
        }

        public event EventHandler<ConstantChangedEventArgs<T>> ConstantChanged;

        [Obsolete]
        public void StartObserving()
        {
            var previousValue = _constantToObserve();
            while (true)
            {
                var newValue = _constantToObserve();
                if (!Equals(previousValue, newValue))
                {
                    OnConstantChanged(new ConstantChangedEventArgs<T>
                    {
                        CurrentValue = newValue,
                        PreviousValue = previousValue
                    });
                    previousValue = newValue;
                }
            }
        }

        private void OnConstantChanged(ConstantChangedEventArgs<T> e)
        {
            ConstantChanged?.Invoke(this, e);
        }
    }
}