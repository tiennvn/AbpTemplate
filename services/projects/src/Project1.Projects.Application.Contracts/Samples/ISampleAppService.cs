using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Project1.Projects.Samples;

public interface ISampleAppService : IApplicationService
{
    Task<SampleDto> GetAsync();

    Task<SampleDto> GetAuthorizedAsync();
}