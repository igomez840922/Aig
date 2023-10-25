using DataModel;
using System.Linq.Expressions;
using AuditoriaApp.Helper;

namespace AuditoriaApp.Services
{
    public class DalService : IDalService
    {

        public ApplicationDbContext DBContext { get; set; }

        public DalService(ApplicationDbContext DBContext)
        {
            //DBContext = new ApplicationDbContext();
            this.DBContext = DBContext;
            DBContext.Database.EnsureCreated();
        }

        public List<T> GetAll<T>() where T : class
        {
            //Reload();
            try
            {
                List<T> _Data = null;
                _Data = DBContext.Set<T>().ToList();
                return _Data;
            }
            catch (Exception ex) { }
            return null;
        }

        public List<T> GetAll<T>(int PageIdx, int PageAmt) where T : class, Identity
        {
            //Reload();
            try
            {
                List<T> _Data = null;

                _Data = DBContext.Set<T>().OrderBy(pp => pp.Id).Skip(PageIdx * PageAmt).Take(PageAmt).ToList();

                return _Data;
            }
            catch (Exception ex) { }
            return null;
        }

        public T Get<T>(long Id) where T : class
        {
            //Reload();
            try
            {
                T _Data = null;
                _Data = DBContext.Set<T>().Find(Id);
                return _Data;
            }
            catch { }
            return null;
        }

        public T GetReloaded<T>(long Id) where T : class
        {
            Reload();
            try
            {
                T _Data = null;
                _Data = DBContext.Set<T>().Find(Id);
                return _Data;
            }
            catch { }
            return null;
        }

        public T Find<T>(Expression<Func<T, bool>> match) where T : class
        {
            //Reload();
            try
            {
                T _Data = null;

                _Data = DBContext.Set<T>().FirstOrDefault(match);

                return _Data;
            }
            catch (Exception ex) { }
            return null;
        }

        public List<T> FindAll<T>(Expression<Func<T, bool>> match) where T : class
        {
            //Reload();
            try
            {
                List<T> _Data = null;

                _Data = DBContext.Set<T>().Where(match).ToList();

                return _Data;
            }
            catch (Exception ex) { }
            return null;
        }

        public List<T> FindAll<T>(Expression<Func<T, bool>> match, int PageIdx, int PageAmt) where T : class, Identity
        {
            //Reload();
            try
            {
                List<T> _Data = null;

                _Data = DBContext.Set<T>().Where(match).OrderBy(pp => pp.Id).Skip(PageIdx * PageAmt).Take(PageAmt).ToList();

                return _Data;
            }
            catch { }
            return null;
        }

        public T Save<T>(T _Data) where T : class, Identity
        {
            //lock (objLock)
            try
            {
                _Data.UpdatedDate = DateTime.Now;

                //var _OldData = DBContext.Set<T>().Find(_Data.Id);
                //if (_OldData != null)
                //{                    
                //    DBContext.Entry(_OldData).CurrentValues.SetValues(_Data);                    
                //}
                //else
                //{
                //    DBContext.Set<T>().Add(_Data);
                //}
                //var _OldData = DBContext.Set<T>().Find(_Data.Id);


                if (_Data?.Id > 0)
                {
                    DBContext.Set<T>().Update(_Data);
                }
                else
                {
                    _Data.CreatedDate = DateTime.Now;
                    DBContext.Set<T>().Attach(_Data);
                    DBContext.Set<T>().Add(_Data);
                }

                DBContext.SaveChanges();

                return Get<T>(_Data.Id); ;
            }
            catch (Exception ex)
            { }
            return null;
        }

        public T UpdateValues<T>(T _Data) where T : class, Identity
        {
            //lock (objLock)
            try
            {
                _Data.UpdatedDate = DateTime.Now;
                var _OldData = DBContext.Set<T>().Find(_Data.Id);
                if (_OldData != null)
                {
                    DBContext.Entry(_OldData).CurrentValues.SetValues(_Data);
                }
                else
                {
                    DBContext.Set<T>().Add(_Data);
                }
                DBContext.SaveChanges();

                return Get<T>(_Data.Id); ;
            }
            catch (Exception ex)
            { }
            return null;
        }


        public T Delete<T>(long Id) where T : class
        {
            //lock (objLock)
            try
            {
                T _Data = null;

                _Data = DBContext.Set<T>().Find(Id);

                DBContext.Set<T>().Remove(_Data);

                DBContext.SaveChanges();

                return _Data;
            }
            catch (Exception ex) { }
            return null;
        }

        public int Count<T>() where T : class
        {
            //lock (objLock)
            try
            {
                int _count = 0;

                _count = DBContext.Set<T>().Count();
                return _count;
            }
            catch { }
            return 0;
        }

        public int Count<T>(Expression<Func<T, bool>> match) where T : class
        {
            try
            {
                int _count = 0;

                _count = DBContext.Set<T>().Where(match).Count();
                return _count;
            }
            catch { }
            return 0;
        }

        public T First<T>() where T : class
        {
            //Reload();
            try
            {
                T _Data = null;
                _Data = DBContext.Set<T>().FirstOrDefault();
                return _Data;
            }
            catch { }
            return null;
        }

        public void Reload()
        {
            try { DBContext.ChangeTracker.Clear(); }
            catch { }
        }

    }

}
