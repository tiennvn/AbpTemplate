using Volo.Abp.Modularity;

namespace Project1.Projects;

[DependsOn(
    typeof(ProjectsApplicationModule),
    typeof(ProjectsDomainTestModule)
    )]
public class ProjectsApplicationTestModule : AbpModule
{

}
