using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
namespace HitPanSQLServicesServer.VO
{
    class CommonSettingsVO
    {
        public bool UseMirrorAlram { get; set; }
        public MessageCredentialType MessageCredentialType { get; set; }
        public string certPath { get; set; }
        public string certPassword { get; set; }

        public string BackupDIRPath { get; set; }
        public TimeSpan BackupSchedule { get; set; }
        public StringCollection MirrorDIRPath { get; set; }
        public string SecurityTokenSeed { get; set; }
        public object this[string key] 
        {
            get 
            {
                object v = null;
                switch (key)
                {
                    case "UseMirrorAlram": { v = this.UseMirrorAlram; } break;
                    case "MessageCredentialType": { v = this.MessageCredentialType; } break;
                    case "certPath": { v = this.certPath; } break;
                    case "certPassword": { v = this.certPassword; } break;
                    case "BackupDIRPath": { v = this.BackupDIRPath; } break;
                    case "BackupSchedule": { v = this.BackupSchedule; } break;
                    case "MirrorDIRPath": { v = this.MirrorDIRPath; } break;
                    case "SecurityTokenSeed": { v = this.SecurityTokenSeed; } break;
                    default:
                        break;
                }
                return v;
            }
            set 
            {
                switch (key)
                {
                    case "UseMirrorAlram": { this.UseMirrorAlram =(bool)value; } break;
                    case "MessageCredentialType": { this.MessageCredentialType = (MessageCredentialType)value; } break;
                    case "certPath": {this.certPath = (string)value; } break;
                    case "certPassword": { this.certPassword = (string)value; } break;
                    case "BackupDIRPath": { this.BackupDIRPath = (string)value; } break;
                    case "BackupSchedule": {this.BackupSchedule = (TimeSpan)value; } break;
                    case "MirrorDIRPath": { this.MirrorDIRPath = (StringCollection)value; } break;
                    case "SecurityTokenSeed": { this.SecurityTokenSeed = (string)value; } break;
                    default:
                        break;
                }
            }
        }
    }
}
