namespace InvoiceSystemAPI.Models;


    public class Template : BaseEntity
    {
        public int Id { get; set; }
        public string Invoice_DateTitle { get; set; } = "Invoice Date";
        public string Transaction_DateTitle { get; set; } = "Transaction Date";
        public string Payment_DateTitle { get; set; } = "Payment Date";
        public string NoteTitle { get; set; } = "Note";
        public string Issuer_IdTitle { get; set; } = "Issuer Id";
        public string Issuer_NameTitle { get; set; } = "Issuer Name";
        public string Issuer_AddressTitle { get; set; } = "Issuer Address";
        public string Issuer_CityTitle { get; set; } = "Issuer City";
        public string Issuer_ZipTitle { get; set; } = "Issuer Zip";
        public string BuyerVATCodeTitle { get; set; } = "Buyer VAT Code";
        public string Buyer_NameTitle { get; set; } = "Buyer Name";
        public string Buyer_AddressTitle { get; set; } = "Buyer Address";
        public string Buyer_CityTitle { get; set; } = "Buyer City";
        public string Buyer_ZipTitle { get; set; } = "Buyer Zip";
        public string Products { get; set; } = "Products";
        public string Is_PaidTitle { get; set; } = "Is Paid";
    }
