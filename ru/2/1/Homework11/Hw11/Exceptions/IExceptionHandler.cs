namespace Hw11.Exceptions;

public interface IExceptionHandler
{
	public void HandleException<T>(T exception) where T : Exception;
}