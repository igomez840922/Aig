using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Infrastructure.Application
{
    public class AppState
    {
        public string SerachText { get; set; } = string.Empty;

        public event Action OnChange;

        public void SetSerachText(string serachText)
        {
            SerachText = serachText;
            NotifyStateChanged();
        }

        public void SetSerachWithoutEvent (string serachText)
        {
            SerachText = serachText;
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
