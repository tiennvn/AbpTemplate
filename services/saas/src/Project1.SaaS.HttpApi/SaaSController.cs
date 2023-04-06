using Project1.SaaS.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Project1.SaaS;

public abstract class SaaSController : AbpControllerBase
{
    protected SaaSController()
    {
        LocalizationResource = typeof(SaaSResource);
    }
}