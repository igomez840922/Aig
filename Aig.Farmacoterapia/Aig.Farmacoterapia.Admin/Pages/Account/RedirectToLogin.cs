﻿using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Admin.Pages.Account
{
    public class RedirectToLogin : ComponentBase
    {
        [Inject]

        protected NavigationManager NavigationManager { get; set; }
        protected override void OnInitialized()
        {
            NavigationManager.NavigateTo("/login", true);
        }

}

}
