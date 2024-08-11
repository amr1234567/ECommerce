using ECommerce.Core.Entities.Application;
using ECommerce.Repository.Models.InputModels;
using ECommerce.Repository.Models.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repository.Abstraction
{
    public interface IBugReportServices
    {
        Task<bool> GenerateNewBugReport(BugReportToAddModel model);
        Task<BugReportResponse> MarkAsDone(string bugReportId);
        Task<BugReportResponse> MarkAsIgnored(string bugReportId);
        Task<BugReportResponse> MarkAsUnderProgress(string bugReportId);
        Task<IQueryable<BugReportResponse>> GetAllBugReports();
        Task<IQueryable<BugReportResponse>> GetAllCompletedBugReports();
        Task<IQueryable<BugReportResponse>> GetAllUnderProgressBugReports();
        Task<IQueryable<BugReportResponse>> GetAllUnCompletedBugReports();
    }
}
