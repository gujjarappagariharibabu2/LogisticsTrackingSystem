
using LogisticsTrackingSystem.Data;
using LogisticsTrackingSystem.Models;
using LogisticsTrackingSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LogisticsTrackingSystem.Controllers
{
    public class ShipmentController : Controller
    {
        // Database context
        private readonly ApplicationDbContext _context;

        // Shipment service
        private readonly ShipmentService _service;

        // Constructor Dependency Injection
        public ShipmentController(
            ApplicationDbContext context)
        {
            _context = context;
            _service = new ShipmentService();
        }

        // Display active shipments
        public async Task<IActionResult> Active(
            string searchTerm,
            string status)
        {
            // Read shipments from database
            var shipments =
                await _context.Shipments.ToListAsync();

            // Apply business logic
            var result =
                _service.GetActiveShipments(shipments);

            // Search filter
            if (!string.IsNullOrEmpty(searchTerm))
            {
                result = result
                    .Where(x =>
                        x.TrackingNumber.Contains(searchTerm))
                    .ToList();
            }

            // Status filter
            if (!string.IsNullOrEmpty(status))
            {
                result = result
                    .Where(x => x.Status == status)
                    .ToList();
            }

            return View(result);
        }

        // Display archived shipments
        public async Task<IActionResult> Archived()
        {
            var shipments =
                 await _context.Shipments.ToListAsync();

            var result =
                _service.GetArchivedShipments(shipments);

            return View(result);
        }

        // GET: Create Shipment Page
        public IActionResult Create()
        {
            return View();
        }

        // POST: Save Shipment
        [HttpPost]
        public async Task<IActionResult> Create(
            Shipment shipment)
        {
            if (ModelState.IsValid)
            {
                // Save shipment into database
                _context.Shipments.Add(shipment);

                // Commit changes
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Active));
            }

            return View(shipment);
        }

        // GET: Edit Shipment
        public async Task<IActionResult> Edit(int id)
        {
            var shipment =
                await _context.Shipments.FindAsync(id);

            if (shipment == null)
            {
                return NotFound();
            }

            return View(shipment);
        }

        // POST: Update Shipment
        [HttpPost]
        public async Task<IActionResult> Edit(
            int id,
            Shipment shipment)
        {
            if (id != shipment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(shipment);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Active));
            }

            return View(shipment);
        }

        // GET: Delete Shipment
        public async Task<IActionResult> Delete(int id)
        {
            var shipment =
                await _context.Shipments.FindAsync(id);

            if (shipment == null)
            {
                return NotFound();
            }

            return View(shipment);
        }

        // POST: Confirm Delete
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shipment =
                await _context.Shipments.FindAsync(id);

            if (shipment != null)
            {
                _context.Shipments.Remove(shipment);

                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Active));
        }

        // Mark shipment as Delivered
        public async Task<IActionResult>
            MarkDelivered(int id)
        {
            var shipment =
                await _context.Shipments.FindAsync(id);

            if (shipment != null)
            {
                shipment.Status = "Delivered";

                shipment.DeliveredDate =
                    DateTime.Now;

                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Active));
        }

        // Mark shipment as In Transit
        public async Task<IActionResult>
            MarkTransit(int id)
        {
            var shipment =
                await _context.Shipments.FindAsync(id);

            if (shipment != null)
            {
                shipment.Status = "In Transit";

                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Active));
        }
    }
}
