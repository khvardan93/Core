namespace Core.Data
{
    public interface IDataSaveFactory
    {
        public bool TryLoadData(string storageName, out IDataStorage dataStorage);
        public bool TrySaveData(IDataStorage dataStorage);
    }
}
