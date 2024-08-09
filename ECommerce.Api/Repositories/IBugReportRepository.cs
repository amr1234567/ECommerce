using ECommerce.Core.Entities.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Repositories
{
    public interface IBugReportRepository
    {
        Task<bool> GenerateNewBugReport(BugReport model);
        Task<BugReport> MarkAsDone(string bugReportId);
        Task<BugReport> MarkAsIgnored(string bugReportId);
        Task<BugReport> MarkAsUnderProgress(string bugReportId);
        Task<BugReport> GetBugReportById(string bugReportId);
        Task<IQueryable<BugReport>> GetAllBugReports();
        Task<IQueryable<BugReport>> GetAllCompletedBugReports();
        Task<IQueryable<BugReport>> GetAllUnderProgressBugReports();
        Task<IQueryable<BugReport>> GetAllUnCompletedBugReports();
    }
}
