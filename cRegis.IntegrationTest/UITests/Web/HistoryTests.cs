﻿using cRegis.Web;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace cRegis.Tests.IntegrationTest.UITests
{
    public class HistoryTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        public HistoryTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        [Fact]
        public async Task HttpGetPageTest()
        {
            //    var client = _factory.WithWebHostBuilder(builder =>
            //    {
            //        builder.ConfigureServices(services =>
            //        {
            //            services.AddAuthentication("Test")
            //               .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>(
            //                   "Test", options => { });

            //        });
            //    })
            //.CreateClient(new WebApplicationFactoryClientOptions
            //{
            //    AllowAutoRedirect = false
            //});

            //    client.DefaultRequestHeaders.Authorization =
            //    new AuthenticationHeaderValue("Test");
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/Home/History");

            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}
