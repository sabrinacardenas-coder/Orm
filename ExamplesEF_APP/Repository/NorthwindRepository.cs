using ExamplesEF.Data;
using Microsoft.EntityFrameworkCore;

namespace ExamplesEF.Repository
{
    public class NorthwindRepository : INorthwindRepository
    {
        private readonly DataContext dbContext;
        public NorthwindRepository(DataContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public async Task<Boolean> UpdateEmploeeTitle(int id, string title)
        {
            Boolean updateOK = false;
            var emp = await dbContext.Employees.SingleOrDefaultAsync(n => n.EmployeeID.Equals(id));
            if (emp != null)
            {
                emp.Title = title;
                dbContext.SaveChanges(); // en este momento confirmo los cambios
                updateOK = true;
            }
            return updateOK;
        }
    }
}
