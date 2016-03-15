using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace EW.WebModaNet.TrasmissioneOrdiniReference
{
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[GeneratedCode("System.Web.Services", "4.0.30319.18408")]
	public class GetMD5AppCompletedEventArgs : AsyncCompletedEventArgs
	{
		private object[] results;

		public string Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[0];
			}
		}

		internal GetMD5AppCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}
	}
}