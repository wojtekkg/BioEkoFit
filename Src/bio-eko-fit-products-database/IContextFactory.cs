namespace bio_eko_fit_products_database
{
    public interface IContextFactory
    {
         ProductsContext CreateDefaultContext();
    }
}