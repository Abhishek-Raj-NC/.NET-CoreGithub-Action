namespace Device_Migration_Admin_Portal.Models
{
    public class UserInfo
    {
        string userName { get; set; }

        string password { get; set; }
    }

    public static class DC
    {
        public static string nearestDC { get; set; }

    }
}
