using EW.WebModaNet.TrasmissioneOrdiniReference;
using EW.WebModaNetClassLibrary.Entities;
using System;
using System.Collections.Generic;

namespace EW.WebModaNet.Code
{
	public static class ClientServiceUtils
	{
		public static ClienteService ConvertClienteToClienteService(Cliente cliente)
		{
			int? nullable;
			string codiceUtente;
			string codice;
			string str;
			string codice1;
			int? nullable1;
			int? nullable2;
			int? nullable3;
			string str1;
			string codice2;
			ClienteService clienteService = new ClienteService()
			{
				Codice = cliente.Codice
			};
			ClienteService clienteService1 = clienteService;
			if (cliente.Agente == null)
			{
				codiceUtente = null;
			}
			else
			{
				codiceUtente = cliente.Agente.CodiceUtente;
			}
			clienteService1.CodiceUtente = codiceUtente;
			clienteService.CodiceAgente = cliente.CodiceAgente;
			clienteService.RagioneSociale1 = cliente.RagioneSociale1;
			clienteService.RagioneSociale2 = cliente.RagioneSociale2;
			clienteService.PartitaIva = cliente.PartitaIva;
			clienteService.CodiceFiscale = cliente.CodiceFiscale;
			clienteService.Attivo = cliente.Attivo;
			ClienteService clienteService2 = clienteService;
			if (cliente.Stato == null)
			{
				codice = null;
			}
			else
			{
				codice = cliente.Stato.Codice;
			}
			clienteService2.CodiceStatoCliente = codice;
			clienteService.Rating = cliente.Rating;
			clienteService.Insoluto = cliente.Insoluto;
			clienteService.Telefono = cliente.Telefono;
			clienteService.Cellulare = cliente.Cellulare;
			clienteService.Fax = cliente.Fax;
			clienteService.Email = cliente.Email;
			clienteService.Referente = cliente.Referente;
			clienteService.Banca = cliente.Banca;
			clienteService.Abi = cliente.Abi;
			clienteService.Cab = cliente.Cab;
			clienteService.Iban = cliente.Iban;
			ClienteService clienteService3 = clienteService;
			if (cliente.MetodoPagamentoPredefinito == null)
			{
				str = null;
			}
			else
			{
				str = cliente.MetodoPagamentoPredefinito.Codice;
			}
			clienteService3.CodiceMetodoPagamentoPredefinito = str;
			ClienteService clienteService4 = clienteService;
			if (cliente.ValutaPredefinita == null)
			{
				codice1 = null;
			}
			else
			{
				codice1 = cliente.ValutaPredefinita.Codice;
			}
			clienteService4.CodiceValutaPredefinita = codice1;
			ClienteService clienteService5 = clienteService;
			if (cliente.PortoPredefinito == null)
			{
				nullable = null;
				nullable1 = nullable;
			}
			else
			{
				nullable1 = new int?(cliente.PortoPredefinito.Id);
			}
			clienteService5.IdPortoPredefinito = nullable1;
			ClienteService clienteService6 = clienteService;
			if (cliente.TrasportoPredefinito == null)
			{
				nullable = null;
				nullable2 = nullable;
			}
			else
			{
				nullable2 = new int?(cliente.TrasportoPredefinito.Id);
			}
			clienteService6.IdTrasportoPredefinito = nullable2;
			ClienteService clienteService7 = clienteService;
			if (cliente.VettorePredefinito == null)
			{
				nullable = null;
				nullable3 = nullable;
			}
			else
			{
				nullable3 = new int?(cliente.VettorePredefinito.Id);
			}
			clienteService7.IdVettorePredefinito = nullable3;
			clienteService.CodiceListinoPredefinito = cliente.CodiceListinoPredefinito;
			clienteService.CodicePoliticaSconti = cliente.CodicePoliticaSconti;
			clienteService.CodiceTipologiaCommerciale = cliente.CodiceTipologiaCommerciale;
			clienteService.CodiceCategoria = cliente.CodiceCategoria;
			clienteService.CodiceZona = cliente.CodiceZona;
			clienteService.ViaSedeLegale1 = cliente.ViaSedeLegale1;
			clienteService.ViaSedeLegale2 = cliente.ViaSedeLegale2;
			clienteService.CapSedeLegale = cliente.CapSedeLegale;
			clienteService.CittaSedeLegale1 = cliente.CittaSedeLegale1;
			clienteService.CittaSedeLegale2 = cliente.CittaSedeLegale2;
			ClienteService clienteService8 = clienteService;
			if (cliente.ProvinciaSedeLegale == null)
			{
				str1 = null;
			}
			else
			{
				str1 = cliente.ProvinciaSedeLegale.Codice;
			}
			clienteService8.CodiceProvinciaSedeLegale = str1;
			ClienteService clienteService9 = clienteService;
			if (cliente.NazioneSedeLegale == null)
			{
				codice2 = null;
			}
			else
			{
				codice2 = cliente.NazioneSedeLegale.Codice;
			}
			clienteService9.NazioneSedeLegale = codice2;
			clienteService.CodiceSituazione = cliente.CodiceSituazione;
			List<IndirizzoService> indirizziService = new List<IndirizzoService>();
			foreach (Indirizzo i in cliente.Indirizzi)
			{
				indirizziService.Add(ClientServiceUtils.ConvertIndirizzoToIndirizzoService(i));
			}
			clienteService.Indirizzi = indirizziService.ToArray();
			return clienteService;
		}

