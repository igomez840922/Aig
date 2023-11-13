using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    
    public class APP_Dashboard:SystemId
    {

        private int total;
        public int Total { get => total; set => SetProperty(ref total, value); }

        private int totalPending;
        public int TotalPending { get => totalPending; set => SetProperty(ref totalPending, value); }

        private int totalRest;
        public int TotalRest { get => totalRest; set => SetProperty(ref totalRest, value); }

        private List<string> chartLabels;
        public List<string> ChartLabels { get => chartLabels; set => SetProperty(ref chartLabels, value); }

        private List<double> chartData;
        public List<double> ChartData { get => chartData; set => SetProperty(ref chartData, value); }

    }
}
