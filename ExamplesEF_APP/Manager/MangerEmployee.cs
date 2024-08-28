using ExamplesEF.Data;
using ExamplesEF.Repository;
using Microsoft.EntityFrameworkCore;

namespace ExamplesEF.Manager
{
    public class MangerEmployee
    {
        private INorthwindRepository northwindRepository;

        public MangerEmployee(INorthwindRepository northwindRepository)
        {
            this.northwindRepository = northwindRepository ?? throw new ArgumentNullException(nameof(northwindRepository));
        }
        public async Task<Boolean> UpdateEmploeeTitle(int id, string title)
        {
            var result = await northwindRepository.UpdateEmploeeTitle(id, title);
            return result;
        }
    }
}
