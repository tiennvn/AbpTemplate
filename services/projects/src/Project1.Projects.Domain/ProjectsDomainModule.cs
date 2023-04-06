using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Project1.Projects;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(ProjectsDomainSharedModule)
)]
public class ProjectsDomainModule : AbpModule
{
}