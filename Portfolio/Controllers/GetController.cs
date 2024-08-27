using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Client.Models;
using Portfolio.Components.Pages;
using Portfolio.Data;
using static Portfolio.Client.Models.ControllersModels;

namespace Portfolio.Controllers
{
    [Route("/[controller]/[action]")]
    [ApiController]
    public class GetController : Controller
    {
        //instances 
        GetData Get = new();
        //vars
        int UserID = 1;
        [HttpGet]
        public async Task<ActionResult<AllUserDetails>> GetUserDetails()
        {
            try
            {
                //get user details 
                var Users = await Get.GetUserDetailsAsync(UserID);
                //get user experience 
                var Experiences = await Get.GetProjectsAsync(UserID);
                //get user skills
                var userSkills = await Get.GetSkillsAsync(UserID);
                //get user education 
                var userEducation = await Get.GetEducationAsync(UserID);

                AllUserDetails userDetails = new AllUserDetails
                {
                    Users = Users,
                    Experiences = Experiences,
                    userSkills = userSkills,
                    userEducation = userEducation
                };

                return Ok(userDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }



    }
}
