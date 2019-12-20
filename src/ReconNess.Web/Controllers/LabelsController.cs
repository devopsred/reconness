using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReconNess.Core.Services;
using ReconNess.Entities;
using ReconNess.Web.Dtos;

namespace ReconNess.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LabelsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILabelService labelService;

        public LabelsController(IMapper mapper,
            ILabelService labelService)
        {
            this.mapper = mapper;
            this.labelService = labelService;
        }

        // GET api/labels
        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var labels = await this.labelService.GetAllByCriteriaAsync(c => !c.Deleted, cancellationToken);

            return Ok(this.mapper.Map<List<Label>, List<LabelDto>>(labels));
        }
    }
}
