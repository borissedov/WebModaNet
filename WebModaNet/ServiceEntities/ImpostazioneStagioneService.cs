using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNet.ServiceEntities
{
	[Serializable]
	public class ImpostazioneStagioneService
	{
		public string CodiceStagione
		{
			get;
			set;
		}

		public string CodiceUtente
		{
			get;
			set;
		}

		public bool Disponibilita
		{
			get;
			set;
		}

		public int Id
		{
			get;
			set;
		}

		public ImpostazioneStagioneService()
		{
		}
	}
}