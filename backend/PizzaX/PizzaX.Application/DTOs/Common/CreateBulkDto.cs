namespace PizzaX.Application.DTOs.Common
{
    public sealed class CreateBulkDto<T> where T : class
    {
        public List<T> Items { get; init; }
    }
}
