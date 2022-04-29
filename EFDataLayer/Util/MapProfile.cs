using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataLayer.Util
{
    public class MapProfile: Profile
    {
        public MapProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap <CommonLayer.Models.Customer,EFDataLayer.Model.Customer>();
            CreateMap<EFDataLayer.Model.Customer,CommonLayer.Models.Customer>();
            CreateMap<CommonLayer.Models.Account, EFDataLayer.Model.Account>();
            CreateMap<EFDataLayer.Model.Account, CommonLayer.Models.Account>();
            CreateMap<EFDataLayer.Model.Transaction, CommonLayer.Models.Transaction>();
            CreateMap<CommonLayer.Models.Transaction, EFDataLayer.Model.Transaction>();
           






        }

    }
}
