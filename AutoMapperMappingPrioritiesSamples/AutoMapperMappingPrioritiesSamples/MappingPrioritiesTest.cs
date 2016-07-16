using System;
using AutoMapper;

using AutoMapperMappingPrioritiesSamples.Models;
using AutoMapperMappingPrioritiesSamples.ViewModels;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoMapperMappingPrioritiesSamples
{
    [TestClass]
    public class MappingPrioritiesTest
    {
        private MapperConfiguration mapperConfiguration;
        private IMapper mapper;
        private TaiwanCustomer taiwanCustomer;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mapperConfiguration =
                new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Customer, CustomerViewModel>()
                       .Include<TaiwanCustomer, TaiwanCustomerViewModel>()
                       .ForMember(d => d.Id, o => o.MapFrom(s => default(string)));

                    cfg.CreateMap<TaiwanCustomer, TaiwanCustomerViewModel>();
                });

            this.mapper = mapperConfiguration.CreateMapper();

            this.taiwanCustomer = new TaiwanCustomer()
            {
                Id = Guid.NewGuid(),
                Name = "Johnny",
                City = "Taipei"
            };
        }

        [TestMethod]
        public void Test_Customer_map_to_CustomerViewModel_Id_should_be_null_or_empty()
        {
            CustomerViewModel taiwanCustomerViewModel = this.mapper.Map<TaiwanCustomerViewModel>(this.taiwanCustomer);

            taiwanCustomerViewModel.Id.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void Test_Customer_map_to_CustomerViewModel_Id_should_not_be_null_or_empty()
        {
            CustomerViewModel taiwanCustomerViewModel = this.mapper.Map<TaiwanCustomerViewModel>(this.taiwanCustomer);

            taiwanCustomerViewModel.Id.Should().NotBeNullOrEmpty();
        }
    }
}