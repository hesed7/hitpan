﻿using System;
using System.Data;
namespace WebService.Model.DB
{
    interface IDBService
    {
        void Backup(string ServiceURL, string BackupFolderPath);
        void Dispose();
        DataTable GetData(string Query);
        int SetData(global::System.Collections.Specialized.StringCollection QueryBlock);
    }
}
