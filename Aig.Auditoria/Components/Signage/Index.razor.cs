using Aig.Auditoria.Events.Language;
using DataModel.Models;
using Microsoft.AspNetCore.Components;
using System.Text;

namespace Aig.Auditoria.Components.Signage
{
    public partial class Index
    {
        public SignatureModel signatureModel { get; set; } = new SignatureModel();
                
        bool loading { get; set; } = false;

        [Parameter] 
        public EventCallback<string> OnSignature { get; set; }

        protected async override Task OnInitializedAsync()
        {
            
            //Subscribe Component to Language Change Event
            
            base.OnInitialized();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await FetchData();
            }
        }
        
        //Fill Data
        protected async Task FetchData()
        {
            loading = false;

            //SignatureData = attachment != null ? attachment : new DataModel.AttachmentTB();

            await this.InvokeAsync(StateHasChanged);
        }

        /// <summary>
        /// Saving Data
        /// </summary>

        //Save Data and Close
        protected async Task SaveData()
        {
            try
            {
                if (signatureModel.signatureArray?.Length > 0)
                {
                    signatureModel.signature = Encoding.UTF8.GetString(signatureModel.signatureArray);
                    await OnSignature.InvokeAsync(signatureModel.signature);
                }
            }
            catch { loading = false; }            
        }

       
        //Cancel and Close
        protected async Task Cancel()
        {
            await OnSignature.InvokeAsync(null);
        }
    }
}
