namespace Hw11.Exceptions;

public class InvalidSymbolException: Exception
{
	public InvalidSymbolException(string message)
		: base(message)
	{
	}
}