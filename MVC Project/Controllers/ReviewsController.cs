using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Data;
using MVC_Project.Models;
using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using UserRoles.Data;
using UserRoles.ViewModels;

namespace MVC_Project.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly BakeryDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<ReviewsController> _logger;

        public ReviewsController(BakeryDbContext context, UserManager<User> userManager,
    ILogger<ReviewsController> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;

        }

        [HttpGet]
        public async Task<IActionResult> Index(int productId)
        {
            Response.Headers["Cache-Control"] = "no-store, no-cache, must-revalidate, proxy-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "-1";

            var viewModel = new ReviewViewModel
            {
                ProductId = productId,
                ExistingReviews = await _context.Reviews
                    .Where(r => r.ProductId == productId)
                    .Include(r => r.User)
                    .Include(r => r.Product)
                    .OrderByDescending(r => r.CreatedAt)
                    .ToListAsync(),
                Products = new SelectList(await _context.Products.ToListAsync(), "ProductId", "Name")
            };

            // If no reviews, initialize an empty list
            if (viewModel.ExistingReviews.Count == 0)
            {
                viewModel.ExistingReviews = new List<Review>();
            }

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReviewViewModel model)
        {
            Console.WriteLine($"Received - ProductId: {model.ProductId}, Rating: {model.Rating}, Comment: {model.Comment}");

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                Console.WriteLine($"Validation errors: {string.Join(", ", errors)}");
                return View("Index", await GetPopulatedModel(model.ProductId));
            }

            try
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null) throw new Exception("User not found");

                var review = new Review
                {
                    ProductId = model.ProductId,
                    Rating = model.Rating,
                    Comment = model.Comment,
                    UserId = user.Id,
                    CreatedAt = DateTime.UtcNow
                };

                Console.WriteLine($"Attempting to save review: {JsonSerializer.Serialize(review)}");

                _context.Reviews.Add(review);
                var changes = await _context.SaveChangesAsync();
                Console.WriteLine($"Saved successfully. {changes} changes written.");

                return RedirectToAction(nameof(Index), new { productId = model.ProductId });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Save failed: {ex.ToString()}");
                TempData["ErrorMessage"] = "Failed to save review. Please try again.";
                return View("Index", await GetPopulatedModel(model.ProductId));
            }
        }

        private async Task<ReviewViewModel> GetPopulatedModel(int productId)
        {
            return new ReviewViewModel
            {
                ProductId = productId,
                ExistingReviews = await _context.Reviews
                    .Where(r => r.ProductId == productId)
                    .Include(r => r.User)
                    .Include(r => r.Product)
                    .OrderByDescending(r => r.CreatedAt)
                    .ToListAsync(),
                Products = new SelectList(await _context.Products.ToListAsync(), "ProductId", "Name")
            };
        }

        private async Task<List<Review>> GetReviewsForProduct(int productId)
        {
            return await _context.Reviews
                .Include(r => r.User)
                .Include(r => r.Product)
                .Where(r => r.ProductId == productId)
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync();
        }

        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var review = await _context.Reviews
                .Include(r => r.User)
                .Include(r => r.Product)
                .FirstOrDefaultAsync(r => r.ReviewId == id);

            if (review == null)
            {
                TempData["ErrorMessage"] = "Review not found.";
                return RedirectToAction(nameof(Index), new { productId = review.ProductId });
            }

            var viewModel = new ReviewViewModel
            {
                ReviewId = review.ReviewId,
                ProductId = review.ProductId,
                Rating = review.Rating,
                Comment = review.Comment
            };

            return View(viewModel);
        }

        // POST: Reviews/Edit/5
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ReviewViewModel model)
        {
            if (id != model.ReviewId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var review = await _context.Reviews.FindAsync(id);

                    if (review == null)
                    {
                        TempData["ErrorMessage"] = "Review not found.";
                        return RedirectToAction(nameof(Index), new { productId = model.ProductId });
                    }

                    review.Rating = model.Rating;
                    review.Comment = model.Comment;
                    review.UpdatedAt = DateTime.UtcNow;

                    _context.Update(review);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index), new { productId = model.ProductId });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Reviews.Any(r => r.ReviewId == id))
                    {
                        TempData["ErrorMessage"] = "Review not found.";
                        return RedirectToAction(nameof(Index), new { productId = model.ProductId });
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return View(model);
        }

        // POST: Reviews/Delete/5
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var review = await _context.Reviews.FindAsync(id);

            if (review == null)
            {
                TempData["ErrorMessage"] = "Review not found.";
                return RedirectToAction(nameof(Index), new { productId = review.ProductId });
            }

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Review deleted successfully.";
            return RedirectToAction(nameof(Index), new { productId = review.ProductId });
        }

    }
}