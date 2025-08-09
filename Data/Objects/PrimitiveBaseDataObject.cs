using System;

namespace Core.Data
{
    public abstract class PrimitiveBaseDataObject<T> : IDataObject<T> where T : IComparable
    {
        private event Action<T> _onValueChanged;
        private T _value;

        public abstract DataType DataType { get; }
        
        public Action<T> OnChange => _onValueChanged;

        public T Value
        {
            get => _value;
            set => SetValue(value);
        }

        private void SetValue(T value)
        {
            if(CheckEquality(_value, value)) return;
            _onValueChanged?.Invoke(value);
            _value = value;
        }

        protected abstract bool CheckEquality(T v1, T v2);
    }
}
