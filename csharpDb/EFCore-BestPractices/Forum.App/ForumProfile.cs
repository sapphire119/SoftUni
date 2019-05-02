using AutoMapper;
using Forum.App.ModelsDto;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.App
{
    public class ForumProfile : Profile
    {
        public ForumProfile()
        {
            CreateMap<User, User>();

            //Подобно на Fluent API-a със Конфигурациите
            CreateMap<Post, PostDetailsDto>()
                        .ForMember(dto => dto.ReplyCount,
                                    cfg => cfg.MapFrom(post => post.Replies.Count));

            CreateMap<Post, ReplyDto>();

            CreateMap<Post, PostDto>()
                    .ForMember(dto => dto.AuthorUsername,
                                cfg => cfg.MapFrom(post => post.Author.Username));
        }
    }
}
