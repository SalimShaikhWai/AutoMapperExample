using Demo63Assignment.Models.DataModel;
using Demo63Assignment.Models.Interface;
using Demo63Assignment.Models.Service;
using Demo63Assignment.Models.UtilityClass;
using Demo63Assignment.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.OData.Query.SemanticAst;

namespace Demo63Assignment.Controllers
{
    public class UsersController : Controller
    {
        private readonly ICrudService<UserViewModel> _crudUserService;
        private readonly IUserService _userService;
        private readonly IDepartmentService _departmentService;
        public UsersController(ICrudService<UserViewModel> crudService, IDepartmentService departmentService, IUserService userService)
        {
            _crudUserService = crudService;
            _departmentService = departmentService;
            _userService = userService;
        }
        public async Task<IActionResult> IndexAsync(int pageNumber=1)
        {
            // var userData = await _crudUserService.GetAllAsync();
            var data = await _userService.PagingGetAllAsync(pageNumber);
           
            return View(data);
        }
        public async Task<ActionResult> Create()
        {

            ViewBag.Departments = await GetSelectListDepartmentAsync();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                await _crudUserService.CreateAsync(user);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public async Task<SelectList> GetSelectListDepartmentAsync(int? id = null)
        {
            var departmentViewModel = await _departmentService.GetDepartmentForDropDown();
            if (id == null)
                return new SelectList(departmentViewModel, "Id", "Name");
            else
                return new SelectList(departmentViewModel, "Id", "Name", id);
        }

        public async Task<ActionResult> Update(int id)
        {
            var userViewModel = await _crudUserService.GetByIdAsync(id);
            if (userViewModel == null)
                return RedirectToAction(nameof(Index));

            ViewBag.Departments = await GetSelectListDepartmentAsync(userViewModel.Id);

            return View(userViewModel);
        }
        public async Task<ActionResult> UpdateUser(UserViewModel userViewModel)
        {
            await _crudUserService.Update(userViewModel);
            return RedirectToAction(nameof(Index));
        }
        public async Task<ActionResult> Delete(int id)
        {
            var userViewModel = await _crudUserService.GetByIdAsync(id);
            return View(userViewModel);
        }
        public async Task<ActionResult> DeleteUser(int id)
        {
            await _crudUserService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
