﻿using Aig.FarmacoVigilancia.Events.Language;
using Aig.FarmacoVigilancia.Events.PMR;
using Aig.FarmacoVigilancia.Services;
using AKSoftware.Localization.MultiLanguages;
using BlazorComponentBus;
using DataModel;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Mobsites.Blazor;

namespace Aig.FarmacoVigilancia.Components.Pmr
{    
    public partial class AddEditPmr
    {
        [Inject]
        IPmrService pmrService { get; set; }
        [Inject]
        IProfileService profileService { get; set; }
        [Inject]
        IWorkerPersonService evaluatorService { get; set; }
        [Inject]
        IPdfGenerationService pdfGenerationService { get; set; }
        [Parameter]
        public DataModel.FMV_PmrTB Pmr { get; set; }
        List<PersonalTrabajadorTB> lEvaluators { get; set; }

        bool OpenAddEditProduct { get; set; }=false;
        FMV_PmrProductoTB AddProduct { get; set; } = null;

        protected async override Task OnInitializedAsync()
        {
            //Subscribe Component to Language Change Event
            bus.Subscribe<LanguageChangeEvent>(LanguageChangeEventHandler);

            base.OnInitialized();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await getUserLanguaje();
                await FetchData();
            }
        }

        //CHANGE LANGUAJE
        protected async Task getUserLanguaje(string? language = null)
        {
            language = string.IsNullOrEmpty(language) ? await profileService.GetLanguage() : language;
            languageContainerService.SetLanguage(System.Globalization.CultureInfo.GetCultureInfo(language));
            await this.InvokeAsync(StateHasChanged);
        }
        private void LanguageChangeEventHandler(MessageArgs args)
        {
            var message = args.GetMessage<LanguageChangeEvent>();

            getUserLanguaje(message.Language);
        }

        //Fill Data
        protected async Task FetchData()
        {
            if (lEvaluators == null || lEvaluators.Count < 1)
            {
                lEvaluators = await evaluatorService.GetAll();
            }

            if (Pmr != null)
            {               
                if (Pmr.EvaluadorId == null)
                {
                    Pmr.EvaluadorId = lEvaluators?.FirstOrDefault()?.Id ?? null;
                    if (Pmr.EvaluadorId != null)
                    {
                        Pmr.Evaluador = lEvaluators.Where(x => x.Id == Pmr.EvaluadorId.Value).FirstOrDefault();
                    }
                }
            }

            await this.InvokeAsync(StateHasChanged);
        }

        //Save Data and Close
        protected async Task SaveData()
        {
            if (Pmr.EvaluadorId != null && Pmr.EvaluadorId > 0)
            {
                Pmr.Evaluador = await evaluatorService.Get(Pmr.EvaluadorId.Value);
            }

            var result = await pmrService.Save(Pmr);
            if (result != null)
            {
                await jsRuntime.InvokeVoidAsync("ShowMessage", languageContainerService.Keys["DataSaveSuccessfully"]);
                Pmr = result;

                await bus.Publish(new PmrAddEdit_CloseEvent { Data = null });
            }
            else
                await jsRuntime.InvokeVoidAsync("ShowError", languageContainerService.Keys["DataSaveError"]);
        }

        //Cancel and Close
        protected async Task Cancel()
        {
            await bus.Publish(new PmrAddEdit_CloseEvent { Data = null });
            await this.InvokeAsync(StateHasChanged);
        }

        //Add New Product
        protected async Task OpenProduct(FMV_PmrProductoTB product = null)
        {
            
            bus.Subscribe<Aig.FarmacoVigilancia.Events.PmrProduct.AddEdit_CloseEvent>(Product_AddEditCloseEventHandlerHandler);

            AddProduct = product != null ? product : new FMV_PmrProductoTB();
            OpenAddEditProduct = true;

            await bus.Publish(new Aig.FarmacoVigilancia.Events.PmrProduct.AddEdit_OpenEvent { Data = AddProduct });
            await this.InvokeAsync(StateHasChanged);
        }
        //Remove Product
        protected async Task RemoveProduct(FMV_PmrProductoTB product)
        {
            if (product != null)
            {
                Pmr.LProductos.Remove(product);
                this.InvokeAsync(StateHasChanged);
            }
        }
        //ON CLOSE PRODUCT MODAL 
        private void Product_AddEditCloseEventHandlerHandler(MessageArgs args)
        {
            bus.UnSubscribe<Aig.FarmacoVigilancia.Events.PmrProduct.AddEdit_CloseEvent>(Product_AddEditCloseEventHandlerHandler);

            var message = args.GetMessage<Aig.FarmacoVigilancia.Events.PmrProduct.AddEdit_CloseEvent>();

            AddProduct = null;
            OpenAddEditProduct = false;
            if (message.Data != null)
            {
                Pmr.LProductos = Pmr.LProductos != null ? Pmr.LProductos : new List<FMV_PmrProductoTB>();

                Pmr.LProductos.Add(message.Data);
            }

            this.InvokeAsync(StateHasChanged);
        }
                
        protected async Task OnEvaluatorChange(long? Id)
        {
            Pmr.EvaluadorId = Id;
            Pmr.Evaluador = lEvaluators.Where(x => x.Id == Id).FirstOrDefault();
        }


    }

}