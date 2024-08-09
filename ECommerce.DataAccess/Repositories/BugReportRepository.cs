using ECommerce.Core.Entities.Application;
using ECommerce.Core.Exceptions;
using ECommerce.Core.Helpers.Enums;
using ECommerce.Core.Repositories;
using ECommerce.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;

namespace ECommerce.DataAccess.Repositories
{
    internal class BugReportRepository(ECommerceContext context) : IBugReportRepository
    {
        public async Task<bool> GenerateNewBugReport(BugReport model)
        {
            ArgumentNullException.ThrowIfNull(model);
            var id = new ObjectId();
            model.Id = id.ToString();
            await context.BugReports.AddAsync(model);
            await context.SaveChangesAsync();
            return true;
        }

        public Task<IQueryable<BugReport>> GetAllBugReports()
        {
            return Task.FromResult(context.BugReports.AsNoTracking());
        }

        public Task<IQueryable<BugReport>> GetAllCompletedBugReports()
        {
            return Task.FromResult(context.BugReports
                .Where(b => b.Status.Equals(BugReportStatus.Ignored) || b.Status.Equals(BugReportStatus.Done))
                .AsNoTracking());
        }

        public Task<IQueryable<BugReport>> GetAllUnCompletedBugReports()
        {
            return Task.FromResult(context.BugReports
                .Where(b => b.Status.Equals(BugReportStatus.NotTouched) || b.Status.Equals(BugReportStatus.underProgress))
                .AsNoTracking());
        }

        public Task<IQueryable<BugReport>> GetAllUnderProgressBugReports()
        {
            return Task.FromResult(context.BugReports
                .Where(b => b.Status.Equals(BugReportStatus.underProgress))
                .AsNoTracking());
        }

        public async Task<BugReport> GetBugReportById(string bugReportId)
        {
            var bugReport = await context.BugReports.FirstOrDefaultAsync(b => b.Id.Equals(bugReportId))
                ?? throw new NotFoundException($"BugReport with id {bugReportId}");
            return bugReport;
        }

        public async Task<BugReport> MarkAsDone(string bugReportId)
        {
            var bugReport = await GetBugReportById(bugReportId);
            bugReport.Status = BugReportStatus.Done;
            context.BugReports.Update(bugReport);
            await context.SaveChangesAsync();
            return bugReport;
        }

        public async Task<BugReport> MarkAsIgnored(string bugReportId)
        {
            var bugReport = await GetBugReportById(bugReportId);
            bugReport.Status = BugReportStatus.Ignored;
            context.BugReports.Update(bugReport);
            await context.SaveChangesAsync();
            return bugReport;
        }

        public async Task<BugReport> MarkAsUnderProgress(string bugReportId)
        {
            var bugReport = await GetBugReportById(bugReportId);
            bugReport.Status = BugReportStatus.underProgress;
            context.BugReports.Update(bugReport);
            await context.SaveChangesAsync();
            return bugReport;
        }
    }
}
