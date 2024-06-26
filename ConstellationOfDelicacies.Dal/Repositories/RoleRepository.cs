﻿using ConstellationOfDelicacies.Dal.Dtos;
using ConstellationOfDelicacies.Dal.IRepositories;

namespace ConstellationOfDelicacies.Dal.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly Context _storage;

        public RoleRepository()
        {
            _storage = SingletoneStorage.GetStorage().Storage;
        }

        public RolesDto GetRoleById(int roleId)
        {
            var role = _storage.Roles.Where(r => r.Id == roleId).Single();
            return role;
        }
    }
}
