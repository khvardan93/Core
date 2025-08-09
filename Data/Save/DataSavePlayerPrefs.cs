
using UnityEngine;

namespace Core.Data
{
    public class DataSavePlayerPrefs : IDataSaveFactory
    {
        public bool TryLoadData(string storageName, out IDataStorage dataStorage)
        {
            var json = PlayerPrefs.GetString(storageName, null);

            if (json != null)
            {
                dataStorage = JsonUtility.FromJson<DataStorage>(json);
                dataStorage.OnDataLoaded.Invoke();
                return dataStorage != null;
            }

            dataStorage = null;
            return true;
        }

        public bool TrySaveData(IDataStorage dataStorage)
        {
            var json = JsonUtility.ToJson(dataStorage);
            if (json != null) PlayerPrefs.SetString(dataStorage.Name, json);
            return true;
        }
    }
}
