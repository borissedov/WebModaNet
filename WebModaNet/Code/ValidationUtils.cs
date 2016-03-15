using System;
using System.Resources;

namespace EW.WebModaNet.Code
{
	public static class ValidationUtils
	{
		private readonly static ResourceManager resourceManager;

		static ValidationUtils()
		{
			ValidationUtils.resourceManager = new ResourceManager(typeof(Resources));
		}

		public static string Date(string fieldName)
		{
			return string.Format(Resources.ErroreDataNonValida, fieldName);
		}

		public static string Email(string fieldName)
		{
			return string.Format(Resources.ErroreEmailNonValida, fieldName);
		}

		public static string Integer(string fieldName)
		{
			return string.Format(Resources.ErroreNumeroIntero, fieldName);
		}

		public static string Required(string fieldName, bool isResourceKey)
		{
			string message = string.Empty;
			if (!isResourceKey)
			{
				message = string.Format(Resources.ErroreCampoObbligatorio, fieldName);
			}
			else
			{
				string resourceValue = ValidationUtils.resourceManager.GetString(fieldName);
				message = string.Format(Resources.ErroreCampoObbligatorio, resourceValue);
			}
			return message;
		}

		public static string Required(string fieldName)
		{
			return string.Format(Resources.ErroreCampoObbligatorio, fieldName);
		}

		public static string TaxCode(string fieldName)
		{
			return string.Format(Resources.ErroreCodiceFiscaleNonValido, fieldName);
		}

		public static string Vat(string fieldName)
		{
			return string.Format(Resources.ErrorePartitaIvaNonValida, fieldName);
		}
	}
}