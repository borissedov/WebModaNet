using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNet.ServiceEntities
{
	[Serializable]
	public class ImpostazioneApplicazioneService
	{
		public virtual string Chiave
		{
			get;
			set;
		}

		public virtual string Valore
		{
			get;
			set;
		}

		public ImpostazioneApplicazioneService()
		{
		}
	}
}