﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entity;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class CategoryRepository : DbContext, ICategory
    {
        
        MyContext db = new();

        public void Add(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }
        public Category Update(Category category)
        {
            db.Categories.Attach(category);
            db.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return category;
        }
        public void Delete(Category category)
        {
            db.Categories.Remove(FindWithId(category));
            db.SaveChanges();
        }
        public Category FindWithId(Category category)
        {
            return db.Categories.SingleOrDefault(x => x.Id == category.Id);
        }
        public IEnumerable<Category> GetAll(Category category)
        {
            return db.Categories.AsQueryable();
        }
    }
    public interface ICategory
    {
        void Add(Category category);
        void Delete(Category category);
        Category Update(Category category);
        Category FindWithId(Category category);
        IEnumerable<Category> GetAll(Category category);
    }
}
