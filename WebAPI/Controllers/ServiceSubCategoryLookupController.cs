using Data.Context;
using Domain.Entities;
using Domain.Entities.Lookups;
using Domain.Modeles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Concrete;
using Service.Interface;
using Service.Models;
using System.Net;
using Microsoft.AspNetCore.Http;
namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/ServiceSubCategoryLookup/")]
    public class ServiceSubCategoryLookupController : Controller
    {
       
        private readonly IServiceSubCategoryLookupService? serviceSubCategory;
        private readonly ApplicationDbContext _context;

        public ServiceSubCategoryLookupController(IServiceSubCategoryLookupService _serviceSub, ApplicationDbContext context) 
        {
            serviceSubCategory = _serviceSub;
           _context = context;
        }
      
     
        [HttpGet]
        [Route("GetAllService")]
        public IActionResult GetAllService()
        {
            List<Domain.Modeles.ServicesModel> model = new List<Domain.Modeles.ServicesModel>();
            try
            {
                model = serviceSubCategory.GetAllServices();
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
           
        }

        [HttpPut]
        [Route("UpdateService")]
        //[Route("UpdateService")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int ServiceId, Services issue)
        {
            try
            {
                _context.Entry(issue).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
            
        }

        //[HttpPut]
        //[Route("UpdateServiceImage")]
        ////[Route("UpdateService")]
        ////[ProducesResponseType(StatusCodes.Status204NoContent)]
        ////[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> UpdateImage(int ServiceId,[FromForm] Services issue)
        //{
        //    _context.Entry(issue).State = EntityState.Modified;
        //    await _context.SaveChangesAsync();
        //    return NoContent();
        //}


        [HttpDelete]
        [Route("DeleteService")]
        //[Route("DeleteService")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int ServiceId)
        {
            try
            {
                var issueToDelete = await _context.Services.FindAsync(ServiceId);
                if (issueToDelete == null) return NotFound();
                _context.Services.Remove(issueToDelete);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
          
        }



        //[HttpGet]
        //[Route("GetAllServiceLookup")]
        //public IActionResult GetAllServiceLookup()
        //{
        //    List<Service.Models.ServiceCategoryLookup> model = new List<Service.Models.ServiceCategoryLookup>();
        //    model = serviceSubCategory.GetAllServiceLookup();
        //    return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        //}

        [HttpPut]
        [Route("UpdateServiceCategoryLookup")]
        //[Route("UpdateService")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateServiceCategoryLookup(int ServiceCategoryId, Domain.Entities.ServiceCategoryLookup issue)
        {
            try
            {
                _context.Entry(issue).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }


        [HttpDelete]
        [Route("DeleteServiceCategoryLookup")]
        //[Route("DeleteService")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteServiceCategoryLookup(int ServiceCategoryId)
        {
            try
            {
                var ServiceCategoryLookupToDelete = await _context.ServiceCategoryLookup.FindAsync(ServiceCategoryId);
                if (ServiceCategoryLookupToDelete == null) return NotFound();
                _context.ServiceCategoryLookup.Remove(ServiceCategoryLookupToDelete);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }



        [HttpGet]
        [Route("GetAllServiceSubCategoryLookup")]
        public IActionResult GetAllServiceSubCategoryLookup()
        {
            List<ServiceSubCategoryLookupModel> model = new List<ServiceSubCategoryLookupModel>();
            try
            {
                model = serviceSubCategory.GetAllSubService();
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpPut]
        [Route("UpdateServiceSubCategoryLookup")]
        //[Route("UpdateService")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateServiceSubCategoryLookup(int ServiceSubCategoryId, ServiceSubCategoryLookup issue)
        {
            try
            {
                _context.Entry(issue).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpDelete]
        [Route("DeleteServiceSubCategoryLookup")]
        //[Route("DeleteService")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteServiceSubCategoryLookup(int ServiceSubCategoryId)
        {
            try
            {
                var ServiceSubCategoryLookupToDelete = await _context.ServiceSubCategoryLookup.FindAsync(ServiceSubCategoryId);
                if (ServiceSubCategoryLookupToDelete == null) return NotFound();
                _context.ServiceSubCategoryLookup.Remove(ServiceSubCategoryLookupToDelete);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        //[HttpGet]
        //[Route("getUserbyId")]
        //public IActionResult GetUserById(int ServiceId)
        //{
        //    Domain.Modeles.ServicesModel model = new Domain.Modeles.ServicesModel();
        //    model = serviceSubCategory.GetUserById(ServiceId);
        //    return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        //}
        //[HttpPost]
        //[Route("InsertUser")]
        //public IActionResult Add(Domain.Modeles.ServicesModel model, string ServiceId)
        //{
        //    if (model.ServiceId > 0)
        //    {
        //        Domain.Modeles.ServicesModel _userModel = serviceSubCategory.GetUserById(model.ServiceId);
        //       // model.CreatedDate = _userModel.CreatedDate;
        //       // model.CreatedBy = _userModel.CreatedBy;
        //        serviceSubCategory.UpdateUser(model, ServiceId);
        //    }
        //    else
        //    {
        //        serviceSubCategory.Add(model, ServiceId);
        //    }
        //    return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        //}


        [HttpGet]
        [Route("GetByServiceId")]
        [ProducesResponseType(typeof(Services), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var issue = await _context.Services.FindAsync(id);
                return issue == null ? NotFound() : Ok(issue);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpPost]
        [Route("AddService")]
        [ProducesResponseType(typeof(Services), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Services issue)
        {
            try
            {
                await _context.Services.AddAsync(issue);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetById), new { id = issue.ServiceSubCategoryId }, issue);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
/// <summary>
/// /////////////////////
/// </summary>
/// <param name="id"></param>
/// <returns></returns>
        [HttpGet]
        [Route("GetByServiceSubCategoryLookupId")]
        [ProducesResponseType(typeof(ServiceSubCategoryLookup), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByServiceSubCategoryLookupid(int id)
        {
            try
            {
                var issue = await _context.ServiceSubCategoryLookup.FindAsync(id);
                return issue == null ? NotFound() : Ok(issue);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpPost]
        [Route("AddServiceSubCategoryLookup")]
        [ProducesResponseType(typeof(ServiceSubCategoryLookup), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateServiceSubCategoryLookup(ServiceSubCategoryLookup issue)
        {
            try
            {
                await _context.ServiceSubCategoryLookup.AddAsync(issue);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetById), new { id = issue.ServiceSubCategoryId }, issue);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        ////////////////////////////////////////////
        ///

        [HttpGet]
        [Route("GetByServiceCategoryLookupId")]
        [ProducesResponseType(typeof(Domain.Entities.ServiceCategoryLookup), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByServiceCategoryLookupid(int id)
        {
            try
            {
                var issue = await _context.ServiceCategoryLookup.FindAsync(id);
                return issue == null ? NotFound() : Ok(issue);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
            
        }

        [HttpPost]
        [Route("AddServiceCategoryLookup")]
        [ProducesResponseType(typeof(Domain.Entities.ServiceCategoryLookup), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateServiceCategoryLookup(Domain.Entities.ServiceCategoryLookup issue)
        {
            try
            {
                await _context.ServiceCategoryLookup.AddAsync(issue);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetById), new { id = issue.ServiceCategoryId }, issue);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }


        [HttpGet]
        [Route("BindServiceCat")]
        public IActionResult BindServiceCat()
        {

            List<Service.Models.ServiceCategoryLookup> model = new List<Service.Models.ServiceCategoryLookup>();
            try
            {
                model = serviceSubCategory.BindServiceCategory();
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpPost]
        [Route("AddServiceSubCat")]
        public IActionResult AddServiceSubCat(ServiceSubCategoryLookupModel model,string userName)
        {
            try
            {
                if (model.Id > 0)
                {
                    serviceSubCategory.UpdateServiceSubCat(model.Id, model, userName);
                }
                else
                {
                    serviceSubCategory.AddServiceSubCat(model, userName);
                }
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpGet]
        [Route("GetAllServiceSubCategoryLookupById")]
        public IActionResult GetAllServiceSubCategoryLookupById(int id)
        {
            try
            {
                var model = serviceSubCategory.GetDataById(id);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }


        [HttpPost]
        [Route("DeleteServiceSubcat")]
        public void DeleteServiceSubcat(int id)
        {
            try
            {
                serviceSubCategory.DeleteServiceSubCat(id);
                new JsonResult(new { data = true, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                 new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
    }
}
