using EW.WebModaNet.Code;
using EW.WebModaNet.ServiceEntities;
using EW.WebModaNetClassLibrary.Entities;
using EW.WebModaNetClassLibrary.Repositories;
using EW.WebModaNetClassLibrary.Utils;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Web;
using System.Web.Services;

namespace EW.WebModaNet
{
	[ToolboxItem(false)]
	[WebService(Namespace="http://webmodanet.expertweb.info/")]
	[WebServiceBinding(ConformsTo=WsiProfiles.BasicProfile1_1)]
	public class TrasmissioneOrdiniWebService : WebService
	{
		public TrasmissioneOrdiniWebService()
		{
		}

		private void AddClienteAndIndirizzi(ClienteService clienteRequest, IClienteRepository clienteRepository)
		{
			Cliente nuovoCliente = ServerServiceUtils.ConvertClienteServiceToCliente(clienteRequest);
			nuovoCliente.Stato = ServiceLocator.Current.GetInstance<IRepository<StatoCliente, string>>().GetById(WebConfigSettings.CodiceStatoClienteTrasmesso);
			clienteRepository.Save(nuovoCliente);
		}

		private void AddOrdine(OrdineService ordineRequest, IOrdineRepository ordineRepository)
		{
			Ordine nuovoOrdine = ServerServiceUtils.ConvertOrdineServiceToOrdine(ordineRequest);
			nuovoOrdine.Stato = ServiceLocator.Current.GetInstance<IRepository<StatoOrdine, string>>().GetById(WebConfigSettings.CodiceStatoOrdineTrasmesso);
			ordineRepository.SaveOrdineTrasmesso(nuovoOrdine);
		}

		private List<ClienteResponseService> CheckAndAddClientiAndIndirizzi(TrasmissioneOrdiniRequestService trasmissione)
		{
			List<ClienteResponseService> clientiResponse = new List<ClienteResponseService>();
			List<ClienteService> clientiRequest = trasmissione.Clienti;
			IClienteRepository clienteRepository = ServiceLocator.Current.GetInstance<IClienteRepository>();
			foreach (ClienteService clienteRequest in clientiRequest)
			{
				ClienteResponseService clienteResponse = new ClienteResponseService()
				{
					Codice = clienteRequest.Codice
				};
				if (clienteRepository.GetById(clienteRequest.Codice) == null)
				{
					try
					{
						this.AddClienteAndIndirizzi(clienteRequest, clienteRepository);
						clienteResponse.Stato = StatoTrasmissioneService.Trasmesso;
						LogUtils.Info(string.Format("Il cliente \"{0}\" ricevuto dall'utente \"{0}\" è stato elaborato correttamente.", clienteRequest.Codice, trasmissione.CodiceUtente));
					}
					catch (Exception exception)
					{
						Exception e = exception;
						clienteResponse.Stato = StatoTrasmissioneService.NonTrasmesso;
						LogUtils.Error(string.Format("Errore durante l'elaborazione del cliente \"{0}\" ricevuto dall'utente \"{0}\".", clienteRequest.Codice, trasmissione.CodiceUtente), e);
					}
				}
				else
				{
					clienteResponse.Stato = StatoTrasmissioneService.GiaTrasmesso;
					LogUtils.Info(string.Format("Il cliente \"{0}\" ricevuto dall'utente \"{0}\" risulta già trasmesso.", clienteRequest.Codice, trasmissione.CodiceUtente));
				}
				clientiResponse.Add(clienteResponse);
			}
			return clientiResponse;
		}

