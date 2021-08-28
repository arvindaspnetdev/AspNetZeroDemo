using Abp.AutoMapper;
using AspnetboilerplateDemo.Authentication.External;

namespace AspnetboilerplateDemo.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
