using System.Threading.Tasks;
using AspnetboilerplateDemo.Configuration.Dto;

namespace AspnetboilerplateDemo.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
