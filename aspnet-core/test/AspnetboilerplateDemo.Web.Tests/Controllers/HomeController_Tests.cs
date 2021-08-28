using System.Threading.Tasks;
using AspnetboilerplateDemo.Models.TokenAuth;
using AspnetboilerplateDemo.Web.Controllers;
using Shouldly;
using Xunit;

namespace AspnetboilerplateDemo.Web.Tests.Controllers
{
    public class HomeController_Tests: AspnetboilerplateDemoWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}