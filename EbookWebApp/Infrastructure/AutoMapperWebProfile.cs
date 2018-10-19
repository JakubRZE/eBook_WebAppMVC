using AutoMapper;
using EbookWebApp.Models;
using EbookWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EbookWebApp.Infrastructure
{
    public class AutoMapperWebProfile : AutoMapper.Profile
    {
        public static void Run()
        {
            AutoMapper.Mapper.Initialize(cfg => {
               cfg.AddProfile<AutoMapperWebProfile>();
             });
        }

        public AutoMapperWebProfile()
        {
            CreateMap<Book, BookViewModel>()
                .ReverseMap()
                .ForSourceMember(x => x.Overall, opt => opt.Ignore());

            CreateMap<Order, OrderViewModel>()
               .ReverseMap();
        }

    }
}