using ECommerce.Core.Entities.Application;
using ECommerce.Repositry.Models.InputModels;
using ECommerce.Repositry.Models.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repositry.Abstraction
{
    public interface IBugReportServices
    {
        Task<bool> GenerateNewBugReport(BugReportToAddModel model);
        Task<BugReportResponse> MarkAsDone(string bugReportId);
        Task<BugReportResponse> MarkAsIgnored(string bugReportId);
        Task<BugReportResponse> MarkAsUnderProgress(string bugReportId);
        Task<List<BugReportResponse>> GetAllBugReports();
        Task<List<BugReportResponse>> GetAllCompletedBugReports();
        Task<List<BugReportResponse>> GetAllUnderProgressBugReports();
        Task<List<BugReportResponse>> GetAllUnCompletedBugReports();
    }
}
