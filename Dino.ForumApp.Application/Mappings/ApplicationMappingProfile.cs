using AutoMapper;
using Dino.ForumApp.Domain.Models;
using Dino.ForumApp.Application.DTOs;

namespace Dino.ForumApp.Application.Mappings
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            // User mappings
            CreateMap<UserRegistrationDto, User>()
            .ForMember(d => d.Id, s => Guid.NewGuid())
            .ForMember(d => d.PasswordHash, opt => opt.MapFrom((src, dst, _, context) => context.Items["PasswordHash"]));

            CreateMap<UserLoginDto, User>();

            // Post mappings
            CreateMap<PostDto, Post>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.AuthorId, opt => opt.MapFrom((src, dst, _, context) => context.Items["AuthorId"]));

            CreateMap<Post, PostResponse>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Author.Email))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Author.Username))
            .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments));

            // Comment mappings
            CreateMap<CommentDto, Comment>()
                .ForMember(d => d.AuthorId, opt => opt.MapFrom((src, dst, _, context) => context.Items["AuthorId"]));
            CreateMap<Comment, CommentDto>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Author.Email))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Author.Username));
        }
    }
}
