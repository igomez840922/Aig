﻿using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace Aig.FarmacoVigilancia.Services
{
    public interface IRamService
    {
        Task<Stream> ExportToExcel(GenericModel<FMV_RamTB> model);
        Task<List<FMV_RamTB>> FindAll(Expression<Func<FMV_RamTB, bool>> match);
        Task<GenericModel<FMV_RamTB>> FindAll(GenericModel<FMV_RamTB> model);
        Task<List<FMV_RamTB>> GetAll();
        Task<FMV_RamTB> Get(long id);
        Task<FMV_RamTB> Save(FMV_RamTB data);
        Task<FMV_RamTB> Delete(long id);
        Task<int> Count();
    }

   
}
