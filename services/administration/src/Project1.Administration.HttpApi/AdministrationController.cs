using Project1.Administration.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Project1.Administration;

public abstract class AdministrationController : AbpControllerBase
{
    protected AdministrationController()
    {
        LocalizationResource = typeof(AdministrationResource);
    }
}