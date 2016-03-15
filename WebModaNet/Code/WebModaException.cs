using System;

namespace EW.WebModaNet.Code
{
	public class WebModaException : Exception
	{
		public WebModaException()
		{
		}

		public WebModaException(string message) : base(message)
		{
		}
	}
}