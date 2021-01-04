using SF.Core;
using SF.DAL.UnitOfWork;
using SF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SF.Service
{
    public class UserRightsService
    {
        private IRepository<UserRights> userRightsRepository = null;
        private IRepository<SysMenu> menuRepository = null;
        public UserRightsService()
        {
            userRightsRepository = new RepositoryBase<UserRights>();
            menuRepository = new RepositoryBase<SysMenu>();
        }
        public List<UserRights> GetUserRights(int userId)
        {
            return userRightsRepository.Entities.Where(zw => zw.UserId == userId).ToList();
        }
        /// <summary>
        /// 获取用户请求Url
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<UserRights> GetListByUrl(string url)
        {
            Expression<Func<UserRights, bool>> ex = t => true;
            ex = ex.And(t => t.SysMenu.Url == url);
            return userRightsRepository.GetEntities(ex, true).ToList();
        }
    }
}
