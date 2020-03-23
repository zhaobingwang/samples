using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace AspNetBoilerplate.Localization
{
    public static class AspNetBoilerplateLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(AspNetBoilerplateConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(AspNetBoilerplateLocalizationConfigurer).GetAssembly(),
                        "AspNetBoilerplate.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
