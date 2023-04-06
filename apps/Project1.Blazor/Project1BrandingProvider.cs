using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Project1.Blazor;

[Dependency(ReplaceServices = true)]
public class Project1BrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Project1";
}
