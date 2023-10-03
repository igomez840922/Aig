using BlazorComponentBus;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using AuditoriaApp.Services;
using AuditoriaApp.Data;

namespace AuditoriaApp.Pages.Subscription
{
    public partial class Index
    {
        [Inject]
        ILicenseOptionService licenseOptionService { get; set; }
        [Inject]
        IAccountDataService accountDataService { get; set; }
        [Inject]
        IPaymentService paymentService { get; set; }


        [Inject]
        IDialogService DialogService { get; set; }

        List<LicenseOptionTB> lLicenseOptions { get; set; }

        ChargeCreditCardModel model { get; set; }
        AccountData accountData { get; set; }

        protected async override Task OnInitializedAsync()
        {
            //Subscribe Component to Language Change Event
            //bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);
            base.OnInitialized();
        }

        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                
                await FetchData();
            }
            await base.OnAfterRenderAsync(firstRender);
        }

        protected async Task FetchData()
        {
            try {
                accountData = accountData!=null ? accountData : await accountDataService.First();

                lLicenseOptions = lLicenseOptions?.Count >0? lLicenseOptions: await licenseOptionService.GetAll();

                //model = await authorizeNetSettingsService.GetFirst();
                model = new ChargeCreditCardModel() { UserId = accountData ?.UserId??null};

            }
            catch { }
            finally { await this.InvokeAsync(StateHasChanged); }           
            
        }

        protected async Task SaveData()
        {
            try {
                var result = await paymentService.ChargeCreditCard(model);
                if (result != null && !result.Invalid)
                {
                    accountData.licenseId = result.Id;
                    await accountDataService.Save(accountData);

                    snackbar.Add("Subscription has been submited successfully", Severity.Success);
                    //FetchData();
                    return;
                }
                else if (result != null && result.Invalid)
                {
                    snackbar.Add(result.ErrorMsg, Severity.Error);
                    //FetchData();
                    return;
                }
            }
            catch(Exception ex) {
                snackbar.Add(ex.Message, Severity.Error);
            }
            snackbar.Add(languageContainerService.Keys["DataSaveError"], Severity.Error);            
        }

        protected async Task Cancel()
        {
            FetchData();
        }


    }

}
