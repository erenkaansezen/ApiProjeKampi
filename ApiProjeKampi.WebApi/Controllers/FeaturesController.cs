using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Dtos.FeatureDtos;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;
        public FeaturesController(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;

        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var features = _context.Features.ToList();
            return Ok(_mapper.Map<List<ResultFeatureDto>>(features));
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto featureDto)
        {
            var feature = _mapper.Map<Entities.Feature>(featureDto);
            _context.Features.Add(feature);
            _context.SaveChanges();
            return Ok("Özellik başarıyla eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var feature = _context.Features.Find(id);
            _context.Features.Remove(feature);
            _context.SaveChanges();
            return Ok("Özellik başarıyla silindi");
        }

        [HttpGet("GetFeature")]
        public IActionResult GetFeature(int id)
        {
            var feature = _context.Features.Find(id);
            return Ok(feature);
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var feature = _mapper.Map<Entities.Feature>(updateFeatureDto);
            _context.Features.Update(feature);
            _context.SaveChanges();
            return Ok("Özellik güncelleme işlemi başarılı");
        }
    }
}
