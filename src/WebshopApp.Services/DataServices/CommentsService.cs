﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebshopApp.Data.Common;
using WebshopApp.Models;
using WebshopApp.Services.DataServices.Contracts;
using WebshopApp.Services.MappingServices;
using WebshopApp.Services.Models.InputModels;
using WebshopApp.Services.Models.ViewModels;

namespace WebshopApp.Services.DataServices
{
    public class CommentsService : ICommentsService
    {
        private readonly IRepository<Comment> commentsRepository;

        public CommentsService(IRepository<Comment> commentsRepository)
        {
            this.commentsRepository = commentsRepository;
        }

        public IEnumerable<CommentViewModel> GetAll()
        {
            var models = this.commentsRepository.All().To<CommentViewModel>();

            return models;
        }

        public IEnumerable<CommentViewModel> GetAllByProduct(int id)
        {
            var exists = this.commentsRepository.All()
                .Where(c => c.ProductId == id).Any();

            if (!exists)
            {
                throw new ArgumentException("There are no comments for this product Id");
            }

            var models = this.commentsRepository.All()
                .Where(c => c.ProductId == id)
                .To<CommentViewModel>();

            return models;
        }

        public async Task<int> Add(CreateCommentInputModel model)
        {
            var comment = new Comment
            {
                Content = model.Content,
                ProductId = model.ProductId,
                UserId = model.UserId
            };

            await this.commentsRepository.AddAsync(comment);
            await this.commentsRepository.SaveChangesAsync();

            var id = commentsRepository.All().Single(c => c.Content.Equals(model.Content)).Id;

            return id;
        }

        public async Task<int> Edit(CommentViewModel model)
        {
            var commentExists = commentsRepository.All()
                .Any(x => x.Id == model.Id);

            if (!commentExists)
            {
                throw new KeyNotFoundException();
            }

            var comment = commentsRepository.All().First(x => x.Id == model.Id);
            comment.Content = model.Content;

            var id = await this.commentsRepository.Update(comment);

            return comment.Id;
        }

        public async Task<int> Delete(int id)
        {
            var comment = this.commentsRepository.All()
                .FirstOrDefault(c => c.Id == id);

            if (comment == null)
            {
                throw new KeyNotFoundException();
            }

            var index = await this.commentsRepository.Delete(comment);

            return index;
        }

        public CommentViewModel GetById(int id)
        {
            var model = commentsRepository.All()
                .Where(c => c.Id == id)
                .To<CommentViewModel>()
                .FirstOrDefault();

            if (model == null)
            {
                throw new KeyNotFoundException();
            }

            return model;
        }      
    }
}
