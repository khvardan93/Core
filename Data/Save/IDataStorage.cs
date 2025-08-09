using System;

namespace Core.Data
{
    public interface IDataStorage
    {
        public Action OnDataLoaded { get; }
        public string Name { get; }
        public bool TryAdd<T>(string key, DataType dataType, IDataObject<T> value);
        public bool TryGet<T>(string key, DataType dataType, out IDataObject<T> value);
    }
}