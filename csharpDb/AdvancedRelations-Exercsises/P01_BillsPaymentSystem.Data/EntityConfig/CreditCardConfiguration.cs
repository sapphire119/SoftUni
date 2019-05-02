namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    using P01_BillsPaymentSystem.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            builder.HasKey(e => e.CreditCardId);

            builder.Ignore(e => e.LimitLeft);
            builder.Ignore(e => e.PaymentMethod);
            builder.Ignore(e => e.PaymentMethodId);

            builder.Property(e => e.ExpirationDate)
                .IsRequired();
        }
    }
}
