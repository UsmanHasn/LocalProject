using Data.Concrete;
using Data.Interface;
using Domain.Entities;
using Service.Interface;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concrete
{
    public  class TestService : ITestService
    {
        //IRepository<UserProfile> _repository;

        //public TestService(IRepository<UserProfile> repository)
        //{
        //    _repository = repository;
        //}
        public List<TestModel> GetAllData()
        {
            //if (roleName == "SystemAdmin")
            //{
            //    //10
            //}
            //else if (roleName == "SystemAdmin")
            //{
            //    //5
            //}
            List<TestModel> model = new List<TestModel>();
            model.Add(new TestModel()
            {
                Id = 1,
                Name = "Name One",
                Description = "Description of One",
            });
            model.Add(new TestModel()
            {
                Id = 2,
                Name = "Name Two",
                Description = "Description of Two",
            });
            model.Add(new TestModel()
            {
                Id = 3,
                Name = "Name Three",
                Description = "Description of Three",
            });
            model.Add(new TestModel()
            {
                Id = 4,
                Name = "Name Four",
                Description = "Description of Foure",
            });
            model.Add(new TestModel()
            {
                Id = 1,
                Name = "Name One",
                Description = "Description of One",
            });
            model.Add(new TestModel()
            {
                Id = 2,
                Name = "Name Two",
                Description = "Description of Two",
            });
            model.Add(new TestModel()
            {
                Id = 3,
                Name = "Name Three",
                Description = "Description of Three",
            });
            model.Add(new TestModel()
            {
                Id = 1,
                Name = "Name One",
                Description = "Description of One",
            });
            model.Add(new TestModel()
            {
                Id = 2,
                Name = "Name Two",
                Description = "Description of Two",
            });
            model.Add(new TestModel()
            {
                Id = 3,
                Name = "Name Three",
                Description = "Description of Three",
            });
            model.Add(new TestModel()
            {
                Id = 4,
                Name = "Name Four",
                Description = "Description of Foure",
            });
            model.Add(new TestModel()
            {
                Id = 1,
                Name = "Name One",
                Description = "Description of One",
            });
            model.Add(new TestModel()
            {
                Id = 2,
                Name = "Name Two",
                Description = "Description of Two",
            });
            model.Add(new TestModel()
            {
                Id = 3,
                Name = "Name Three",
                Description = "Description of Three",
            });
            model.Add(new TestModel()
            {
                Id = 1,
                Name = "Name One",
                Description = "Description of One",
            });
            model.Add(new TestModel()
            {
                Id = 2,
                Name = "Name Two",
                Description = "Description of Two",
            });
            model.Add(new TestModel()
            {
                Id = 3,
                Name = "Name Three",
                Description = "Description of Three",
            });
            model.Add(new TestModel()
            {
                Id = 4,
                Name = "Name Four",
                Description = "Description of Foure",
            });
            model.Add(new TestModel()
            {
                Id = 1,
                Name = "Name One",
                Description = "Description of One",
            });
            model.Add(new TestModel()
            {
                Id = 2,
                Name = "Name Two",
                Description = "Description of Two",
            });
            model.Add(new TestModel()
            {
                Id = 3,
                Name = "Name Three",
                Description = "Description of Three",
            });
            model.Add(new TestModel()
            {
                Id = 1,
                Name = "Name One",
                Description = "Description of One",
            });
            model.Add(new TestModel()
            {
                Id = 2,
                Name = "Name Two",
                Description = "Description of Two",
            });
            model.Add(new TestModel()
            {
                Id = 3,
                Name = "Name Three",
                Description = "Description of Three",
            });
            model.Add(new TestModel()
            {
                Id = 4,
                Name = "Name Four",
                Description = "Description of Foure",
            });
            model.Add(new TestModel()
            {
                Id = 1,
                Name = "Name One",
                Description = "Description of One",
            });
            model.Add(new TestModel()
            {
                Id = 2,
                Name = "Name Two",
                Description = "Description of Two",
            });
            model.Add(new TestModel()
            {
                Id = 3,
                Name = "Name Three",
                Description = "Description of Three",
            });
            model.Add(new TestModel()
            {
                Id = 1,
                Name = "Name One",
                Description = "Description of One",
            });
            model.Add(new TestModel()
            {
                Id = 2,
                Name = "Name Two",
                Description = "Description of Two",
            });
            model.Add(new TestModel()
            {
                Id = 3,
                Name = "Name Three",
                Description = "Description of Three",
            });
            model.Add(new TestModel()
            {
                Id = 4,
                Name = "Name Four",
                Description = "Description of Foure",
            });
            model.Add(new TestModel()
            {
                Id = 1,
                Name = "Name One",
                Description = "Description of One",
            });
            model.Add(new TestModel()
            {
                Id = 2,
                Name = "Name Two",
                Description = "Description of Two",
            });
            model.Add(new TestModel()
            {
                Id = 3,
                Name = "Name Three",
                Description = "Description of Three",
            });
            model.Add(new TestModel()
            {
                Id = 1,
                Name = "Name One",
                Description = "Description of One",
            });
            model.Add(new TestModel()
            {
                Id = 2,
                Name = "Name Two",
                Description = "Description of Two",
            });
            model.Add(new TestModel()
            {
                Id = 3,
                Name = "Name Three",
                Description = "Description of Three",
            });
            model.Add(new TestModel()
            {
                Id = 4,
                Name = "Name Four",
                Description = "Description of Foure",
            });
            model.Add(new TestModel()
            {
                Id = 1,
                Name = "Name One",
                Description = "Description of One",
            });
            model.Add(new TestModel()
            {
                Id = 2,
                Name = "Name Two",
                Description = "Description of Two",
            });
            model.Add(new TestModel()
            {
                Id = 3,
                Name = "Name Three",
                Description = "Description of Three",
            });
            model.Add(new TestModel()
            {
                Id = 1,
                Name = "Name One",
                Description = "Description of One",
            });
            model.Add(new TestModel()
            {
                Id = 2,
                Name = "Name Two",
                Description = "Description of Two",
            });
            model.Add(new TestModel()
            {
                Id = 3,
                Name = "Name Three",
                Description = "Description of Three",
            });
            model.Add(new TestModel()
            {
                Id = 4,
                Name = "Name Four",
                Description = "Description of Foure",
            });
            model.Add(new TestModel()
            {
                Id = 1,
                Name = "Name One",
                Description = "Description of One",
            });
            model.Add(new TestModel()
            {
                Id = 2,
                Name = "Name Two",
                Description = "Description of Two",
            });
            model.Add(new TestModel()
            {
                Id = 3,
                Name = "Name Three",
                Description = "Description of Three",
            });
            model.Add(new TestModel()
            {
                Id = 1,
                Name = "Name One",
                Description = "Description of One",
            });
            model.Add(new TestModel()
            {
                Id = 2,
                Name = "Name Two",
                Description = "Description of Two",
            });
            model.Add(new TestModel()
            {
                Id = 3,
                Name = "Name Three",
                Description = "Description of Three",
            });
            model.Add(new TestModel()
            {
                Id = 4,
                Name = "Name Four",
                Description = "Description of Foure",
            });
            model.Add(new TestModel()
            {
                Id = 1,
                Name = "Name One",
                Description = "Description of One",
            });
            model.Add(new TestModel()
            {
                Id = 2,
                Name = "Name Two",
                Description = "Description of Two",
            });
            model.Add(new TestModel()
            {
                Id = 3,
                Name = "Name Three",
                Description = "Description of Three",
            });
            model.Add(new TestModel()
            {
                Id = 1,
                Name = "Name One",
                Description = "Description of One",
            });
            model.Add(new TestModel()
            {
                Id = 2,
                Name = "Name Two",
                Description = "Description of Two",
            });
            model.Add(new TestModel()
            {
                Id = 3,
                Name = "Name Three",
                Description = "Description of Three",
            });
            model.Add(new TestModel()
            {
                Id = 4,
                Name = "Name Four",
                Description = "Description of Foure",
            });
            model.Add(new TestModel()
            {
                Id = 1,
                Name = "Name One",
                Description = "Description of One",
            });
            model.Add(new TestModel()
            {
                Id = 2,
                Name = "Name Two",
                Description = "Description of Two",
            });
            model.Add(new TestModel()
            {
                Id = 3,
                Name = "Name Three",
                Description = "Description of Three",
            });
            model.Add(new TestModel()
            {
                Id = 1,
                Name = "Name One",
                Description = "Description of One",
            });
            model.Add(new TestModel()
            {
                Id = 2,
                Name = "Name Two",
                Description = "Description of Two",
            });
            model.Add(new TestModel()
            {
                Id = 3,
                Name = "Name Three",
                Description = "Description of Three",
            });
            model.Add(new TestModel()
            {
                Id = 4,
                Name = "Name Four",
                Description = "Description of Foure",
            });
            model.Add(new TestModel()
            {
                Id = 1,
                Name = "Name One",
                Description = "Description of One",
            });
            model.Add(new TestModel()
            {
                Id = 2,
                Name = "Name Two",
                Description = "Description of Two",
            });
            model.Add(new TestModel()
            {
                Id = 3,
                Name = "Name Three",
                Description = "Description of Three",
            });
            model.Add(new TestModel()
            {
                Id = 1,
                Name = "Name One",
                Description = "Description of One",
            });
            model.Add(new TestModel()
            {
                Id = 2,
                Name = "Name Two",
                Description = "Description of Two",
            });
            model.Add(new TestModel()
            {
                Id = 3,
                Name = "Name Three",
                Description = "Description of Three",
            });
            model.Add(new TestModel()
            {
                Id = 4,
                Name = "Name Four",
                Description = "Description of Foure",
            });
            model.Add(new TestModel()
            {
                Id = 1,
                Name = "Name One",
                Description = "Description of One",
            });
            model.Add(new TestModel()
            {
                Id = 2,
                Name = "Name Two",
                Description = "Description of Two",
            });
            model.Add(new TestModel()
            {
                Id = 3,
                Name = "Name Three",
                Description = "Description of Three",
            });
            model.Add(new TestModel()
            {
                Id = 1,
                Name = "Name One",
                Description = "Description of One",
            });
            model.Add(new TestModel()
            {
                Id = 2,
                Name = "Name Two",
                Description = "Description of Two",
            });
            model.Add(new TestModel()
            {
                Id = 3,
                Name = "Name Three",
                Description = "Description of Three",
            });
            model.Add(new TestModel()
            {
                Id = 4,
                Name = "Name Four",
                Description = "Description of Foure",
            });
            model.Add(new TestModel()
            {
                Id = 1,
                Name = "Name One",
                Description = "Description of One",
            });
            model.Add(new TestModel()
            {
                Id = 2,
                Name = "Name Two",
                Description = "Description of Two",
            });
            model.Add(new TestModel()
            {
                Id = 3,
                Name = "Name Three",
                Description = "Description of Three",
            });
            model.Add(new TestModel()
            {
                Id = 1,
                Name = "Name One",
                Description = "Description of One",
            });
            model.Add(new TestModel()
            {
                Id = 2,
                Name = "Name Two",
                Description = "Description of Two",
            });
            model.Add(new TestModel()
            {
                Id = 3,
                Name = "Name Three",
                Description = "Description of Three",
            });
            model.Add(new TestModel()
            {
                Id = 4,
                Name = "Name Four",
                Description = "Description of Foure",
            });
            model.Add(new TestModel()
            {
                Id = 1,
                Name = "Name One",
                Description = "Description of One",
            });
            model.Add(new TestModel()
            {
                Id = 2,
                Name = "Name Two",
                Description = "Description of Two",
            });
            model.Add(new TestModel()
            {
                Id = 3,
                Name = "Name Three",
                Description = "Description of Three",

            });
            model.Add(new TestModel()
            {
                Id = 4,
                Name = "Name Four",
                Description = "Description of Foure",
            });
            model.Add(new TestModel()
            {
                Id = 1,
                Name = "Name One",
                Description = "Description of One",
            });
            model.Add(new TestModel()
            {
                Id = 2,
                Name = "Name Two",
                Description = "Description of Two",
            });
            model.Add(new TestModel()
            {
                Id = 3,
                Name = "Name Three",
                Description = "Description of Three",
            });
            model.Add(new TestModel()
            {
                Id = 4,
                Name = "Name Four",
                Description = "Description of Foure",
            });
            model.Add(new TestModel()
            {
                Id = 1,
                Name = "Name One",
                Description = "Description of One",
            });
            model.Add(new TestModel()
            {
                Id = 2,
                Name = "Name Two",
                Description = "Description of Two",
            });
            model.Add(new TestModel()
            {
                Id = 3,
                Name = "Name Three",
                Description = "Description of Three",
            });
            model.Add(new TestModel()
            {
                Id = 4,
                Name = "Name Four",
                Description = "Description of Foure",
            });
            return model;
        }
    }
}
