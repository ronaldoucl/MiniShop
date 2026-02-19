using Microsoft.EntityFrameworkCore;
using MiniShop.Data;
using MiniShop.Models;

namespace MiniShop.Services;

public class CartService
{
    private readonly AppDbContext _context;
    private readonly AuthService _authService;
    public event Action? OnChange;
    private void Notify() => OnChange?.Invoke();



    public CartService(AppDbContext context, AuthService authService)
    {
        _context = context;
        _authService = authService;
    }

    /*
 * Gets the authenticated user's active cart (Pending order) or creates one if it doesn't exist.
 * Returns null when no user is logged in.
 */
    private async Task<Order?> GetOrCreateCartAsync()
    {
        try
        {
            var user = _authService.CurrentUser;
            if (user == null) return null;

            var order = await _context.Orders
                .Include(o => o.Items)
                .FirstOrDefaultAsync(o =>
                    o.UserId == user.Id &&
                    o.Status == "Pending");

            if (order == null)
            {
                order = new Order
                {
                    UserId = user.Id,
                    OrderDate = DateTime.UtcNow,
                    Status = "Pending",
                    Total = 0
                };

                _context.Orders.Add(order);
                await _context.SaveChangesAsync();
            }

            return order;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[GetOrCreateCartAsync] Error: {ex.Message}");
            return null;
        }
    }


    /*
     * Adds a product to the user's active cart, increasing quantity if it already exists.
     * Recalculates the total and persists changes.
     */
    public async Task AddToCartAsync(Product product)
    {
        try
        {
            var order = await GetOrCreateCartAsync();
            if (order == null) return;

            var existingItem = order.Items
                .FirstOrDefault(i => i.ProductId == product.Id);

            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                order.Items.Add(new OrderItem
                {
                    ProductId = product.Id,
                    Quantity = 1,
                    Price = product.Price
                });
            }

            order.Total = order.Items.Sum(i => i.Price * i.Quantity);

            await _context.SaveChangesAsync();
            Notify();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[AddToCartAsync] Error: {ex.Message}");
        }
    }


    /*
     * Retrieves the authenticated user's active cart with its items and related products.
     * Returns null if no user is logged in.
     */
    public async Task<Order?> GetCartAsync()
    {
        try
        {
            var user = _authService.CurrentUser;
            if (user == null) return null;

            return await _context.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(o =>
                    o.UserId == user.Id &&
                    o.Status == "Pending");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[GetCartAsync] Error: {ex.Message}");
            return null;
        }
    }


    /*
     * Returns the total quantity of items in the authenticated user's active cart.
     * Returns 0 if no user or active cart exists.
     */
    public async Task<int> GetCartItemCountAsync()
    {
        try
        {
            var user = _authService.CurrentUser;
            if (user == null) return 0;

            var order = await _context.Orders
                .Include(o => o.Items)
                .FirstOrDefaultAsync(o =>
                    o.UserId == user.Id &&
                    o.Status == "Pending");

            if (order == null) return 0;

            return order.Items.Sum(i => i.Quantity);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[GetCartItemCountAsync] Error: {ex.Message}");
            return 0;
        }
    }

    /*
     * Completes the active cart by marking it as "Completed",
     * persists changes, and notifies subscribers.
     */
    public async Task<bool> CheckoutAsync()
    {
        try
        {
            var order = await GetCartAsync();
            if (order == null || !order.Items.Any())
                return false;

            order.Status = "Completed";
            order.OrderDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            Notify();

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[CheckoutAsync] Error: {ex.Message}");
            return false;
        }
    }
}