		public static DettaglioOrdineService ConvertDettaglioOrdineToDettaglioOrdineService(DettaglioOrdine dettaglioOrdine)
		{
			string codice;
			string str;
			string codice1;
			string str1;
			string codice2;
			DettaglioOrdineService dettaglioOrdineService = new DettaglioOrdineService()
			{
				Id = dettaglioOrdine.Id,
				Progressivo = dettaglioOrdine.Progressivo
			};
			DettaglioOrdineService dettaglioOrdineService1 = dettaglioOrdineService;
			if (dettaglioOrdine.Ordine == null)
			{
				codice = null;
			}
			else
			{
				codice = dettaglioOrdine.Ordine.Codice;
			}
			dettaglioOrdineService1.CodiceOrdine = codice;
			DettaglioOrdineService dettaglioOrdineService2 = dettaglioOrdineService;
			if (dettaglioOrdine.Variante == null)
			{
				str = null;
			}
			else
			{
				str = dettaglioOrdine.Variante.Codice;
			}
			dettaglioOrdineService2.CodiceVariante = str;
			DettaglioOrdineService dettaglioOrdineService3 = dettaglioOrdineService;
			if (dettaglioOrdine.Variante == null)
			{
				codice1 = null;
			}
			else
			{
				codice1 = dettaglioOrdine.Variante.Articolo.Codice;
			}
			dettaglioOrdineService3.CodiceArticolo = codice1;
			DettaglioOrdineService dettaglioOrdineService4 = dettaglioOrdineService;
			if (dettaglioOrdine.Segnataglie == null)
			{
				str1 = null;
			}
			else
			{
				str1 = dettaglioOrdine.Segnataglie.Codice;
			}
			dettaglioOrdineService4.CodiceSegnataglie = str1;
			dettaglioOrdineService.Quantita = dettaglioOrdine.Quantita;
			dettaglioOrdineService.Prezzi = dettaglioOrdine.Prezzi;
			dettaglioOrdineService.Sconti = dettaglioOrdine.Sconti;
			dettaglioOrdineService.CodiceListino = dettaglioOrdine.CodiceListino;
			dettaglioOrdineService.NumeroCapi = dettaglioOrdine.NumeroCapi;
			dettaglioOrdineService.Totale = dettaglioOrdine.Totale;
			dettaglioOrdineService.Note = dettaglioOrdine.Note;
			dettaglioOrdineService.DataConsegna = dettaglioOrdine.DataConsegna;
			dettaglioOrdineService.DataUltimaConsegna = dettaglioOrdine.DataUltimaConsegna;
			dettaglioOrdineService.DataDecorrenza = dettaglioOrdine.DataDecorrenza;
			DettaglioOrdineService dettaglioOrdineService5 = dettaglioOrdineService;
			if (dettaglioOrdine.Imballo == null)
			{
				codice2 = null;
			}
			else
			{
				codice2 = dettaglioOrdine.Imballo.Codice;
			}
			dettaglioOrdineService5.CodiceImballo = codice2;
			dettaglioOrdineService.NumeroImballi = dettaglioOrdine.NumeroImballi;
			dettaglioOrdineService.UnitaMisura = dettaglioOrdine.UnitaMisura;
			return dettaglioOrdineService;
		}

		public static IndirizzoService ConvertIndirizzoToIndirizzoService(Indirizzo indirizzo)
		{
			string codice;
			string str;
			string codice1;
			IndirizzoService indirizzoService = new IndirizzoService()
			{
				Id = indirizzo.Id
			};
			IndirizzoService indirizzoService1 = indirizzoService;
			if (indirizzo.Cliente == null)
			{
				codice = null;
			}
			else
			{
				codice = indirizzo.Cliente.Codice;
			}
			indirizzoService1.CodiceCliente = codice;
			indirizzoService.RagioneSociale1 = indirizzo.RagioneSociale1;
			indirizzoService.RagioneSociale2 = indirizzo.RagioneSociale2;
			indirizzoService.Via1 = indirizzo.Via1;
			indirizzoService.Via2 = indirizzo.Via2;
			indirizzoService.Cap = indirizzo.Cap;
			indirizzoService.Citta1 = indirizzo.Citta1;
			indirizzoService.Citta2 = indirizzo.Citta2;
			IndirizzoService indirizzoService2 = indirizzoService;
			if (indirizzo.Provincia == null)
			{
				str = null;
			}
			else
			{
				str = indirizzo.Provincia.Codice;
			}
			indirizzoService2.CodiceProvincia = str;
			IndirizzoService indirizzoService3 = indirizzoService;
			if (indirizzo.Nazione == null)
			{
				codice1 = null;
			}
			else
			{
				codice1 = indirizzo.Nazione.Codice;
			}
			indirizzoService3.CodiceNazione = codice1;
			indirizzoService.Predefinito = indirizzo.Predefinito;
			return indirizzoService;
		}

