using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESchool.Logic.DB;
using ESchool.Models;

namespace ESchool.Extensions
{
    public static class MappingExtensions
    {
            public static CategoryModel ToModel(this Categories category)
            {
                return new CategoryModel()
                {
                    Id = category.Id,
                    Name = category.Name,
                    ParentId = category.ParentId,
                };
            }

        public static UserModel ToModel(this Users user)
        {
            if(user == null)
            {
                return null;
            }

            return new UserModel()
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                Password = user.Password,
            };
        }
    }
}
