public class Transaction {
    // Simplified model for a transaction
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string Status { get; set; }
    public string Merchant { get; set; }
    public string Customer { get; set; }
    public string PaymentGateway { get; set; }
    public string Bank { get; set; }

    public Transaction(decimal amount, DateTime date, string status, string merchant, string customer, string paymentGateway, string bank)
    {
        Amount = amount;
        Date = date;
        Status = status;
        Merchant = merchant;
        Customer = customer;
        PaymentGateway = paymentGateway;
        Bank = bank;
    }

    public Transaction()
    {
        Amount = 0;
        Date = DateTime.Now;
        Status = "Pending";
        Merchant = "Merchant";
        Customer = "Customer";
        PaymentGateway = "PaymentGateway";
        Bank = "Bank";
    }
}
