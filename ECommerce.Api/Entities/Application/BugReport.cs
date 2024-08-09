using ECommerce.Core.Entities.Users;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using ECommerce.Core.Helpers.Enums;

namespace ECommerce.Core.Entities.Application
{
    public class BugReport
    {
        [Required]
        //[Key]
        [BsonElement("id")]
        [BsonId]
        public string Id { get; set; }

        [BsonElement("title")]
        [Required]
        public string Title { get; set; }

        [BsonElement("content")]
        [Required]
        public string Content { get; set; }

        [BsonElement("create_date")]
        [Required]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        [BsonElement("completed_date")]
        [AllowNull]
        public DateTime CompletedDate { get; set; }

        [BsonElement("status")]
        [Required]
        public BugReportStatus Status { get; set; } = BugReportStatus.NotTouched;

        [BsonElement("admin_id")]
        [AllowNull]
        public string AdminId { get; set; }

        [BsonElement("consumer_id")]
        [Required]
        public string ConsumerId { get; set; }
    }
}
