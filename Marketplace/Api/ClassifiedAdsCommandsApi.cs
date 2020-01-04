using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Marketplace.Api.Contracts.ClassifiedAds;

namespace Marketplace.Api
{
    [Route("/ad")]
    public class ClassifiedAdsCommandsApi : Controller
    {
        private readonly ClassifiedAdsApplicationService applicationService;

        public ClassifiedAdsCommandsApi(ClassifiedAdsApplicationService applicationService)
        {
            this.applicationService = applicationService;
        }
    [HttpPost]
    public async Task<IActionResult> Post(V1.Create request)
    {
            applicationService.Handle(request);
            return Ok();
    }

    [Route("name")]
    [HttpPut]
    public async Task<IActionResult> Put(V1.SetTitle request)
    {
            await applicationService.Handle(request);
            return Ok();
    }
    }
}
