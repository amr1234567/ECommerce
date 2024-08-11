using ECommerce.Core.Exceptions;
using ECommerce.Core.Helpers;
using ECommerce.Core.Repositories.Manager;
using ECommerce.Repository.Abstraction;
using ECommerce.Repository.Models.InputModels;
using ECommerce.Repository.Models.OutputModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repository.Services
{
    internal class BugReportServices(IManagerRepository managerRepository, IUserServices userServices) : IBugReportServices
    {
        public async Task<bool> GenerateNewBugReport(BugReportToAddModel model)
        {
            if (model is null)
            {
                throw new ParameterIsNullOrEmptyException("Bug Report Model in Service");
            }
            return await managerRepository.BugReportRepository.GenerateNewBugReport(model.ToModel());
        }

        public async Task<IQueryable<BugReportResponse>> GetAllBugReports()
        {
            var bugReports = await managerRepository.BugReportRepository.GetAllBugReports();
            return bugReports.Select(b => new BugReportResponse(b, userServices));
        }

        public async Task<IQueryable<BugReportResponse>> GetAllCompletedBugReports()
        {
            var bugReports = await managerRepository.BugReportRepository.GetAllCompletedBugReports();
            return bugReports.Select(b => new BugReportResponse(b, userServices));
        }

        public async Task<IQueryable<BugReportResponse>> GetAllUnCompletedBugReports()
        {
            var bugReports = await managerRepository.BugReportRepository.GetAllUnCompletedBugReports();
            return bugReports.Select(b => new BugReportResponse(b, userServices));
        }

        public async Task<IQueryable<BugReportResponse>> GetAllUnderProgressBugReports()
        {
            var bugReports = await managerRepository.BugReportRepository.GetAllUnderProgressBugReports();
            return bugReports.Select(b => new BugReportResponse(b, userServices));
        }

        public async Task<BugReportResponse> MarkAsDone(string bugReportId)
        {
            var bugReport = await managerRepository.BugReportRepository.MarkAsDone(bugReportId);
            return new BugReportResponse(bugReport, userServices);
        }

        public async Task<BugReportResponse> MarkAsIgnored(string bugReportId)
        {
            var bugReport = await managerRepository.BugReportRepository.MarkAsIgnored(bugReportId);
            return new BugReportResponse(bugReport, userServices);
        }

        public async Task<BugReportResponse> MarkAsUnderProgress(string bugReportId)
        {
            var bugReport = await managerRepository.BugReportRepository.MarkAsUnderProgress(bugReportId);
            return new BugReportResponse(bugReport, userServices);
        }
    }
}
