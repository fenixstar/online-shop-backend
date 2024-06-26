using System.Collections.Generic;
using System.Linq;
using online_shop_backend.Models.Entities;
using online_shop_backend.Models.Identity;
using online_shop_backend.Repositories.Interfaces;

namespace online_shop_backend.Repositories.Implementations;

public class EfReviewRepository : IReviewRepository
{
    private readonly ApplicationDbContext context;

    public EfReviewRepository(ApplicationDbContext context)
    {
        this.context = context;
    }

    public void AddReview(Review review)
    {
        context.Reviews.Add(review);
        context.SaveChanges();
    }

    public void RemoveReview(Review review)
    {
        context.Reviews.Remove(review);
        context.SaveChanges();
    }

    public void UpdateReview(Review review)
    {
        context.Reviews.Update(review);
        context.SaveChanges();
    }

    public Review GetReview(long id)
    {
        return context.Reviews.Find(id);
    }

    public ICollection<Review> GetAllReviews()
    {
        return context.Reviews.ToList();
    }

    public ApplicationUser GetUserForReview(long id)
    {
        return (ApplicationUser)context.Users.Find(
            context.Reviews.Find(id)?.ApplicationUserId
        );
    }

    public Product GetProductForReview(long id)
    {
        return context.Products.Find(
            context.Reviews.Find(id)?.Product
        );
    }
}