using AbpIoTest.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AbpIoTest.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class AbpIoTestController : AbpController
    {
        protected AbpIoTestController()
        {
            LocalizationResource = typeof(AbpIoTestResource);
        }
    }
}