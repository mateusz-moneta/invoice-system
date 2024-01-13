using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using InvoiceSystemAPI.Models;
using InvoiceSystemAPI.Services.Abstracts;

namespace InvoiceSystemAPI.Controllers
{
    [ApiController]
    [Route("/api/templates")]
    [Authorize]
    public class TemplatesController : Controller
    {
        private readonly ITemplateService _templateService;

        public TemplatesController(ITemplateService templateService)
        {
            _templateService = templateService;
        }

        [HttpGet]
        public IActionResult GetAllTemplates()
        {
            try
            {
                var templates = _templateService.GetAllTemplatesAsync().Result;

                if (templates != null)
                {
                    return Ok(templates);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetTemplateById(int id)
        {
            try
            {
                var template = _templateService.GetTemplateByIdAsync(id).Result;

                if (template != null)
                {
                    return Ok(template);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<Template> CreateTemplate(Template template)
        {
            try
            {
                _templateService.CreateTemplateAsync(template);
                return CreatedAtAction(nameof(GetTemplateById), new { id = template.Id }, template);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTemplate(int id, Template updatedTemplate)
        {
            try
            {
                var existingTemplate = _templateService.GetTemplateByIdAsync(id).Result;
                if (existingTemplate == null)
                {
                    return NotFound();
                }

                updatedTemplate.Id = id;

                bool isSuccess = _templateService.UpdateTemplateAsync(updatedTemplate).Result;

                if (isSuccess)
                {
                    return NoContent();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTemplate(int id)
        {
            try
            {
                var existingTemplate = _templateService.GetTemplateByIdAsync(id).Result;

                if (existingTemplate == null)
                {
                    return NotFound();
                }

                _templateService.DeleteTemplateAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}