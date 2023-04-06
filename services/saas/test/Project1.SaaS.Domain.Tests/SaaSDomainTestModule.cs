﻿using Project1.SaaS.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Project1.SaaS;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(SaaSEntityFrameworkCoreTestModule)
    )]
public class SaaSDomainTestModule : AbpModule
{

}
