using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace EW.WebModaNet.TrasmissioneOrdiniReference
{
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[GeneratedCode("System.Web.Services", "4.0.30319.18408")]
	public class TrasmettiCompletedEventArgs : AsyncCompletedEventArgs
	{
		private object[] results;

		public TrasmissioneOrdiniResponseService Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (TrasmissioneOrdiniResponseService)this.results[0];
			}
		}

		internal TrasmettiCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}
	}
}