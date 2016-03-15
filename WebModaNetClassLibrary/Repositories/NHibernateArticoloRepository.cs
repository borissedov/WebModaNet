using EW.WebModaNetClassLibrary.Entities;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace EW.WebModaNetClassLibrary.Repositories
{
	public class NHibernateArticoloRepository : NHibernateBaseRepository<Articolo, string>, IArticoloRepository, IRepository<Articolo, string>
	{
		public NHibernateArticoloRepository(ISessionFactory sessionFactory) : base(sessionFactory)
		{
		}

		public int[] GetQuantitaImpegnateForVariante(Variante variante, Ordine ordineCorrente, params string[] codiciStatoOrdine)
		{
			int numeroQuantita = (int)variante.Quantita.Length;
			int[] quantitaImpegnate = new int[numeroQuantita];
			var dettagliOrdine2 = 
				from d in base.CurrentSession.Query<DettaglioOrdine>()
				join o in base.CurrentSession.Query<Ordine>() on d.Ordine equals o
				select new { Dettaglio = d, Ordine = o } into o
				where o.Dettaglio.Variante == variante
				where o.Ordine != ordineCorrente
				select o;
			string[] strArrays = codiciStatoOrdine;
			for (int num = 0; num < (int)strArrays.Length; num++)
			{
				string str = strArrays[num];
				dettagliOrdine2 = 
					from o in dettagliOrdine2
					where o.Ordine.Stato.Codice != str
					select o;
			}
			List<DettaglioOrdine> dettagliOrdine = (
				from o in dettagliOrdine2
				select o.Dettaglio).ToList<DettaglioOrdine>();
			foreach (DettaglioOrdine d in dettagliOrdine)
			{
				int[] quantitaVariante = d.Quantita;
				for (int i = 0; i < numeroQuantita; i++)
				{
					quantitaImpegnate[i] = quantitaImpegnate[i] + quantitaVariante[i];
				}
			}
			return quantitaImpegnate;
		}
	}
}