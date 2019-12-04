using System;
using System.IO;
using System.Linq;

namespace OleHotels.DataAccess
{
    public class Backup
    {
        public bool BackupData()
        {
            var filesLocation = Path.Combine(AppContext.BaseDirectory, "JsonFiles");
            var backupLocation = Path.Combine(AppContext.BaseDirectory, "Backup");

            try
            {
                // Create backup folder if necessary
                if (!Directory.Exists(backupLocation))
                {
                    Directory.CreateDirectory(backupLocation);
                }

                var fileDriveInfo = new DirectoryInfo(filesLocation);
                if (fileDriveInfo == null)
                {
                    return false;
                }

                var fileInfos = fileDriveInfo.GetFiles();
                if(fileInfos.Any() == false)
                {
                    return false;
                }

                foreach(var file in fileInfos)
                {
                    file.CopyTo($"{backupLocation}/{file.Name}_{DateTime.Now.Ticks}");
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}