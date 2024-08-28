namespace ExamplesEF.Repository
{
    public interface INorthwindRepository
    {
        Task<Boolean> UpdateEmploeeTitle(int id, string title);
    }
}
