using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace AspnetboilerplateDemo.Localization
{
    public static class AspnetboilerplateDemoLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(AspnetboilerplateDemoConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(AspnetboilerplateDemoLocalizationConfigurer).GetAssembly(),
                        "AspnetboilerplateDemo.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
