using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNet
{
	[Serializable]
	public class ArticoloJson
	{
		public string label
		{
			get;
			set;
		}

		public string @value
		{
			get;
			set;
		}

		public ArticoloJson()
		{
		}
	}
}