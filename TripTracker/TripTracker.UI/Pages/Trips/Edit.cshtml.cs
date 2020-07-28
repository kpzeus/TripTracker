using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TripTracker.Service.Models;
using TripTracker.UI.Data;
using TripTracker.UI.Services;

namespace TripTracker.UI.Pages.Trips
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly IApiClient _Client;

        public EditModel(IApiClient client)
        {
            _Client = client;
        }

        [BindProperty]
        public Trip Trip { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Trip = await _Client.GetTripAsync(id.Value);

            if (Trip == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _Client.PutTripAsync(Trip);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _Client.GetTripAsync(Trip.Id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
