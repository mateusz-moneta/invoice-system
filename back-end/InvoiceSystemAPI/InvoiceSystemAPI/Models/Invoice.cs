namespace InvoiceSystemAPI.Models
{
    public class Invoice : BaseEntity
    {
        public string Invoice_Id { get; set; }
        public DateTime Invoice_Date { get; set; }
        public DateTime Transaction_Date { get; set; }
        public DateTime Payment_Date { get; set; }
        public string Note { get; set; }
        public int Issuer_Id { get; set; }
        public string Issuer_Name { get; set; }
        public string Issuer_Address { get; set; }
        public string Issuer_City { get; set; }
        public string Issuer_Zip { get; set; }
        public int Buyer_Id { get; set; }
        public string Buyer_Name { get; set; }
        public string Buyer_Address { get; set; }
        public string Buyer_City { get; set; }   
        public string Buyer_Zip { get; set; }
        public bool Is_Paid { get; set; }
        public int Status_Id { get; set; }
    }
}
