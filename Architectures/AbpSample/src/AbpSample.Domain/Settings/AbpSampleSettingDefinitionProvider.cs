using Volo.Abp.Settings;

namespace AbpSample.Settings
{
    public class AbpSampleSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(AbpSampleSettings.MySetting1));
        }
    }
}
