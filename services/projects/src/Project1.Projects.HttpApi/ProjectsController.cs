using Project1.Projects.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Project1.Projects;

public abstract class ProjectsController : AbpControllerBase
{
    protected ProjectsController()
    {
        LocalizationResource = typeof(ProjectsResource);
    }
}