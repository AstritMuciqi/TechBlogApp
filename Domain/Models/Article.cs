﻿using System.ComponentModel.DataAnnotations.Schema;

namespace TechBlogApp.Domain.Models
{
    public class Article
    {
        public Guid ArticleId { get; set; }
        /*public int UserId { get; set; }
        public AppUser User { get; set; }*/
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime DatePublished { get; set; }

        public int TimeDifference { get; set; }
        public string ImagePath { get; set; }

        public string Tags { get; set; }

        public virtual List<Comment> Comments { get; set; }
        public string AppUserId { get; set; }

        [ForeignKey("AppUserId")]
        public virtual AppUser User { get; set; }


    }
}
