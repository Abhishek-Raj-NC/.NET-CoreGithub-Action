using System.ComponentModel.DataAnnotations;

namespace Device_Migration_Admin_Portal.Models
{
    public class DeviceMigration
    {
        [Key]
        [Required]
        [StringLength(50)]
        public string DeviceSerial { get; set; }

        [StringLength(100)]
        public string DeviceName { get; set; }

        [StringLength(100)]
        public string UserName { get; set; }

        [StringLength(100)]
        public string UserEmail { get; set; }

        [StringLength(50)]
        public string OverallStatus { get; set; }

        public bool MigrationNotStarted { get; set; }
        public bool MigrationInProgress { get; set; }
        public bool MigrationCompleted { get; set; }
        public bool MigrationFailed { get; set; }
        public bool IntuneUnenrollment { get; set; }
        public bool AzureUnregister { get; set; }
        public bool OutlookProfileRemoval { get; set; }
        public bool OneDriveUnlink { get; set; }
        public bool UserConfirmation { get; set; }
        public bool UserReRun { get; set; }
        public bool SleepSetting { get; set; }
        public bool M365SignOut { get; set; }
        public bool TeamsSignOut { get; set; }

        [StringLength(100)]
        public string ForesnsitTool { get; set; }

        public bool ComputerMigration { get; set; }
        public DateTime LastUpdatedTime { get; set; }
    }
}
