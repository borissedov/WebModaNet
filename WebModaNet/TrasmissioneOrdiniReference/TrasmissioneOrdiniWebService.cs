using EW.WebModaNet.Properties;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Protocols;

namespace EW.WebModaNet.TrasmissioneOrdiniReference
{
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[GeneratedCode("System.Web.Services", "4.0.30319.18408")]
	[WebServiceBinding(Name="TrasmissioneOrdiniWebServiceSoap", Namespace="http://webmodanet.expertweb.info/")]
	public class TrasmissioneOrdiniWebService : SoapHttpClientProtocol
	{
		private SendOrPostCallback GetMD5AppOperationCompleted;

		private SendOrPostCallback GetMD5DBOperationCompleted;

		private SendOrPostCallback GetMD5ImgOperationCompleted;

		private SendOrPostCallback TrasmettiOperationCompleted;

		private bool useDefaultCredentialsSetExplicitly;

		public new string Url
		{
			get
			{
				return base.Url;
			}
			set
			{
				if ((!this.IsLocalFileSystemWebService(base.Url) || this.useDefaultCredentialsSetExplicitly ? false : !this.IsLocalFileSystemWebService(value)))
				{
					base.UseDefaultCredentials = false;
				}
				base.Url = value;
			}
		}

		public new bool UseDefaultCredentials
		{
			get
			{
				return base.UseDefaultCredentials;
			}
			set
			{
				base.UseDefaultCredentials = value;
				this.useDefaultCredentialsSetExplicitly = true;
			}
		}

		public TrasmissioneOrdiniWebService()
		{
			this.Url = Settings.Default.EW_WebModaNet_TrasmissioneOrdiniReference_TrasmissioneOrdiniWebService;
			if (!this.IsLocalFileSystemWebService(this.Url))
			{
				this.useDefaultCredentialsSetExplicitly = true;
			}
			else
			{
				this.UseDefaultCredentials = true;
				this.useDefaultCredentialsSetExplicitly = false;
			}
		}

		public new void CancelAsync(object userState)
		{
			base.CancelAsync(userState);
		}

		[SoapDocumentMethod("http://webmodanet.expertweb.info/GetMD5App", RequestNamespace="http://webmodanet.expertweb.info/", ResponseNamespace="http://webmodanet.expertweb.info/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string GetMD5App()
		{
			object[] results = base.Invoke("GetMD5App", new object[0]);
			return (string)results[0];
		}

		public void GetMD5AppAsync()
		{
			this.GetMD5AppAsync(null);
		}

		public void GetMD5AppAsync(object userState)
		{
			if (this.GetMD5AppOperationCompleted == null)
			{
				this.GetMD5AppOperationCompleted = new SendOrPostCallback(this.OnGetMD5AppOperationCompleted);
			}
			base.InvokeAsync("GetMD5App", new object[0], this.GetMD5AppOperationCompleted, userState);
		}

		[SoapDocumentMethod("http://webmodanet.expertweb.info/GetMD5DB", RequestNamespace="http://webmodanet.expertweb.info/", ResponseNamespace="http://webmodanet.expertweb.info/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string GetMD5DB(string codiceUtente)
		{
			object[] objArray = new object[] { codiceUtente };
			return (string)base.Invoke("GetMD5DB", objArray)[0];
		}

		public void GetMD5DBAsync(string codiceUtente)
		{
			this.GetMD5DBAsync(codiceUtente, null);
		}

		public void GetMD5DBAsync(string codiceUtente, object userState)
		{
			if (this.GetMD5DBOperationCompleted == null)
			{
				this.GetMD5DBOperationCompleted = new SendOrPostCallback(this.OnGetMD5DBOperationCompleted);
			}
			object[] objArray = new object[] { codiceUtente };
			base.InvokeAsync("GetMD5DB", objArray, this.GetMD5DBOperationCompleted, userState);
		}

		[SoapDocumentMethod("http://webmodanet.expertweb.info/GetMD5Img", RequestNamespace="http://webmodanet.expertweb.info/", ResponseNamespace="http://webmodanet.expertweb.info/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public string GetMD5Img()
		{
			object[] results = base.Invoke("GetMD5Img", new object[0]);
			return (string)results[0];
		}

		public void GetMD5ImgAsync()
		{
			this.GetMD5ImgAsync(null);
		}

		public void GetMD5ImgAsync(object userState)
		{
			if (this.GetMD5ImgOperationCompleted == null)
			{
				this.GetMD5ImgOperationCompleted = new SendOrPostCallback(this.OnGetMD5ImgOperationCompleted);
			}
			base.InvokeAsync("GetMD5Img", new object[0], this.GetMD5ImgOperationCompleted, userState);
		}

		private bool IsLocalFileSystemWebService(string url)
		{
			bool flag;
			if ((url == null ? false : !(url == string.Empty)))
			{
				System.Uri wsUri = new System.Uri(url);
				flag = ((wsUri.Port < 1024 ? true : string.Compare(wsUri.Host, "localHost", StringComparison.OrdinalIgnoreCase) != 0) ? false : true);
			}
			else
			{
				flag = false;
			}
			return flag;
		}

		private void OnGetMD5AppOperationCompleted(object arg)
		{
			if (this.GetMD5AppCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				this.GetMD5AppCompleted(this, new GetMD5AppCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
			}
		}

		private void OnGetMD5DBOperationCompleted(object arg)
		{
			if (this.GetMD5DBCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				this.GetMD5DBCompleted(this, new GetMD5DBCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
			}
		}

		private void OnGetMD5ImgOperationCompleted(object arg)
		{
			if (this.GetMD5ImgCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				this.GetMD5ImgCompleted(this, new GetMD5ImgCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
			}
		}

		private void OnTrasmettiOperationCompleted(object arg)
		{
			if (this.TrasmettiCompleted != null)
			{
				InvokeCompletedEventArgs invokeArgs = (InvokeCompletedEventArgs)arg;
				this.TrasmettiCompleted(this, new TrasmettiCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
			}
		}

		[SoapDocumentMethod("http://webmodanet.expertweb.info/Trasmetti", RequestNamespace="http://webmodanet.expertweb.info/", ResponseNamespace="http://webmodanet.expertweb.info/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public TrasmissioneOrdiniResponseService Trasmetti(TrasmissioneOrdiniRequestService trasmissione)
		{
			object[] objArray = new object[] { trasmissione };
			return (TrasmissioneOrdiniResponseService)base.Invoke("Trasmetti", objArray)[0];
		}

		public void TrasmettiAsync(TrasmissioneOrdiniRequestService trasmissione)
		{
			this.TrasmettiAsync(trasmissione, null);
		}

		public void TrasmettiAsync(TrasmissioneOrdiniRequestService trasmissione, object userState)
		{
			if (this.TrasmettiOperationCompleted == null)
			{
				this.TrasmettiOperationCompleted = new SendOrPostCallback(this.OnTrasmettiOperationCompleted);
			}
			object[] objArray = new object[] { trasmissione };
			base.InvokeAsync("Trasmetti", objArray, this.TrasmettiOperationCompleted, userState);
		}

		public event GetMD5AppCompletedEventHandler GetMD5AppCompleted;

		public event GetMD5DBCompletedEventHandler GetMD5DBCompleted;

		public event GetMD5ImgCompletedEventHandler GetMD5ImgCompleted;

		public event TrasmettiCompletedEventHandler TrasmettiCompleted;
	}
}