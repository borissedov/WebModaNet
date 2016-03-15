using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNetClassLibrary.Entities
{
	public class CondizioneCommerciale
	{
		public virtual EW.WebModaNetClassLibrary.Entities.Cliente Cliente
		{
			get;
			set;
		}

		public virtual int CodiceAgente
		{
			get;
			set;
		}

		public virtual string CodiceListino
		{
			get;
			set;
		}

		public virtual string CodicePoliticaSconti
		{
			get;
			set;
		}

		public virtual DateTime DataDecorrenza
		{
			get;
			set;
		}

		public virtual DateTime DataScadenza
		{
			get;
			set;
		}

		public virtual int Id
		{
			get;
			set;
		}

		public virtual EW.WebModaNetClassLibrary.Entities.Marchio Marchio
		{
			get;
			set;
		}

		public virtual EW.WebModaNetClassLibrary.Entities.MetodoPagamento MetodoPagamento
		{
			get;
			set;
		}

		public CondizioneCommerciale()
		{
		}
	}
}