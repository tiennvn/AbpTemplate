using Project1.Administration.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Project1.Administration;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(AdministrationEntityFrameworkCoreTestModule)
    )]
public class AdministrationDomainTestModule : AbpModule
{

}
