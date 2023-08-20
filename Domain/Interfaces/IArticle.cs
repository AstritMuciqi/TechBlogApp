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
        IEnumerable<Article> GetAllArticles(string search);
        Article GetArticleById(Guid id);
        void AddArticle(Article article);
        void UpdateArticle(Article article);
        void DeleteArticle(Guid id);
    }
}
