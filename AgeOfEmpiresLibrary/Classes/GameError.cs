using System;
namespace AgeOfEmpiresLibrary
{
	/// <summary>
	/// Game error.
	/// self explanatory.
	/// </summary>
	public class GameError : System.Exception
	{
		public int status;

		public GameError()
		{
		}
	}
}
