using System;
using System.Collections.Generic;

namespace Core.Data
{
    [Serializable]
    public class DataStorage : IDataStorage
    {
        private readonly string _name;
        private event Action _onDataLoaded;
        
        private Dictionary<string, BoolDataObject> _boolData;
        private Dictionary<string, IntDataObject> _intData;
        private Dictionary<string, DoubleDataObject> _doubleData;
        private Dictionary<string, FloatDataObject> _floatData;
        private Dictionary<string, StringDataObject> _stringData;
        //private Dictionary<string, SerializedObject> _boolData;

        Action IDataStorage.OnDataLoaded => _onDataLoaded;
        string IDataStorage.Name => _name;

        public DataStorage(string name)
        {
            _name = name;
        }
        
        bool IDataStorage.TryAdd<T>(string key, DataType dataType, IDataObject<T> value)
        {
            switch (dataType)
            {
                case DataType.Bool:
                    _boolData ??= new();
                    _boolData.Add(key, (BoolDataObject)value);
                    break;
                case DataType.Int:
                    _intData ??= new();
                    _intData.Add(key, (IntDataObject)value);
                    break;
                case DataType.Float:
                    _floatData ??= new();
                    _floatData.Add(key, (FloatDataObject)value);
                    break;
                case DataType.Double:
                    _doubleData ??= new();
                    _doubleData.Add(key, (DoubleDataObject)value);
                    break;
                case DataType.String:
                    _stringData ??= new();
                    _stringData.Add(key, (StringDataObject)value);
                    break;
                case DataType.SerializedObject:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dataType), dataType, null);
            }
            
            return default;
        }

        bool IDataStorage.TryGet<T>(string key, DataType dataType, out IDataObject<T> value)
        {
            switch (dataType)
            {
                case DataType.Bool:
                    if (TryGet(_boolData as Dictionary<string, IDataObject<T>>, key, out var dataObject))
                    {
                        value = dataObject;
                        return true;
                    }
                    break;
                case DataType.Int:
                    if (TryGet(_intData as Dictionary<string, IDataObject<T>>, key, out dataObject))
                    {
                        value = dataObject;
                        return true;
                    }
                    break;
                case DataType.Float:
                    if (TryGet(_floatData as Dictionary<string, IDataObject<T>>, key, out dataObject))
                    {
                        value = dataObject;
                        return true;
                    }
                    break;
                case DataType.Double:
                    if (TryGet(_intData as Dictionary<string, IDataObject<T>>, key, out dataObject))
                    {
                        value = dataObject;
                        return true;
                    }
                    break;
                case DataType.String:
                    if (TryGet(_stringData as Dictionary<string, IDataObject<T>>, key, out dataObject))
                    {
                        value = dataObject;
                        return true;
                    }
                    break;
                case DataType.SerializedObject:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dataType), dataType, null);
            }

            value = null;
            return false;
        }

        private bool TryGet<T>(Dictionary<string, IDataObject<T>> data, string key, out IDataObject<T> value)
        {
            if (data != null && data.TryGetValue(key, out IDataObject<T> dataObject))
            {
                value = dataObject;
                return true;
            }
            
            value = null;
            return false;
        }
    }
}
