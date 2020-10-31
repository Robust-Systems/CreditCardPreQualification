namespace DataLogic.Models
{
  public class CreditCard
  {
    public int CreditCardID { get; set; }

    public string CardName { get; set; }

    public int? AgeRestriction { get; set; }

    public int? AnnualIncomeRestriction { get; set; }

    public string PromotionalMessage { get; set; }

    public decimal? APR { get; set; }

    public bool IsDefault { get; set; }
  }
}