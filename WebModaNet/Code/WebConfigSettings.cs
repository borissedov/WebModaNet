using System;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.Configuration;

namespace EW.WebModaNet.Code
{
	public static class WebConfigSettings
	{
		public static string[] AllowedImageExtensions
		{
			get
			{
				string str = WebConfigUtils.GetString("AllowedImageExtensions");
				char[] chrArray = new char[] { ',' };
				string[] array = (
					from x in str.Split(chrArray)
					select x.Trim()).ToArray<string>();
				return array;
			}
		}

		public static string ApplicationErrorMessageSessionKey
		{
			get
			{
				return WebConfigUtils.GetString("ApplicationErrorMessageSessionKey");
			}
		}

		public static string CartellaAllegati
		{
			get
			{
				return WebConfigUtils.GetString("CartellaAllegati");
			}
		}

		public static string CartellaCataloghi
		{
			get
			{
				return WebConfigUtils.GetString("CartellaCataloghi");
			}
		}

		public static string CartellaImmaginiArticoli
		{
			get
			{
				return WebConfigUtils.GetString("CartellaImmaginiArticoli");
			}
		}

		public static string CartellaImmaginiContatti
		{
			get
			{
				return WebConfigUtils.GetString("CartellaImmaginiContatti");
			}
		}

		public static string CartellaImmaginiPromozioni
		{
			get
			{
				return WebConfigUtils.GetString("CartellaImmaginiPromozioni");
			}
		}

		public static string CartellaImmaginiVarianti
		{
			get
			{
				return WebConfigUtils.GetString("CartellaImmaginiVarianti");
			}
		}

		public static string CartellaManuali
		{
			get
			{
				return WebConfigUtils.GetString("CartellaManuali");
			}
		}

		public static string ClientUpdateDirectory
		{
			get
			{
				return WebConfigUtils.GetString("ClientUpdateDirectory");
			}
		}

		public static string CodiceAgenteAutenticatoSessionKey
		{
			get
			{
				return WebConfigUtils.GetString("CodiceAgenteAutenticatoSessionKey");
			}
		}

		public static string CodiceLinguaItaliano
		{
			get
			{
				return WebConfigUtils.GetString("CodiceLinguaItaliano");
			}
		}

		public static string CodiceNazioneItalia
		{
			get
			{
				return WebConfigUtils.GetString("CodiceNazioneItalia");
			}
		}

		public static string CodiceOrdineQueryStringKey
		{
			get
			{
				return WebConfigUtils.GetString("CodiceOrdineQueryStringKey");
			}
		}

		public static string CodiceStatoClienteElaborato
		{
			get
			{
				return WebConfigUtils.GetString("CodiceStatoClienteElaborato");
			}
		}

		public static string CodiceStatoClienteGestionale
		{
			get
			{
				return WebConfigUtils.GetString("CodiceStatoClienteGestionale");
			}
		}

		public static string CodiceStatoClienteNuovo
		{
			get
			{
				return WebConfigUtils.GetString("CodiceStatoClienteNuovo");
			}
		}

		public static string CodiceStatoClienteTrasmesso
		{
			get
			{
				return WebConfigUtils.GetString("CodiceStatoClienteTrasmesso");
			}
		}

		public static string CodiceStatoOrdineAnnullato
		{
			get
			{
				return WebConfigUtils.GetString("CodiceStatoOrdineAnnullato");
			}
		}

		public static string CodiceStatoOrdineChiuso
		{
			get
			{
				return WebConfigUtils.GetString("CodiceStatoOrdineChiuso");
			}
		}

		public static string CodiceStatoOrdineElaborato
		{
			get
			{
				return WebConfigUtils.GetString("CodiceStatoOrdineElaborato");
			}
		}

		public static string CodiceStatoOrdineEliminato
		{
			get
			{
				return WebConfigUtils.GetString("CodiceStatoOrdineEliminato");
			}
		}

		public static string CodiceStatoOrdineSospeso
		{
			get
			{
				return WebConfigUtils.GetString("CodiceStatoOrdineSospeso");
			}
		}

		public static string CodiceStatoOrdineTemporaneo
		{
			get
			{
				return WebConfigUtils.GetString("CodiceStatoOrdineTemporaneo");
			}
		}

		public static string CodiceStatoOrdineTrasmesso
		{
			get
			{
				return WebConfigUtils.GetString("CodiceStatoOrdineTrasmesso");
			}
		}

		public static string CodiceTipoAgenteAgente
		{
			get
			{
				return WebConfigUtils.GetString("CodiceTipoAgenteAgente");
			}
		}

		public static string CodiceTipoAgenteAmministratore
		{
			get
			{
				return WebConfigUtils.GetString("CodiceTipoAgenteAmministratore");
			}
		}

