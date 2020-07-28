using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TripTracker.Service.Models;
using TripTracker.UI.Data;
using TripTracker.UI.Services;

namespace TripTracker.UI.Pages.Trips
{
    public class CreateModel : PageModel
    {
        private readonly IApiClient _Client;

        public CreateModel(IApiClient client)
        {
            _Client = client;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Trip Trip { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _Client.AddTripAsync(Trip);

            return RedirectToPage("./Index");
        }
    }
}
