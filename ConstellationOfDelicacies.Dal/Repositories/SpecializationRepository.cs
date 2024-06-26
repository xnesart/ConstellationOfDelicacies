﻿using ConstellationOfDelicacies.Dal.Dtos;
using ConstellationOfDelicacies.Dal.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstellationOfDelicacies.Dal.Repositories
{
    public class SpecializationRepository : ISpecializationRepository
    {
        private Context _storage;

        public SpecializationRepository()
        {
            _storage = SingletoneStorage.GetStorage().Storage;
        }

        public SpecializationsDto GetSpTitleById(int spId)
        {
            var result = _storage.Specializations.Where(s => s.Id == spId).SingleOrDefault();
            return result;
        }

        public SpecializationsDto GetSpByProfile(int prId)
        {
            var result = _storage.Specializations.Where(s => s.Profiles.Any(p => p.Id == prId)).SingleOrDefault();
            if (result == null)
            {
                return new SpecializationsDto() { Title = "Специализация не найдена"};
            }
            return result;
        }

        public List<SpecializationsDto> GetAllSpecializations()
        {
            var result = _storage.Specializations.ToList();
            return result;
        }
    }
}
