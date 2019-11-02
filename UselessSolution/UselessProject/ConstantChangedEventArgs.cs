using System;

namespace UselessProject
{
    public class ConstantChangedEventArgs<T> : EventArgs
    {
        public T PreviousValue { get; set; }
        public T CurrentValue { get; set; }
    }
}