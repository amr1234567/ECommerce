using ECommerce.Core.Exceptions;
using ECommerce.Core.Helpers;
using ECommerce.Core.Repositories.Manager;
using ECommerce.Repositry.Abstraction;
using ECommerce.Repositry.Models.InputModels;
using ECommerce.Repositry.Models.OutputModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repositry.Services
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

        public async Task<List<BugReportResponse>> GetAllBugReports()
        {
            var bugReports = await managerRepository.BugReportRepository.GetAllBugReports();
            return await bugReports.Select(b => new BugReportResponse(b, userServices)).ToListAsync();
        }

        public async Task<List<BugReportResponse>> GetAllCompletedBugReports()
        {
            var bugReports = await managerRepository.BugReportRepository.GetAllCompletedBugReports();
            return await bugReports.Select(b => new BugReportResponse(b, userServices))
                .ToListAsync();
        }

        public async Task<List<BugReportResponse>> GetAllUnCompletedBugReports()
        {
            var bugReports = await managerRepository.BugReportRepository.GetAllUnCompletedBugReports();
            return await bugReports.Select(b => new BugReportResponse(b, userServices))
                .ToListAsync();
        }

        public async Task<List<BugReportResponse>> GetAllUnderProgressBugReports()
        {
            var bugReports = await managerRepository.BugReportRepository.GetAllUnderProgressBugReports();
            return await bugReports.Select(b => new BugReportResponse(b, userServices))
                .ToListAsync();
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
