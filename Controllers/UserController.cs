using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using User_Lib;
using WebApp.Models;
using WebApp.Models.DTO;
using WebApp.Services.IServices;

namespace WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper  _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<IActionResult> IndexUser() 
        {

            List<UserDTO> list = new();
            var response = await _userService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));

            if(response != null )
            {
                list = JsonConvert.DeserializeObject<List<UserDTO>>(Convert.ToString(response.Results));

            }

            return View(list);
        }
		public async Task<IActionResult> CreateUser()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
        [Authorize(Roles ="IT_ADMIN")]
		public async Task<IActionResult> CreateUser(UserCreateDTO model)
		{
			if (ModelState.IsValid)
			{

				var response = await _userService.CreateAsync<APIResponse>(model, HttpContext.Session.GetString(SD.SessionToken));
				if (response != null && response.IsSuccess)
				{
					return RedirectToAction(nameof(IndexUser));
				}
			}
			return View(model);
		}
        public async Task<IActionResult> UpdateUser(int Id)
        {
            var response = await _userService.GetAsync<APIResponse>(Id ,HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                UserDTO model = JsonConvert.DeserializeObject<UserDTO>(Convert.ToString(response.Results));
                return View(_mapper.Map<UserUpdateDTO>(model));
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "IT_ADMIN")]
        public async Task<IActionResult> UpdateUser(UserUpdateDTO model)
        {
            if (ModelState.IsValid)
            {

                var response = await _userService.UpdateAsync<APIResponse>(model ,HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexUser));
                }
            }
            return View(model);
        }

		public async Task<IActionResult> DeleteUser(int Id)
		{
			var response = await _userService.GetAsync<APIResponse>(Id ,HttpContext.Session.GetString(SD.SessionToken));
			if (response != null && response.IsSuccess)
			{
				UserDTO model = JsonConvert.DeserializeObject<UserDTO>(Convert.ToString(response.Results));
				return View(model);
			}
			return NotFound();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
        [Authorize(Roles = "IT_ADMIN")]
        public async Task<IActionResult> DeleteUser(UserDTO model)
		{

			var response = await _userService.DeleteAsync<APIResponse>(model.Id , HttpContext.Session.GetString(SD.SessionToken));
			if (response != null && response.IsSuccess)
			{
				return RedirectToAction(nameof(IndexUser));
			}

			return View(model);
		}

	}
}


	