		public static string CodiceTipoAgenteCapoArea
		{
			get
			{
				return WebConfigUtils.GetString("CodiceTipoAgenteCapoArea");
			}
		}

		public static string CodiceTipoAgenteCliente
		{
			get
			{
				return WebConfigUtils.GetString("CodiceTipoAgenteCliente");
			}
		}

		public static string CodiceTipoAgenteExpertweb
		{
			get
			{
				return WebConfigUtils.GetString("CodiceTipoAgenteExpertweb");
			}
		}

		public static string[] CodiciTipoAgenteAmministratore
		{
			get
			{
				string str = WebConfigUtils.GetString("CodiciTipoAgenteAmministratore");
				char[] chrArray = new char[] { ',' };
				string[] array = (
					from x in str.Split(chrArray)
					select x.Trim()).ToArray<string>();
				return array;
			}
		}

		public static bool ControlliDiValidazioneAttivati
		{
			get
			{
				return WebConfigUtils.GetBool("ControlliDiValidazioneAttivati");
			}
		}

		public static bool DebugMode
		{
			get
			{
				return WebConfigUtils.GetBool("DebugMode");
			}
		}

		public static bool DisponibilitaAttivate
		{
			get
			{
				return WebConfigUtils.GetBool("DisponibilitaAttivate");
			}
		}

		public static string EmptyImageName
		{
			get
			{
				return WebConfigUtils.GetString("EmptyImageName");
			}
		}

		public static string ErrorMessageSessionKey
		{
			get
			{
				return WebConfigUtils.GetString("ErrorMessageSessionKey");
			}
		}

		public static bool FiltraDateConsegnaOffline
		{
			get
			{
				return WebConfigUtils.GetBool("FiltraDateConsegnaOffline");
			}
		}

		public static string HashKey
		{
			get
			{
				return WebConfigUtils.GetString("HashKey");
			}
		}

		public static string[] IdentityTables
		{
			get
			{
				string str = WebConfigUtils.GetString("IdentityTables");
				char[] chrArray = new char[] { ',' };
				string[] array = (
					from x in str.Split(chrArray)
					select x.Trim()).ToArray<string>();
				return array;
			}
		}

		public static int IDTipoCategoriaBanner1
		{
			get
			{
				return WebConfigUtils.GetInt("IDTipoCategoriaBanner1");
			}
		}

		public static int IDTipoCategoriaBanner2
		{
			get
			{
				return WebConfigUtils.GetInt("IDTipoCategoriaBanner2");
			}
		}

		public static int IDTipoCategoriaGenere
		{
			get
			{
				return WebConfigUtils.GetInt("IDTipoCategoriaGenere");
			}
		}

		public static int IDTipoCategoriaGruppo
		{
			get
			{
				return WebConfigUtils.GetInt("IDTipoCategoriaGruppo");
			}
		}

		public static int IDTipoCategoriaTessuto
		{
			get
			{
				return WebConfigUtils.GetInt("IDTipoCategoriaTessuto");
			}
		}

		public static int[] IDTipoOrdineOffline
		{
			get
			{
				string str = WebConfigUtils.GetString("IDTipoOrdineOffline");
				char[] chrArray = new char[] { ',' };
				int[] array = (
					from x in str.Split(chrArray)
					select Convert.ToInt32(x.Trim())).ToArray<int>();
				return array;
			}
		}

		public static int IdTipoOrdineRiassortimento
		{
			get
			{
				return WebConfigUtils.GetInt("IDTipoOrdineRiassortimento");
			}
		}

		public static string ImageSuffix
		{
			get
			{
				return WebConfigUtils.GetString("ImageSuffix");
			}
		}

		public static bool ImballiAttivi
		{
			get
			{
				return WebConfigUtils.GetBool("ImballiAttivi");
			}
		}

		public static string ImmagineDisponibilitaInEsaurimento
		{
			get
			{
				return WebConfigUtils.GetString("ImmagineDisponibilitaInEsaurimento");
			}
		}

		public static string ImmagineDisponibilitaMax
		{
			get
			{
				return WebConfigUtils.GetString("ImmagineDisponibilitaMax");
			}
		}

		public static string ImmagineDisponibilitaMed
		{
			get
			{
				return WebConfigUtils.GetString("ImmagineDisponibilitaMed");
			}
		}

		public static string ImmagineDisponibilitaMin
		{
			get
			{
				return WebConfigUtils.GetString("ImmagineDisponibilitaMin");
			}
		}

		public static string ImmagineVarianteNonTrovata
		{
			get
			{
				return WebConfigUtils.GetString("ImmagineVarianteNonTrovata");
			}
		}

