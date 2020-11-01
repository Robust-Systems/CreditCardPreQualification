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

    public string ImageFileName { get; set; }

    public bool IsDefault { get; set; }

    public override string ToString()
    {
      return CardName;
    }
  }
}