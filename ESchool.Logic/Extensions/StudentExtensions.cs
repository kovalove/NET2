using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESchool.Logic.DB;
using ESchool.Models;

namespace ESchool.Extensions
{
    public static class StudentExtensions
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


    }
}
