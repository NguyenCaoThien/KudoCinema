using AutoMapper;
using KudoCinema.Dtos;
using KudoCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KudoCinema.App_Start
{
    public class AutoMapperConfig
    {
        public static IMapper Mapper;
        public static void Init()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CustomerDto, Customer>());

            Mapper = config.CreateMapper();
        }
    }
}