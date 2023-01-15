using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Infrastructure.Application
{
    //public class AppState
    //{
    //    public string SerachText { get; set; } = string.Empty;

    //    public event Action OnChange;

    //    public void SetSearchText(string serachText)
    //    {
    //        SerachText = serachText;
    //        NotifyStateChanged();
    //    }

    //    public void SetSearchWithoutEvent (string serachText)
    //    {
    //        SerachText = serachText;
    //    }

    //    private void NotifyStateChanged() => OnChange?.Invoke();
    //}

    public class AppState
    {
        public AppFilter Filter { get; set; } = new AppFilter();

        public event Action OnChange;

        public void SetSearchText(AppFilter filter,bool notify =true)
        {
            Filter = filter;
            if(notify)
               NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
    public class AppFilter
    {
        public AppFilter() { Term = string.Empty; Valid = true; }
        public string Term { get; set; }
        public string Classification { get; set; }
        public string SaleCondition { get; set; }
        public bool Valid { get; set; }

    }

}
