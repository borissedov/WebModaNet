using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNetClassLibrary.Entities
{
	public class Documento
	{
		public virtual EW.WebModaNetClassLibrary.Entities.Agente Agente
		{
			get;
			set;
		}

		public virtual EW.WebModaNetClassLibrary.Entities.Cliente Cliente
		{
			get;
			set;
		}

		public virtual DateTime? DataScadenza
		{
			get;
			set;
		}

		public virtual string Descrizione
		{
			get;
			set;
		}

		public virtual int Id
		{
			get;
			set;
		}

		public virtual EW.WebModaNetClassLibrary.Entities.Linea Linea
		{
			get;
			set;
		}

		public virtual string NomeFile
		{
			get;
			set;
		}

		public virtual EW.WebModaNetClassLibrary.Entities.Stagione Stagione
		{
			get;
			set;
		}

		public virtual string Tipo
		{
			get;
			set;
		}

		public virtual string Titolo
		{
			get;
			set;
		}

		public Documento()
		{
		}
	}
}