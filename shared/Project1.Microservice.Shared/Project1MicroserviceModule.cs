using Project1.Administration.EntityFrameworkCore;
using Project1.Hosting.Shared;
using Volo.Abp.Modularity;

namespace Project1.Microservice.Shared;

[DependsOn(
    typeof(Project1HostingModule),
    typeof(AdministrationEntityFrameworkCoreModule)
)]
public class Project1MicroserviceModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
    }
}