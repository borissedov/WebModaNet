using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNetClassLibrary.Entities
{
	public class DettaglioDateConsegna
	{
		public DateTime DataConsegna
		{
			get;
			set;
		}

		public DateTime DataDecorrenza
		{
			get;
			set;
		}

		public DateTime DataUltimaConsegna
		{
			get;
			set;
		}

		public string DescrizioneMarchio
		{
			get;
			set;
		}

		public string DescrizioneStagione
		{
			get;
			set;
		}

		public DettaglioDateConsegna()
		{
		}
	}
}