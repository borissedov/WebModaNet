using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNetClassLibrary.Entities
{
	public class ImpostazioneStagione
	{
		public virtual EW.WebModaNetClassLibrary.Entities.Agente Agente
		{
			get;
			set;
		}

		public virtual bool Disponibilita
		{
			get;
			set;
		}

		public virtual int Id
		{
			get;
			set;
		}

		public virtual EW.WebModaNetClassLibrary.Entities.Stagione Stagione
		{
			get;
			set;
		}

		public ImpostazioneStagione()
		{
		}
	}
}