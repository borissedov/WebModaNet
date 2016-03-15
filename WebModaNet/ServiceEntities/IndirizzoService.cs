using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNet.ServiceEntities
{
	[Serializable]
	public class IndirizzoService
	{
		public string Cap
		{
			get;
			set;
		}

		public string Citta1
		{
			get;
			set;
		}

		public string Citta2
		{
			get;
			set;
		}

		public string CodiceCliente
		{
			get;
			set;
		}

		public string CodiceNazione
		{
			get;
			set;
		}

		public string CodiceProvincia
		{
			get;
			set;
		}

		public int Id
		{
			get;
			set;
		}

		public bool Predefinito
		{
			get;
			set;
		}

		public string RagioneSociale1
		{
			get;
			set;
		}

		public string RagioneSociale2
		{
			get;
			set;
		}

		public string Via1
		{
			get;
			set;
		}

		public string Via2
		{
			get;
			set;
		}

		public IndirizzoService()
		{
		}
	}
}