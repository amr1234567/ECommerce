using ECommerce.Core.Entities.Application;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repositry.Models.InputModels
{
    public class BugReportToAddModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        private string ConsumerId { get; set; }

        public BugReportToAddModel(string Title, string Content, string ConsumerId)
        {
            this.Title = Title;
            this.Content = Content;
            this.ConsumerId = ConsumerId;
        }
        public BugReportToAddModel(string consumerId)
        {
            ConsumerId = consumerId;
        }

        public BugReport ToModel()
        {
            return new BugReport
            {
                Title = Title,
                Content = Content,
                ConsumerId = ConsumerId,
            };
        }
    }
}
