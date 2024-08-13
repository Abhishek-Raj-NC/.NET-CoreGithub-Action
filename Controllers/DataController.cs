using Device_Migration_Admin_Portal.Hubs;
using Device_Migration_Admin_Portal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Device_Migration_Admin_Portal.Controllers
{
    public class DataController : Controller
    {
        private readonly DeviceDbContext _context;
        private readonly IHubContext<DeviceHub> _hubContext;

        public DataController(DeviceDbContext context, IHubContext<DeviceHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.DeviceMigration.ToListAsync());
        }

        // Call this method whenever there is a change in the database
        public async Task NotifyDatabaseChange()
        {
            var devices = await _context.DeviceMigration.ToListAsync();
            await _hubContext.Clients.All.SendAsync("ReceiveDeviceUpdates", devices);
        }

        // Action method to fetch device details by serial number
        [HttpGet]
        public IActionResult GetDeviceDetails(string deviceSerial)
        {
            if (string.IsNullOrEmpty(deviceSerial))
            {
                return BadRequest("Device serial number is required.");
            }

            // Fetch device details from the database
            var device = _context.DeviceMigration.FirstOrDefault(d => d.DeviceSerial == deviceSerial);

            if (device == null)
            {
                return NotFound($"Device with serial number '{deviceSerial}' not found.");
            }

            // Prepare and return JSON response
            return Json(new
            {
                device.IntuneUnenrollment,
                device.AzureUnregister,
                device.OutlookProfileRemoval,
                device.OneDriveUnlink,
                device.UserConfirmation,
                device.UserReRun,
                device.SleepSetting,
                device.M365SignOut,
                device.TeamsSignOut,
                device.ForesnsitTool,
                device.ComputerMigration,
                device.LastUpdatedTime
            });
        }
    }
}