		private List<OrdineResponseService> CheckAndAddOrdiniAndDettagliOrdine(TrasmissioneOrdiniRequestService trasmissione)
		{
			List<OrdineResponseService> ordiniResponse = new List<OrdineResponseService>();
			List<OrdineService> ordiniRequest = trasmissione.Ordini;
			IOrdineRepository ordineRepository = ServiceLocator.Current.GetInstance<IOrdineRepository>();
			foreach (OrdineService ordineRequest in ordiniRequest)
			{
				OrdineResponseService ordineResponse = new OrdineResponseService()
				{
					Codice = ordineRequest.Codice
				};
				if (ordineRepository.GetById(ordineRequest.Codice) == null)
				{
					try
					{
						this.AddOrdine(ordineRequest, ordineRepository);
						ordineResponse.Stato = StatoTrasmissioneService.Trasmesso;
						LogUtils.Info(string.Format("L'ordine \"{0}\" ricevuto dall'utente \"{0}\" è stato elaborato correttamente.", ordineRequest.Codice, trasmissione.CodiceUtente));
					}
					catch (Exception exception)
					{
						Exception e = exception;
						ordineResponse.Stato = StatoTrasmissioneService.NonTrasmesso;
						LogUtils.Error(string.Format("Errore durante l'elaborazione dell'ordine \"{0}\" ricevuto dall'utente \"{0}\".", ordineRequest.Codice, trasmissione.CodiceUtente), e);
					}
				}
				else
				{
					ordineResponse.Stato = StatoTrasmissioneService.GiaTrasmesso;
					LogUtils.Info(string.Format("L'ordine \"{0}\" ricevuto dall'utente \"{0}\" risulta già trasmesso.", ordineRequest.Codice, trasmissione.CodiceUtente));
				}
				ordiniResponse.Add(ordineResponse);
			}
			return ordiniResponse;
		}

		[WebMethod]
		public string GetMD5App()
		{
			string mD5File;
			string path = Path.Combine(HttpContext.Current.Server.MapPath(WebConfigSettings.ServerUpdateDirectory), WebConfigSettings.UpdateAppZipFileName);
			if (File.Exists(path))
			{
				mD5File = Utils.GetMD5File(path);
			}
			else
			{
				mD5File = null;
			}
			return mD5File;
		}

		[WebMethod]
		public string GetMD5DB(string codiceUtente)
		{
			string mD5File;
			string fileName = string.Format(WebConfigSettings.UpdateDBZipFileName, codiceUtente);
			string path = Path.Combine(HttpContext.Current.Server.MapPath(WebConfigSettings.ServerUpdateDirectory), fileName);
			if (File.Exists(path))
			{
				mD5File = Utils.GetMD5File(path);
			}
			else
			{
				mD5File = null;
			}
			return mD5File;
		}

		[WebMethod]
		public string GetMD5Img()
		{
			string mD5File;
			string path = Path.Combine(HttpContext.Current.Server.MapPath(WebConfigSettings.ServerUpdateDirectory), WebConfigSettings.UpdateImgZipFileName);
			if (File.Exists(path))
			{
				mD5File = Utils.GetMD5File(path);
			}
			else
			{
				mD5File = null;
			}
			return mD5File;
		}

		[WebMethod]
		public TrasmissioneOrdiniResponseService Trasmetti(TrasmissioneOrdiniRequestService trasmissione)
		{
			TrasmissioneOrdiniResponseService trasmissioneOrdiniResponseService;
			TrasmissioneOrdiniResponseService response = new TrasmissioneOrdiniResponseService()
			{
				Ordini = new List<OrdineResponseService>(),
				Clienti = new List<ClienteResponseService>()
			};
			if (Utils.GetMD5(string.Concat(trasmissione.CodiceUtente, WebConfigSettings.HashKey)) == trasmissione.Hash)
			{
				response.Esito = EsitoTrasmissioneService.OK;
				response.Clienti = this.CheckAndAddClientiAndIndirizzi(trasmissione);
				response.Ordini = this.CheckAndAddOrdiniAndDettagliOrdine(trasmissione);
				trasmissioneOrdiniResponseService = response;
			}
			else
			{
				response.Esito = EsitoTrasmissioneService.KO;
				response.Messaggio = "Codice di verifica non valido.";
				trasmissioneOrdiniResponseService = response;
			}
			return trasmissioneOrdiniResponseService;
		}
	}
}