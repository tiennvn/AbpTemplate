using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement;

namespace Project1.SaaS;

[DependsOn(
    typeof(SaaSDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
)]
[DependsOn(typeof(AbpTenantManagementApplicationContractsModule))]
public class SaaSApplicationContractsModule : AbpModule
{
}