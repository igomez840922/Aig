using DataAccess.FarmacoVigilancia;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.FarmacoVigilancia.Services
{    
    public class LabsService : ILabsService
    {
        private readonly IDalService DalService;
        public LabsService(IDalService dalService)
        {
            DalService = dalService;
        }

        public async Task<GenericModel<LaboratorioTB>> FindAll(GenericModel<LaboratorioTB> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata  = (from data in DalService.DBContext.Set<LaboratorioTB>()
                              where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.Nombre.Contains(model.Filter) || data.Pais.Contains(model.Filter) || data.Telefono.Contains(model.Filter) || data.Correo.Contains(model.Filter))) &&
                              (model.LaboratoryType == null ? true : (data.TipoLaboratorio == model.LaboratoryType)) &&
                              (model.UbicationType == null ? true : (data.TipoUbicacion == model.UbicationType))
                                orderby data.Nombre
                              select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<LaboratorioTB>()
                               where data.Deleted == false &&
                               (string.IsNullOrEmpty(model.Filter) ? true : (data.Nombre.Contains(model.Filter) || data.Pais.Contains(model.Filter) || data.Telefono.Contains(model.Filter) || data.Correo.Contains(model.Filter))) &&
                               (model.LaboratoryType == null ? true : (data.TipoLaboratorio == model.LaboratoryType)) &&
                               (model.UbicationType == null ? true : (data.TipoUbicacion == model.UbicationType))
                               select data).Count();  
            }
            catch (Exception ex)
            { }

            return model;
        }

        public async Task<List<LaboratorioTB>> GetAll()
        {
            return (from data in DalService.DBContext.Set<LaboratorioTB>()
                    where data.Deleted == false
                    select data).ToList();
        }

        public async Task<LaboratorioTB> Get(long Id)
        {
            var result = DalService.Get<LaboratorioTB>(Id);
            return result;
        }

        public async Task<LaboratorioTB> Save(LaboratorioTB data)
        {
            var result = DalService.Save(data);
            return result;           
        }

        public async Task<LaboratorioTB> Delete(long Id)
        {
            var data = DalService.Delete<LaboratorioTB>(Id);
            return data;
        }

        public async Task<int> Count()
        {
            try { return DalService.Count<LaboratorioTB>(); }
            catch { }return 0;
        }
    }

}