		public static OrdineService ConvertOrdineToOrdineService(Ordine ordine)
		{
			int? nullable;
			string codiceUtente;
			string codice;
			string str;
			int? nullable1;
			string codice1;
			string str1;
			string codice2;
			string str2;
			int? nullable2;
			int? nullable3;
			int? nullable4;
			string codice3;
			OrdineService ordineService = new OrdineService()
			{
				Codice = ordine.Codice,
				CodiceGestionale = ordine.CodiceGestionale
			};
			OrdineService ordineService1 = ordineService;
			if (ordine.Agente == null)
			{
				codiceUtente = null;
			}
			else
			{
				codiceUtente = ordine.Agente.CodiceUtente;
			}
			ordineService1.CodiceUtente = codiceUtente;
			ordineService.CodiceAgente = ordine.CodiceAgente;
			ordineService.NumeroOrdine = ordine.NumeroOrdine;
			ordineService.Data = ordine.Data;
			ordineService.DataInserimento = ordine.DataInserimento;
			OrdineService ordineService2 = ordineService;
			if (ordine.Cliente == null)
			{
				codice = null;
			}
			else
			{
				codice = ordine.Cliente.Codice;
			}
			ordineService2.CodiceCliente = codice;
			ordineService.IdIndirizzoConsegna = ordine.IdIndirizzoConsegna;
			OrdineService ordineService3 = ordineService;
			if (ordine.Marchio == null)
			{
				str = null;
			}
			else
			{
				str = ordine.Marchio.Codice;
			}
			ordineService3.CodiceMarchio = str;
			OrdineService ordineService4 = ordineService;
			if (ordine.Tipo == null)
			{
				nullable = null;
				nullable1 = nullable;
			}
			else
			{
				nullable1 = new int?(ordine.Tipo.Id);
			}
			ordineService4.IdTipoOrdine = nullable1;
			OrdineService ordineService5 = ordineService;
			if (ordine.Stagione == null)
			{
				codice1 = null;
			}
			else
			{
				codice1 = ordine.Stagione.Codice;
			}
			ordineService5.CodiceStagione = codice1;
			OrdineService ordineService6 = ordineService;
			if (ordine.Linea == null)
			{
				str1 = null;
			}
			else
			{
				str1 = ordine.Linea.Codice;
			}
			ordineService6.CodiceLinea = str1;
			ordineService.Banca = ordine.Banca;
			OrdineService ordineService7 = ordineService;
			if (ordine.Valuta == null)
			{
				codice2 = null;
			}
			else
			{
				codice2 = ordine.Valuta.Codice;
			}
			ordineService7.CodiceValuta = codice2;
			OrdineService ordineService8 = ordineService;
			if (ordine.MetodoPagamento == null)
			{
				str2 = null;
			}
			else
			{
				str2 = ordine.MetodoPagamento.Codice;
			}
			ordineService8.CodiceMetodoPagamento = str2;
			ordineService.ScontoMetodoPagamento = ordine.ScontoMetodoPagamento;
			ordineService.CodiceListino = ordine.CodiceListino;
			ordineService.NumeroCapi = ordine.NumeroCapi;
			ordineService.Totale = ordine.Totale;
			OrdineService ordineService9 = ordineService;
			if (ordine.Porto == null)
			{
				nullable = null;
				nullable2 = nullable;
			}
			else
			{
				nullable2 = new int?(ordine.Porto.Id);
			}
			ordineService9.IdPorto = nullable2;
			OrdineService ordineService10 = ordineService;
			if (ordine.Trasporto == null)
			{
				nullable = null;
				nullable3 = nullable;
			}
			else
			{
				nullable3 = new int?(ordine.Trasporto.Id);
			}
			ordineService10.IdTrasporto = nullable3;
			OrdineService ordineService11 = ordineService;
			if (ordine.Vettore == null)
			{
				nullable = null;
				nullable4 = nullable;
			}
			else
			{
				nullable4 = new int?(ordine.Vettore.Id);
			}
			ordineService11.IdVettore = nullable4;
			ordineService.Note = ordine.Note;
			OrdineService ordineService12 = ordineService;
			if (ordine.Stato == null)
			{
				codice3 = null;
			}
			else
			{
				codice3 = ordine.Stato.Codice;
			}
			ordineService12.CodiceStatoOrdine = codice3;
			ordineService.Online = ordine.Online;
			ordineService.DataConsegna = ordine.DataConsegna;
			ordineService.DataUltimaConsegna = ordine.DataUltimaConsegna;
			ordineService.DataDecorrenza = ordine.DataDecorrenza;
			ordineService.CodicePoliticaSconti = ordine.CodicePoliticaSconti;
			List<DettaglioOrdineService> dettagliOrdineService = new List<DettaglioOrdineService>();
			foreach (DettaglioOrdine d in ordine.Dettagli)
			{
				dettagliOrdineService.Add(ClientServiceUtils.ConvertDettaglioOrdineToDettaglioOrdineService(d));
			}
			ordineService.Dettagli = dettagliOrdineService.ToArray();
			return ordineService;
		}
	}
}