		public static string InfoMessageSessionKey
		{
			get
			{
				return WebConfigUtils.GetString("InfoMessageSessionKey");
			}
		}

		public static bool IsOnline
		{
			get
			{
				return WebConfigUtils.GetBool("Online");
			}
		}

		public static string LastUpdateAppZipFileName
		{
			get
			{
				return WebConfigUtils.GetString("LastUpdateAppZipFileName");
			}
		}

		public static string LastUpdateDBZipFileName
		{
			get
			{
				return WebConfigUtils.GetString("LastUpdateDBZipFileName");
			}
		}

		public static bool ListiniClienteAttivi
		{
			get
			{
				return WebConfigUtils.GetBool("ListiniClienteAttivi");
			}
		}

		public static bool ListiniPerVarianteAttivi
		{
			get
			{
				return WebConfigUtils.GetBool("ListiniPerVarianteAttivi");
			}
		}

		public static string LogoImageFolder
		{
			get
			{
				return WebConfigUtils.GetString("LogoImageFolder");
			}
		}

		public static string LogoImageName
		{
			get
			{
				return WebConfigUtils.GetString("LogoImageName");
			}
		}

		public static int MagicNumber
		{
			get
			{
				return WebConfigUtils.GetInt("MagicNumber");
			}
		}

		public static int MaxArticoliCaricabili
		{
			get
			{
				return WebConfigUtils.GetInt("MaxArticoliCaricabili");
			}
		}

		public static int MaxGalleryImages
		{
			get
			{
				return WebConfigUtils.GetInt("MaxGalleryImages");
			}
		}

		public static int MaxImageSize
		{
			get
			{
				return WebConfigUtils.GetInt("MaxImageSize");
			}
		}

		public static int NumeroDecimali
		{
			get
			{
				return WebConfigUtils.GetInt("NumeroDecimali");
			}
		}

		public static int NumeroGiorniAnnullamentoOrdiniSospesi
		{
			get
			{
				return WebConfigUtils.GetInt("NumeroGiorniAnnullamentoOrdiniSospesi");
			}
		}

		public static int NumeroImpostazioniListino
		{
			get
			{
				return WebConfigUtils.GetInt("NumeroImpostazioniListino");
			}
		}

		public static int NumeroImpostazioniMetodoPagamento
		{
			get
			{
				return WebConfigUtils.GetInt("NumeroImpostazioniMetodoPagamento");
			}
		}

		public static int NumeroImpostazioniOrdine
		{
			get
			{
				return WebConfigUtils.GetInt("NumeroImpostazioniOrdine");
			}
		}

		public static int NumeroImpostazioniStagione
		{
			get
			{
				return WebConfigUtils.GetInt("NumeroImpostazioniStagione");
			}
		}

		public static int NumeroImpostazioniValuta
		{
			get
			{
				return WebConfigUtils.GetInt("NumeroImpostazioniListino");
			}
		}

		public static int NumeroMassimoScontiDettaglioOrdine
		{
			get
			{
				return WebConfigUtils.GetInt("NumeroMassimoScontiDettaglioOrdine");
			}
		}

		public static bool OpzioneAllegatoTestata
		{
			get
			{
				return WebConfigUtils.GetBool("OpzioneAllegatoTestata");
			}
		}

		public static bool OpzioneBloccaDisponibilita
		{
			get
			{
				return WebConfigUtils.GetBool("OpzioneBloccaDisponibilita");
			}
		}

		public static bool OpzioneForzaListiniMancanti
		{
			get
			{
				return WebConfigUtils.GetBool("OpzioneForzaListiniMancanti");
			}
		}

		public static bool OpzioneIconaDisponibilita
		{
			get
			{
				return WebConfigUtils.GetBool("OpzioneIconaDisponibilita");
			}
		}

		public static bool OpzioneMostraListinoConsigliato
		{
			get
			{
				return WebConfigUtils.GetBool("OpzioneMostraListinoConsigliato");
			}
		}

		public static bool OpzioneMostraMenuClienti
		{
			get
			{
				return WebConfigUtils.GetBool("OpzioneMostraMenuClienti");
			}
		}

		public static bool OpzioneMostraRichiediUtenza
		{
			get
			{
				return WebConfigUtils.GetBool("OpzioneMostraRichiediUtenza");
			}
		}

		public static bool OpzioneMostraTastoNascondiImmagini
		{
			get
			{
				return WebConfigUtils.GetBool("OpzioneMostraTastoNascondiImmagini");
			}
		}

		public static bool OpzioneNoteTestata
		{
			get
			{
				return WebConfigUtils.GetBool("OpzioneNoteTestata");
			}
		}

