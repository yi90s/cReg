﻿using cRegis.Core.Entities;
using cRegis.Core.Interfaces;
using cRegis.Core.Services;
using cRegis.Web.test.Infrastructure;
using Xunit;

namespace cRegis.UnitTests.UnitTests.Core.Services
{
    public class FacultyServiceTest : TestBase
    {
        private readonly IFacultyService _facultyService;
        public FacultyServiceTest()
        {
            _facultyService = new FacultyService(_context);
        }

        [Fact]
        public void nullFindFacultyById()
        {
            Faculty c = _facultyService.getFaculty(-1);
            Assert.Null(c);
        }

        //TODO : writting test against all the methods in cRegis.Core.Service.FacultyService

        [Fact]
        public void GetFacultyTest_HappyPath()
        {
            Faculty faculty = _facultyService.getFaculty(1);
            Assert.NotNull(faculty);
            Assert.True(faculty.facultyId == 1);
            Assert.Equal("Computer Science", faculty.facultyName);
            Assert.True(faculty.graduateCreditHours == 60);
        }

        [Fact]
        public void GetFacultyTest_NonExistantFaculty()
        {
            Faculty faculty = _facultyService.getFaculty(-1);
            Assert.Null(faculty);
        }
    }
}
