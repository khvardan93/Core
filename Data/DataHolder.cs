
namespace Core.Data
{
    public abstract class DataHolder
    {
        public abstract IDataSaveFactory SaveFactory { get; set; }

        public void SaveStorage(IDataStorage storage)
        {
            SaveFactory.TrySaveData(storage);
        }

        public bool TryLoadStorage(string storageName, out IDataStorage dataStorage)
        {
            return SaveFactory.TryLoadData(storageName, out dataStorage);
        }
    }
}