		public static bool OpzioneVarianteinEsaurimento
		{
			get
			{
				return WebConfigUtils.GetBool("OpzioneVarianteinEsaurimento");
			}
		}

		public static bool OpzioneVisualizzaDataDecorrenza
		{
			get
			{
				return WebConfigUtils.GetBool("OpzioneVisualizzaDataDecorrenza");
			}
		}

		public static bool OpzioneVisualizzaDataUltimaConsegna
		{
			get
			{
				return WebConfigUtils.GetBool("OpzioneVisualizzaDataUltimaConsegna");
			}
		}

		public static bool OpzioneVisualizzaImpostazioniStaticheOrdine
		{
			get
			{
				return WebConfigUtils.GetBool("OpzioneVisualizzaImpostazioniStaticheOrdine");
			}
		}

		public static bool PoliticheScontoAttive
		{
			get
			{
				return WebConfigUtils.GetBool("PoliticheScontoAttive");
			}
		}

		public static string Release
		{
			get
			{
				return WebConfigUtils.GetString("Release");
			}
		}

		public static bool RunMigrations
		{
			get
			{
				return WebConfigUtils.GetBool("RunMigrations");
			}
		}

		public static string ServerUpdateDirectory
		{
			get
			{
				return WebConfigUtils.GetString("ServerUpdateDirectory");
			}
		}

		public static bool ShowAdvancedStatistics
		{
			get
			{
				return WebConfigUtils.GetBool("ShowAdvancedStatistics");
			}
		}

		public static bool ShowHomePage
		{
			get
			{
				return WebConfigUtils.GetBool("ShowHomePage");
			}
		}

		public static string[] SkippedTables
		{
			get
			{
				string str = WebConfigUtils.GetString("SkippedTables");
				char[] chrArray = new char[] { ',' };
				string[] array = (
					from x in str.Split(chrArray)
					select x.Trim()).ToArray<string>();
				return array;
			}
		}

		public static string SqlConnectionString
		{
			get
			{
				return WebConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
			}
		}

		public static string SqlServerCeConnectionString
		{
			get
			{
				return WebConfigurationManager.ConnectionStrings["SqlServerCeConnectionString"].ConnectionString;
			}
		}

		public static string SuccessMessageSessionKey
		{
			get
			{
				return WebConfigUtils.GetString("SuccessMessageSessionKey");
			}
		}

		public static string TaskKey
		{
			get
			{
				return WebConfigUtils.GetString("TaskKey");
			}
		}

		public static bool TestataOrdineDefault
		{
			get
			{
				return WebConfigUtils.GetBool("TestataOrdineDefault");
			}
		}

		public static string UpdateAppPathViewStateKey
		{
			get
			{
				return WebConfigUtils.GetString("UpdateAppPathViewStateKey");
			}
		}

		public static string UpdateAppUrl
		{
			get
			{
				return WebConfigUtils.GetString("UpdateAppUrl");
			}
		}

		public static string UpdateAppZipFileName
		{
			get
			{
				return WebConfigUtils.GetString("UpdateAppZipFileName");
			}
		}

		public static string UpdateDBPathViewStateKey
		{
			get
			{
				return WebConfigUtils.GetString("UpdateDBPathViewStateKey");
			}
		}

		public static string UpdateDBUrl
		{
			get
			{
				return WebConfigUtils.GetString("UpdateDBUrl");
			}
		}

		public static string UpdateDBXmlFileName
		{
			get
			{
				return WebConfigUtils.GetString("UpdateDBXmlFileName");
			}
		}

		public static string UpdateDBZipFileName
		{
			get
			{
				return WebConfigUtils.GetString("UpdateDBZipFileName");
			}
		}

		public static string UpdateImgPathViewStateKey
		{
			get
			{
				return WebConfigUtils.GetString("UpdateImgPathViewStateKey");
			}
		}

		public static string UpdateImgUrl
		{
			get
			{
				return WebConfigUtils.GetString("UpdateImgUrl");
			}
		}

		public static string UpdateImgZipFileName
		{
			get
			{
				return WebConfigUtils.GetString("UpdateImgZipFileName");
			}
		}

		public static string UserDataFile
		{
			get
			{
				return WebConfigUtils.GetString("UserDataFile");
			}
		}

		public static string VersioneApplicazione
		{
			get
			{
				return WebConfigUtils.GetString("VersioneApplicazione");
			}
		}

		public static string VersioneDatabase
		{
			get
			{
				return WebConfigUtils.GetString("VersioneDatabase");
			}
		}

		public static string ZoomSuffix
		{
			get
			{
				return WebConfigUtils.GetString("ZoomSuffix");
			}
		}
	}
}