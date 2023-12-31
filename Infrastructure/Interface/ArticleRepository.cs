﻿using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogApp.Domain.Models;
using TechBlogApp.Persistence;

namespace Infrastructure.Interface
{
    public class ArticleRepository : IArticleRepository 
    {
        private readonly ApplicationDbContext _context;

        public ArticleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Article> GetAllArticles(string search, string tag)
        {
            if (!string.IsNullOrEmpty(search))
            {
                return _context.Articles.Include(n => n.User).Where(n => n.Title.Contains(search)).ToList();

            }
            if (!string.IsNullOrEmpty(tag))
            {
                return _context.Articles.Include(n => n.User).Where(n => n.Tags.Contains(tag)).ToList();

            }
            return _context.Articles.Include(n => n.User).ToList();

        }

        public Article GetArticleById(Guid id)
        {
            return _context.Articles.Include(n => n.User).FirstOrDefault(n=>n.ArticleId == id);

        }

        public List<Comment>  GetCommentsArticleById(string id)
        {
            return _context.Comments.Include(u=>u.User).Where(u=>u.ArticleId == id).ToList();

        }


        public void AddArticle(Article article)
        {
            _context.Articles.Add(article);
            _context.SaveChanges();
        }
        public void AddComment(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        
        public void UpdateArticle(Article article)
        {
            _context.Update(article);
            _context.SaveChanges();
        }

        public void DeleteArticle(Guid id)
        {
            var article = _context.Articles.Find(id);
            _context.Articles.Remove(article);
            _context.SaveChanges();
        }

         public void DeleteComment(Guid id)
        {
            var comment = _context.Comments.Find(id);
            _context.Comments.Remove(comment);
            _context.SaveChanges();
        }

        
    }
}

