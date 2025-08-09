using System;

namespace Core.Data
{
    public interface IDataObject<T>
    {
        public DataType DataType { get; }
        public T Value { get; set; }
        public Action<T> OnChange { get; }
    }
}
