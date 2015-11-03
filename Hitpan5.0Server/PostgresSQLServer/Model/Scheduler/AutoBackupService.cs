using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32.TaskScheduler;
using System.Diagnostics;
namespace PostgresSQLServer.Model.Scheduler
{
    public class SchedulingService
    {
        public void RegistSchedule(string serviceName,ProcessPriorityClass Priority,string FilePath,string args) 
        {
            using (TaskService task= new TaskService())
            {
                string SchedulerName= "GISHitpanDBManager"+Guid.NewGuid().ToString();
                using(TaskDefinition def = task.NewTask())
	            {
                    //일반
                    def.Principal.DisplayName = serviceName;
                    def.Principal.UserId=string.Format("{0}\\{1}",Environment.UserDomainName,Environment.UserName);
                    def.Principal.LogonType=TaskLogonType.InteractiveToken;
                    def.Principal.RunLevel=TaskRunLevel.Highest;
                    def.Triggers.Add( new LogonTrigger());
                    //조건
                    def.Settings.MultipleInstances=TaskInstancesPolicy.IgnoreNew;
                    def.Settings.DisallowStartIfOnBatteries=false;
                    def.Settings.StopIfGoingOnBatteries=false;
                    def.Settings.AllowHardTerminate=false;
                    def.Settings.StartWhenAvailable=true;
                    def.Settings.RunOnlyIfNetworkAvailable=false;
                    def.Settings.IdleSettings.StopOnIdleEnd=false;
                    def.Settings.IdleSettings.RestartOnIdle=false;
                    //설정
                    def.Settings.AllowDemandStart=false;
                    def.Settings.Enabled=true;
                    def.Settings.Hidden=false;
                    def.Settings.RunOnlyIfIdle=false;  
                    def.Settings.ExecutionTimeLimit=TimeSpan.Zero;
                    def.Settings.Priority = Priority;
                    //동작
                    def.Actions.Add(FilePath, args);
                    //등록		 
                    task.RootFolder.RegisterTaskDefinition(SchedulerName,def);
	            }

            }
        }
    }
}
