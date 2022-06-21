using Demo63Assignment.Models.DataModel;
using Demo63Assignment.Models.UtilityClass;
using Demo63Assignment.Models.ViewModel;

namespace Demo63Assignment.Models.Interface
{
    public interface IUserService
    {
        public Task<PaginatedList<User, UserViewModel>> PagingGetAllAsync(int pageNumber);
    }
}
