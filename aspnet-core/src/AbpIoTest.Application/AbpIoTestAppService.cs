using System;
using System.Collections.Generic;
using System.Text;
using AbpIoTest.Localization;
using Volo.Abp.Application.Services;

namespace AbpIoTest
{
    /* Inherit your application services from this class.
     */
    public abstract class AbpIoTestAppService : ApplicationService
    {
        protected AbpIoTestAppService()
        {
            LocalizationResource = typeof(AbpIoTestResource);
        }
    }
}
