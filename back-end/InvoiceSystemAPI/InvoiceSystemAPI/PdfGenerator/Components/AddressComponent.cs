using InvoiceSystemAPI.PdfGenerator.Models;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace InvoiceSystemAPI.PdfGenerator.Components
{
    public class PartyDataComponent : IComponent
    {
        private string Title { get; }
        private PartyData PartyData { get; }

        public PartyDataComponent(string title, PartyData partyData)
        {
            Title = title;
            PartyData = partyData;
        }

        public void Compose(IContainer container)
        {
            container.Column(column =>
            {
                column.Spacing(2);

                column.Item().BorderBottom(1).PaddingBottom(5).Text(Title).SemiBold();

                column.Item().Text(PartyData.CompanyName);
                column.Item().Text(PartyData.Street);
                column.Item().Text($"{PartyData.City}, {PartyData.Zip}");
                column.Item().Text(PartyData.VATCode);
            });
        }
    }
}
