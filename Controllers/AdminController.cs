
using LogisticsTrackingSystem.Data;
using LogisticsTrackingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LogisticsTrackingSystem.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(
            ApplicationDbContext context)
        {
            _context = context;
        }

        // Display all users
        public async Task<IActionResult> Users()
        {
            var users =
                await _context.Users.ToListAsync();

            return View(users);
        }

        // GET: Edit User
        public async Task<IActionResult> EditUser(int id)
        {
            var user =
                await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Update User
        [HttpPost]
        public async Task<IActionResult> EditUser(
            int id,
            User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(user);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Users));
            }

            return View(user);
        }

        // GET: Delete User
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user =
                await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Confirm Delete
        [HttpPost, ActionName("DeleteUser")]
        public async Task<IActionResult>
            DeleteUserConfirmed(int id)
        {
            var user =
                await _context.Users.FindAsync(id);

            if (user != null)
            {
                _context.Users.Remove(user);

                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Users));
        }
    }
}
