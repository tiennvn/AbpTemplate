﻿using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;

namespace Project1.Projects;

[DependsOn(
    typeof(ProjectsDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
)]
public class ProjectsApplicationContractsModule : AbpModule
{
}