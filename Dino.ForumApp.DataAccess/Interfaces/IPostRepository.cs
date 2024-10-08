﻿using Dino.ForumApp.Domain.Models;

namespace Dino.ForumApp.DataAccess.Interfaces
{
    public interface IPostRepository
    {
        Task<int> AddPostAsync(Post post);
        Task<bool> IsPostExists(int postId);
        Task<List<Post>> GetAllPostsAsync();
    }
}
