using Microsoft.EntityFrameworkCore;

namespace Hw10.DbModels;

public class ApplicationContext: DbContext
{
	public DbSet<SolvingExpression> SolvingExpressions => Set<SolvingExpression>();

	public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
	{
	}
}