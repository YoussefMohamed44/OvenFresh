using System.ComponentModel.DataAnnotations;

public class PaymentInfoViewModel
{
    [Required]
    [Display(Name = "Name on Card")]
    public string CardholderName { get; set; }

    [Required]
    [CreditCard]
    [Display(Name = "Card Number")]
    public string CardNumber { get; set; }

    [Required]
    [Display(Name = "Expiration Date")]
    [RegularExpression(@"^(0[1-9]|1[0-2])\/?([0-9]{2})$", ErrorMessage = "Invalid expiration date")]
    public string ExpirationDate { get; set; }

    [Required]
    [RegularExpression(@"^[0-9]{3,4}$", ErrorMessage = "Invalid CVV")]
    public string CVV { get; set; }

    public bool SavePaymentInfo { get; set; }
}