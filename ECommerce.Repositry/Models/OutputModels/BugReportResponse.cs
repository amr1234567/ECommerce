using ECommerce.Core.Entities.Application;
using ECommerce.Core.Helpers.Enums;
using ECommerce.Repository.Abstraction;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repository.Models.OutputModels
{
    public class BugReportResponse
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? CompletedDate { get; set; }

        public BugReportStatus Status { get; set; }

        public string? AdminName { get; set; }

        public string ConsumerName { get; set; }

        public BugReportResponse(BugReport bugReport, IUserServices userServices)
        {
            CompletedDate = bugReport.CompletedDate;
            Content = bugReport.Content;
            CreateDate = bugReport.CreateDate;
            Id = bugReport.Id;
            Status = bugReport.Status;
            Title = bugReport.Title;
            ConsumerName = userServices.GetConsumerById(bugReport.ConsumerId).Result.Name;
            AdminName = userServices.GetAdminById(bugReport.AdminId).Result.Name;
        }
        public BugReportResponse()
        {

        }
    }
}
