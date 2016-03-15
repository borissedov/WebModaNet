using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace EW.WebModaNet.Properties
{
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
	internal sealed class Settings : ApplicationSettingsBase
	{
		private static Settings defaultInstance;

		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		[ApplicationScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("http://localhost/WebModaNet/TrasmissioneOrdiniWebService.asmx")]
		[SpecialSetting(SpecialSetting.WebServiceUrl)]
		public string EW_WebModaNet_TrasmissioneOrdiniReference_TrasmissioneOrdiniWebService
		{
			get
			{
				return (string)this["EW_WebModaNet_TrasmissioneOrdiniReference_TrasmissioneOrdiniWebService"];
			}
		}

		static Settings()
		{
			Settings.defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
		}

		public Settings()
		{
		}
	}
}