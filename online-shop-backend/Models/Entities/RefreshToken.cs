using System;
using online_shop_backend.Models.Identity;

namespace online_shop_backend.Models.Entities;

public class RefreshToken
{
    public long Id { get; set; }

    public string ApplicationUserId { get; set; }

    public string Token { get; set; }

    public DateTime ExpiryDate { get; set; }

    public ApplicationUser ApplicationUser { get; set; }
}