using Device_Migration_Admin_Portal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Device_Migration_Admin_Portal.Controllers
{
    public class ExportController : Controller
    {
        private readonly DeviceDbContext _dbContext;

        public ExportController(DeviceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> ExportToCSV(string status)
        {
            // Fetch filtered data based on status
            var filteredData = _dbContext.DeviceMigration.Where(item => status == null || item.OverallStatus == status).ToList();

            // Generate CSV content
            var csvContent = new StringBuilder();
            csvContent.AppendLine("Device Serial,Device Name,User Name,User Email,Migration Not Started,Migration In Progress,Migration Completed,Migration Failed,Overall Status");
            foreach (var item in filteredData)
            {
                csvContent.AppendLine($"{item.DeviceSerial},{item.DeviceName},{item.UserName},{item.UserEmail},{(item.MigrationNotStarted ? "Not Started" : "Started")},{(item.MigrationInProgress ? "In Progress" : "Not In Progress")},{(item.MigrationCompleted ? "Completed" : "Not Completed")},{(item.MigrationFailed ? "Failed" : "Not Failed")},{item.OverallStatus}");
            }

            // Return CSV file
            return File(Encoding.UTF8.GetBytes(csvContent.ToString()), "text/csv", "export.csv");
        }
        public async Task<IActionResult> ExportToExcel(string status)
        {
            // Fetch filtered data based on status
            var filteredData = await _dbContext.DeviceMigration.Where(item => status == null || item.OverallStatus == status).ToListAsync();

            // Generate Excel content
            // For simplicity, let's assume a tab-separated format
            var excelContent = new StringBuilder();
            excelContent.AppendLine("Device Serial\tDevice Name\tUser Name\tUser Email\tMigration Not Started\tMigration In Progress\tMigration Completed\tMigration Failed\tOverall Status");
            foreach (var item in filteredData)
            {
                excelContent.AppendLine($"{item.DeviceSerial}\t{item.DeviceName}\t{item.UserName}\t{item.UserEmail}\t{(item.MigrationNotStarted ? "Not Started" : "Started")}\t{(item.MigrationInProgress ? "In Progress" : "Not In Progress")}\t{(item.MigrationCompleted ? "Completed" : "Not Completed")}\t{(item.MigrationFailed ? "Failed" : "Not Failed")}\t{item.OverallStatus}");
            }

            // Return Excel file
            return File(Encoding.UTF8.GetBytes(excelContent.ToString()), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "export.xlsx");
        }
    }
}
