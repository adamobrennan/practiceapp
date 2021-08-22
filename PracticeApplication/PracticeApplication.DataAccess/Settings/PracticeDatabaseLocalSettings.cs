namespace PracticeApplication.DataAccess.Settings
{
    public class PracticeDatabaseLocalSettings : IPracticeDatabaseSettings
    {
        public string PieceCollectionName { get; set; }
        public string ComposerCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
