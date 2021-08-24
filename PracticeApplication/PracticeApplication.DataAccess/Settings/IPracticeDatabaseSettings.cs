using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeApplication.DataAccess.Settings
{
    public interface IPracticeDatabaseSettings
    {
        string PieceCollectionName { get; set; }
        string ComposerCollectionName { get; set; }
        string UserCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
