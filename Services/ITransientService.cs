namespace Services
{
	public interface ITransientService
	{
		string GetScopedValue();
		string GetSingletonValue();
		string GetValue();
	}
}