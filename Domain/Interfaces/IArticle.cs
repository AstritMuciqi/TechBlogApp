﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogApp.Domain.Models;

namespace Domain.Interfaces
{
    public interface IArticleRepository
    {
        IEnumerable<Article> GetAllArticles(string search, string tag);

        List<Comment> GetCommentsArticleById(string id);

        
        Article GetArticleById(Guid id);
        void AddArticle(Article article);

        void AddComment(Comment comment);

        void UpdateArticle(Article article);
        void DeleteArticle(Guid id);
        void DeleteComment(Guid id);

    }
}
