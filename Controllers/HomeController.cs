using Device_Migration_Admin_Portal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device_Migration_Admin_Portal.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DeviceDbContext _context;

        public HomeController(ILogger<HomeController> logger, DeviceDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        // Existing Index action
        public async Task<IActionResult> Index()
        {
            var devices = await _context.DeviceMigration.ToListAsync();
            return View(devices);
        }

        // Existing Privacy action
        public IActionResult Privacy()
        {
            return View();
        }

        // Existing Error action
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // Action to export filtered data to CSV
        public async Task<IActionResult> ExportToCSV(string statusFilter)
        {
            // Fetch filtered data based on status filter
            var filteredDevices = await _context.DeviceMigration.Where(d => string.IsNullOrEmpty(statusFilter) || d.OverallStatus == statusFilter).ToListAsync();

            // Generate CSV content
            var csvContent = new StringBuilder();
            csvContent.AppendLine("Device Serial,Device Name,User Name,User Email,Migration Not Started,Migration In Progress,Migration Completed,Migration Failed,Overall Status");
            foreach (var device in filteredDevices)
            {
                csvContent.AppendLine($"{device.DeviceSerial},{device.DeviceName},{device.UserName},{device.UserEmail},{(device.MigrationNotStarted ? "Not Started" : "Started")},{(device.MigrationInProgress ? "In Progress" : "Not In Progress")},{(device.MigrationCompleted ? "Completed" : "Not Completed")},{(device.MigrationFailed ? "Failed" : "Not Failed")},{device.OverallStatus}");
            }

            // Return CSV file
            return File(Encoding.UTF8.GetBytes(csvContent.ToString()), "text/csv", "export.csv");
        }

        // Action to export filtered data to Excel (similar logic as CSV)
        public async Task<IActionResult> ExportToExcel(string statusFilter)
        {
            // Fetch filtered data based on status filter
            var filteredDevices = await _context.DeviceMigration.Where(d => string.IsNullOrEmpty(statusFilter) || d.OverallStatus == statusFilter).ToListAsync();

            // Generate Excel content

            // Return Excel file
            // (Implementation omitted for brevity)
            return Content("Excel export logic will be implemented here.");
        }
    }
}
