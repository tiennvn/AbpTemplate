using Project1.IdentityService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Project1.IdentityService;

public abstract class IdentityServiceController : AbpControllerBase
{
    protected IdentityServiceController()
    {
        LocalizationResource = typeof(IdentityServiceResource);
    }
}