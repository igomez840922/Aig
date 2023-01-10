﻿using DataAccess;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace Aig.FarmacoVigilancia.Services
{    
    public class TerMedraService : ITerMedraService
    {
        private readonly IDalService DalService;
        public TerMedraService(IDalService dalService)
        {
            DalService = dalService;
        }
        public async Task<List<FMV_TerMedraTB>> FindAll(Expression<Func<FMV_TerMedraTB, bool>> match)
        {
            try
            {
                return DalService.FindAll(match);
            }
            catch (Exception ex)
            { }

            return null;
        }

        public async Task<GenericModel<FMV_TerMedraTB>> FindAll(GenericModel<FMV_TerMedraTB> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata  = (from data in DalService.DBContext.Set<FMV_TerMedraTB>()
                              where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.Nombre.Contains(model.Filter) || data.Soc.Nombre.Contains(model.Filter))) &&
                              (model.NParentId > 0 ? data.SocId == model.NParentId : true)
                                orderby data.Nombre
                              select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_TerMedraTB>()
                             where data.Deleted == false &&
                            (string.IsNullOrEmpty(model.Filter) ? true : (data.Nombre.Contains(model.Filter) || data.Soc.Nombre.Contains(model.Filter))) &&
                              (model.NParentId > 0 ? data.SocId == model.NParentId : true)
                               select data).Count();  
            }
            catch (Exception ex)
            { }

            return model;
        }

        public async Task<List<FMV_TerMedraTB>> GetAll()
        {
            return (from data in DalService.DBContext.Set<FMV_TerMedraTB>()
                    where data.Deleted == false
                    select data).ToList();
        }

        public async Task<FMV_TerMedraTB> Get(long Id)
        {
            var result = DalService.Get<FMV_TerMedraTB>(Id);
            return result;
        }

        public async Task<FMV_TerMedraTB> Save(FMV_TerMedraTB data)
        {
            var result = DalService.Save(data);
            return result;           
        }

        public async Task<FMV_TerMedraTB> Delete(long Id)
        {
            var data = DalService.Delete<FMV_TerMedraTB>(Id);
            return data;
        }

        public async Task<int> Count()
        {
            try { return DalService.Count<FMV_TerMedraTB>(); }
            catch { }return 0;
        }
    }

}
