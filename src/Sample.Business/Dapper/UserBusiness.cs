using Sample.Data.Access.Dapper;
using Sample.Data.Entities;
using Sample.DTO.API;
using Sample.Utilities;
using System;
using System.Collections.Generic;

namespace Sample.Business.Dapper
{
    public class UserBusiness
    {
        public bool Insert(UserDTO userDTO)
        {
            try
            {
                var user = AutoMapperHelper.MapTo<User>(userDTO);
                UserOperator userOperator = new UserOperator();
                return userOperator.Insert(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<User> GetAll()
        {
            try
            {

                UserOperator userOperator = new UserOperator();
                var users = userOperator.GetAll();
                return users;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
