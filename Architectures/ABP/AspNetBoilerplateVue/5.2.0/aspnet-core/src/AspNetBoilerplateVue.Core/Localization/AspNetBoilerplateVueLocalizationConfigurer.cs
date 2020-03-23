using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace AspNetBoilerplateVue.Localization
{
    public static class AspNetBoilerplateVueLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(AspNetBoilerplateVueConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(AspNetBoilerplateVueLocalizationConfigurer).GetAssembly(),
                        "AspNetBoilerplateVue.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
