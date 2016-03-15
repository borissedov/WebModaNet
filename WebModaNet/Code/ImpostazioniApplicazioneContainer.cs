using EW.WebModaNetClassLibrary.Entities;
using EW.WebModaNetClassLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace EW.WebModaNet.Code
{
	public class ImpostazioniApplicazioneContainer
	{
		public bool AbiObbligatorio
		{
			get
			{
				return this.GetImpostazione<bool>("AbiObbligatorio", true, true);
			}
		}

		public bool AttivaAreaDocumentale
		{
			get
			{
				return this.GetImpostazione<bool>("AttivaAreaDocumentale", false, true);
			}
		}

		public bool BloccoDataConsegnaManualeTestata
		{
			get
			{
				return this.GetImpostazione<bool>("BloccoDataConsegnaManualeTestata", true, true);
			}
		}

		public bool BloccoIndirizziNuoviClientiVecchi
		{
			get
			{
				return this.GetImpostazione<bool>("BloccoIndirizziNuoviClientiVecchi", true, true);
			}
		}

		public bool BloccoNuoviClienti
		{
			get
			{
				return this.GetImpostazione<bool>("BloccoNuoviClienti", false, true);
			}
		}

		public bool CabObbligatorio
		{
			get
			{
				return this.GetImpostazione<bool>("CabObbligatorio", true, true);
			}
		}

		public string CapDitta
		{
			get
			{
				return this.GetImpostazione<string>("CapDitta", string.Empty, true);
			}
		}

		public bool CapIndirizzoObbligatorio
		{
			get
			{
				return this.GetImpostazione<bool>("CapIndirizzoObbligatorio", true, true);
			}
		}

		public bool CapSedeLegaleObbligatorio
		{
			get
			{
				return this.GetImpostazione<bool>("CapSedeLegaleObbligatorio", true, true);
			}
		}

		public string CartellaDocumentiPdf
		{
			get
			{
				return this.GetImpostazione<string>("CartellaDocumentiPdf", "~/Documents/PDF", true);
			}
		}

		public string CartellaPdfArticoli
		{
			get
			{
				return this.GetImpostazione<string>("CartellaPdfArticoli", "~/Documents/PDFArticoli", true);
			}
		}

		public string CittaDitta
		{
			get
			{
				return this.GetImpostazione<string>("CittaDitta", string.Empty, true);
			}
		}

		public string CodiceDitta
		{
			get
			{
				return this.GetImpostazione<string>("CodiceDitta", string.Empty, true);
			}
		}

		public bool CodiceFiscaleObbligatorio
		{
			get
			{
				return this.GetImpostazione<bool>("CodiceFiscaleObbligatorio", true, true);
			}
		}

		public string CondizioniVendita
		{
			get
			{
				string str = Convert.ToString(this.GetImpostazione<string>("CondizioniVendita", string.Empty, true));
				return str;
			}
		}

		public int DisponibilitaLimiteInferiore
		{
			get
			{
				return this.GetImpostazione<int>("DisponibilitaLimiteInferiore", 0, true);
			}
		}

		public int DisponibilitaLimiteSuperiore
		{
			get
			{
				return this.GetImpostazione<int>("DisponibilitaLimiteSuperiore", 0, true);
			}
		}

		public string EmailDitta
		{
			get
			{
				return this.GetImpostazione<string>("EmailDitta", string.Empty, true);
			}
		}

		public string FaxDitta
		{
			get
			{
				return this.GetImpostazione<string>("FaxDitta", string.Empty, true);
			}
		}

		public bool IbanObbligatorio
		{
			get
			{
				return this.GetImpostazione<bool>("IbanObbligatorio", true, true);
			}
		}

		public int[] IdTipiOrdineAnnullamento
		{
			get
			{
				int[] array;
				int idTipoOrdineRiassortimento = WebConfigSettings.IdTipoOrdineRiassortimento;
				string s = this.GetImpostazione<string>("IdTipiOrdineAnnullamento", idTipoOrdineRiassortimento.ToString(), true);
				if (!string.IsNullOrEmpty(s))
				{
					char[] chrArray = new char[] { ',' };
					array = (
						from x in s.Split(chrArray)
						select Convert.ToInt32(x.Trim())).ToArray<int>();
				}
				else
				{
					array = new int[0];
				}
				return array;
			}
		}

		public string IndirizzoDitta
		{
			get
			{
				return this.GetImpostazione<string>("IndirizzoDitta", string.Empty, true);
			}
		}

		public string IntestazioneStampa
		{
			get
			{
				string str = Convert.ToString(this.GetImpostazione<string>("IntestazioneStampa", string.Empty, true));
				return str;
			}
		}

		public bool IsApplicazioneSospesa
		{
			get
			{
				return this.GetImpostazione<bool>("Sospensione", false, false);
			}
		}

		public string LogoDitta
		{
			get
			{
				return this.GetImpostazione<string>("LogoDitta", string.Empty, true);
			}
		}

		public string MessaggioHome
		{
			get
			{
				return this.GetImpostazione<string>("MessaggioHome", string.Empty, true);
			}
		}

		public bool MostraGalleriaImmagini
		{
			get
			{
				return this.GetImpostazione<bool>("MostraGalleriaImmagini", false, true);
			}
		}

		public bool MostraImmaginiNonTrovate
		{
			get
			{
				return this.GetImpostazione<bool>("MostraImmaginiNonTrovate", false, true);
			}
		}

		public bool MostraPdfArticoli
		{
			get
			{
				return this.GetImpostazione<bool>("MostraPdfArticoli", false, true);
			}
		}

		public bool NascondiSconto
		{
			get
			{
				return this.GetImpostazione<bool>("NascondiSconto", false, true);
			}
		}

		public string NomeApplicazione
		{
			get
			{
				return this.GetImpostazione<string>("NomeApplicazione", "Web Moda", true);
			}
		}

		public int NumeroDecimali
		{
			get
			{
				return this.GetImpostazione<int>("NumeroDecimali", WebConfigSettings.NumeroDecimali, true);
			}
		}

		public int NumeroGiorniAnnullamentoOrdiniSospesi
		{
			get
			{
				return this.GetImpostazione<int>("NumeroGiorniAnnullamentoOrdiniSospesi", WebConfigSettings.NumeroGiorniAnnullamentoOrdiniSospesi, true);
			}
		}

		public int NumeroMassimoUtenti
		{
			get
			{
				return this.GetImpostazione<int>("NumeroMassimoUtenti", 0, true);
			}
		}

		public string OrdineSpecialeListino
		{
			get
			{
				return this.GetImpostazione<string>("OrdineSpecialeListino", string.Empty, true);
			}
		}

		public string OrdineSpecialeMetedoPagamento
		{
			get
			{
				return this.GetImpostazione<string>("OrdineSpecialeMetedoPagamento", string.Empty, true);
			}
		}

		public int OrdineSpecialeTipo
		{
			get
			{
				return this.GetImpostazione<int>("OrdineSpecialeTipo", 0, true);
			}
		}

		public string PartitaIVADitta
		{
			get
			{
				return this.GetImpostazione<string>("PartitaIVADitta", string.Empty, true);
			}
		}

		public bool PartitaIvaObbligatoria
		{
			get
			{
				return this.GetImpostazione<bool>("PartitaIvaObbligatoria", true, true);
			}
		}

		public string PiedeStampa
		{
			get
			{
				string str = Convert.ToString(this.GetImpostazione<string>("PiedeStampa", string.Empty, true));
				return str;
			}
		}

		public string ProvinciaDitta
		{
			get
			{
				return this.GetImpostazione<string>("ProvinciaDitta", string.Empty, true);
			}
		}

		public string RagioneSocialeDitta
		{
			get
			{
				return this.GetImpostazione<string>("RagioneSocialeDitta", string.Empty, true);
			}
		}

		private IImpostazioneApplicazioneRepository repository
		{
			get;
			set;
		}

		public string SitoWebDitta
		{
			get
			{
				return this.GetImpostazione<string>("SitoWebDitta", string.Empty, true);
			}
		}

		public string TelefonoDitta
		{
			get
			{
				return this.GetImpostazione<string>("TelefonoDitta", string.Empty, true);
			}
		}

		public bool TelefonoObbligatorio
		{
			get
			{
				return this.GetImpostazione<bool>("TelefonoObbligatorio", true, true);
			}
		}

		public string VersioneApplicazione
		{
			get
			{
				return this.GetImpostazione<string>("VersioneApplicazione", string.Empty, true);
			}
		}

		public string VersioneDatabase
		{
			get
			{
				return this.GetImpostazione<string>("VersioneDatabase", string.Empty, true);
			}
		}

		public ImpostazioniApplicazioneContainer(IImpostazioneApplicazioneRepository repository)
		{
			if (repository == null)
			{
				throw new ArgumentNullException("repository");
			}
			this.repository = repository;
		}

		private T GetImpostazione<T>(string key, T defaultValue, bool useCache = true)
		{
			T t;
			if ((!useCache ? true : !CacheManager.Contains(key)))
			{
				T returnValue = defaultValue;
				ImpostazioneApplicazione impostazione = this.repository.GetById(key);
				if (impostazione != null)
				{
					try
					{
						returnValue = (T)Convert.ChangeType(impostazione.Valore, typeof(T));
					}
					catch
					{
						returnValue = defaultValue;
					}
				}
				if (useCache)
				{
					CacheManager.Add(key, returnValue);
				}
				t = returnValue;
			}
			else
			{
				t = (T)CacheManager.Get(key);
			}
			return t;
		}

		public void Salva(ImpostazioneApplicazione impostazioneApplicazione)
		{
			if (impostazioneApplicazione == null)
			{
				throw new ArgumentNullException("impostazioniApplicazione");
			}
			this.Salva(new ImpostazioneApplicazione[] { impostazioneApplicazione });
		}

		public void Salva(params ImpostazioneApplicazione[] impostazioniApplicazione)
		{
			if (impostazioniApplicazione == null)
			{
				throw new ArgumentNullException("impostazioniApplicazione");
			}
			List<ImpostazioneApplicazione> nuoveImpostazioniApplicazione = new List<ImpostazioneApplicazione>();
			ImpostazioneApplicazione[] impostazioneApplicazioneArray = impostazioniApplicazione;
			for (int i = 0; i < (int)impostazioneApplicazioneArray.Length; i++)
			{
				ImpostazioneApplicazione impostazioneApplicazione = impostazioneApplicazioneArray[i];
				ImpostazioneApplicazione nuovaImpostazioneApplicazione = this.repository.GetById(impostazioneApplicazione.Chiave);
				if (nuovaImpostazioneApplicazione != null)
				{
					nuovaImpostazioneApplicazione.Valore = impostazioneApplicazione.Valore;
					nuoveImpostazioniApplicazione.Add(nuovaImpostazioneApplicazione);
				}
				else
				{
					nuoveImpostazioniApplicazione.Add(impostazioneApplicazione);
				}
			}
			this.repository.Save(nuoveImpostazioniApplicazione);
		}
	}
}