using AutoMapper;
using Demo63Assignment.Models.DataModel;
using Demo63Assignment.Models.Interface;
using Demo63Assignment.Models.UtilityClass;
using Demo63Assignment.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Demo63Assignment.Models.Service
{

   
    public class UserService : ICrudService<UserViewModel>, IUserService
    {
        private readonly UserMgtContext _userMgtContext;
        private readonly IMapper _autoMapperProfile;
        public UserService(UserMgtContext userMgtContext, IMapper automapperprofile)
        {
            _userMgtContext = userMgtContext;
            _autoMapperProfile = automapperprofile;
        }


        public async Task CreateAsync(UserViewModel entity)
        {
            var user = _autoMapperProfile.Map<User>(entity);
            await _userMgtContext.Users.AddAsync(user);
            await _userMgtContext.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var user = await _userMgtContext.Users.SingleAsync(u => u.Id == id);
            _userMgtContext.Remove(user);
            await _userMgtContext.SaveChangesAsync();
        }
        public async Task<PaginatedList<User,UserViewModel>> PagingGetAllAsync(int pageNumber)
        {
            //var users=await  _userMgtContext.Users.Include(nameof(User.DepartmentRef)).ToListAsync();
            //var userViewModels = users.Select(u => _autoMapperProfile.Map<UserViewModel>(u));
            var pageData = await PaginatedList<User, UserViewModel>.CreateAsync(_userMgtContext.Users, pageNumber, 2,_autoMapperProfile);
          //  var userviewModels = _autoMapperProfile.ProjectTo<UserViewModel>(pageData);
            
            // var userViewModels = await _autoMapperProfile.ProjectTo<UserViewModel>(_userMgtContext.Users).ToListAsync();
            return pageData;
        }

        public async Task<List<UserViewModel>> GetAllAsync()
        {
            //var users=await  _userMgtContext.Users.Include(nameof(User.DepartmentRef)).ToListAsync();
            //var userViewModels = users.Select(u => _autoMapperProfile.Map<UserViewModel>(u));
            var userViewModels = await _autoMapperProfile.ProjectTo<UserViewModel>(_userMgtContext.Users).ToListAsync();
            return userViewModels;
        }

        public async Task<UserViewModel> GetByIdAsync(int id)
        {
            // var user = await _userMgtContext.Users.SingleAsync(u => u.Id == id);
            //var userVieModel = _autoMapperProfile.Map<UserViewModel>(user);
            var userVieModel =await  _autoMapperProfile.ProjectTo<UserViewModel>(_userMgtContext.Users).SingleAsync(u=>u.Id==id); 
            return userVieModel;
        }

        public async Task Update(UserViewModel entity)
        {
            var user = _autoMapperProfile.Map<User>(entity);
            _userMgtContext.Users.Update(user);
            await _userMgtContext.SaveChangesAsync();

        }
    }
}
