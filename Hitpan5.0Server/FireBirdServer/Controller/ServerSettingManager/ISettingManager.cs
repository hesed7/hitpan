using System;
namespace WebServiceServer.Controller.ServerSettingManager
{
    interface ISettingManager
    {
        bool CheckServerEngine();
        void AutoBackup(TimeSpan Interval, string BackupFolder);
        void SetMirroring(string key, string MirrorPath, bool UseAlram);
        void SetServerEngine();
    }
}
