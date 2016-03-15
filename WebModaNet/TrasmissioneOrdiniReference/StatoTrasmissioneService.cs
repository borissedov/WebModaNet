using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace EW.WebModaNet.TrasmissioneOrdiniReference
{
	[GeneratedCode("System.Xml", "4.0.30319.18408")]
	[Serializable]
	[XmlType(Namespace="http://webmodanet.expertweb.info/")]
	public enum StatoTrasmissioneService
	{
		Trasmesso,
		NonTrasmesso,
		GiaTrasmesso
	}
}