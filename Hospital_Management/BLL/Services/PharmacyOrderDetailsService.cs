using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PharmacyOrderDetailsService
    {
        public static List<PharmacyOrderDetailsDTO> Get()
        {
            var data = DataAccessFactory.PharmacyOrderDetailsDataAccess().Get();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<PharmacyOrderDetails, PharmacyOrderDetailsDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<PharmacyOrderDetailsDTO>>(data);
        }
        public static PharmacyOrderDetailsDTO Get(int id)
        {
            var data = DataAccessFactory.PharmacyOrderDetailsDataAccess().Get();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<PharmacyOrderDetails, PharmacyOrderDetailsDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<PharmacyOrderDetailsDTO>(data);
        }
        public static PharmacyOrderDetailsDTO Add(PharmacyOrderDetailsDTO PharmacyOrderDetails)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<PharmacyOrderDetailsDTO, PharmacyOrderDetails>();
                c.CreateMap<PharmacyOrderDetails, PharmacyOrderDetailsDTO>();

            });
            var mapper = new Mapper(cfg);
            var cab = mapper.Map<PharmacyOrderDetails>(PharmacyOrderDetails);
            var data = DataAccessFactory.PharmacyOrderDetailsDataAccess().Add(cab);

            if (data != null) return mapper.Map<PharmacyOrderDetailsDTO>(data);
            return null;
        }
        public static PharmacyOrderDetailsDTO Delete(int id)
        {
            var data = DataAccessFactory.PharmacyOrderDetailsDataAccess().Get(id);
            DataAccessFactory.PharmacyOrderDetailsDataAccess().Delete(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PharmacyOrderDetails, PharmacyOrderDetailsDTO>());
            var mapper = new Mapper(config);
            var op = mapper.Map<PharmacyOrderDetailsDTO>(data);

            return op;

        }
        public static PharmacyOrderDetailsDTO Update(PharmacyOrderDetailsDTO dto)
        {
            var data = DataAccessFactory.PharmacyOrderDetailsDataAccess().Get(dto.Id);
            data.Id = dto.Id;
            DataAccessFactory.PharmacyOrderDetailsDataAccess().Update(data);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PharmacyOrderDetails, PharmacyOrderDetailsDTO>());
            var mapper = new Mapper(config);
            var PharmacyOrderDetails = mapper.Map<PharmacyOrderDetailsDTO>(data);

            return PharmacyOrderDetails;

        }
    }
}
