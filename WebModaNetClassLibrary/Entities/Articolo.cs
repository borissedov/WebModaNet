using EW.WebModaNetClassLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace EW.WebModaNetClassLibrary.Entities
{
	public class Articolo
	{
		public virtual IList<Categoria> Categorie
		{
			get;
			set;
		}

		public virtual string Codice
		{
			get;
			set;
		}

		public virtual string CodiceClasseLogistica
		{
			get;
			set;
		}

		public virtual string CodiceClasseMerceologica
		{
			get;
			set;
		}

		public virtual string Descrizione
		{
			get;
			set;
		}

		public virtual string DescrizioneCompleta
		{
			get
			{
				return this.ToString();
			}
		}

		public virtual string DescrizioneImmagine
		{
			get;
			set;
		}

		public virtual EW.WebModaNetClassLibrary.Entities.Famiglia Famiglia
		{
			get;
			set;
		}

		public virtual EW.WebModaNetClassLibrary.Entities.Linea Linea
		{
			get;
			set;
		}

		public virtual IList<Listino> Listini
		{
			get;
			set;
		}

		public virtual EW.WebModaNetClassLibrary.Entities.Marchio Marchio
		{
			get;
			set;
		}

		public virtual int QuantitaConfezione
		{
			get;
			set;
		}

		public virtual int QuantitaMinima
		{
			get;
			set;
		}

		public virtual EW.WebModaNetClassLibrary.Entities.Segnataglie Segnataglie
		{
			get;
			set;
		}

		public virtual EW.WebModaNetClassLibrary.Entities.Stagione Stagione
		{
			get;
			set;
		}

		protected virtual bool TagliaValida1
		{
			get;
			set;
		}

		protected virtual bool TagliaValida10
		{
			get;
			set;
		}

		protected virtual bool TagliaValida11
		{
			get;
			set;
		}

		protected virtual bool TagliaValida12
		{
			get;
			set;
		}

		protected virtual bool TagliaValida13
		{
			get;
			set;
		}

		protected virtual bool TagliaValida14
		{
			get;
			set;
		}

		protected virtual bool TagliaValida15
		{
			get;
			set;
		}

		protected virtual bool TagliaValida16
		{
			get;
			set;
		}

		protected virtual bool TagliaValida17
		{
			get;
			set;
		}

		protected virtual bool TagliaValida18
		{
			get;
			set;
		}

		protected virtual bool TagliaValida19
		{
			get;
			set;
		}

		protected virtual bool TagliaValida2
		{
			get;
			set;
		}

		protected virtual bool TagliaValida20
		{
			get;
			set;
		}

		protected virtual bool TagliaValida21
		{
			get;
			set;
		}

		protected virtual bool TagliaValida22
		{
			get;
			set;
		}

		protected virtual bool TagliaValida23
		{
			get;
			set;
		}

		protected virtual bool TagliaValida24
		{
			get;
			set;
		}

		protected virtual bool TagliaValida25
		{
			get;
			set;
		}

		protected virtual bool TagliaValida26
		{
			get;
			set;
		}

		protected virtual bool TagliaValida27
		{
			get;
			set;
		}

		protected virtual bool TagliaValida28
		{
			get;
			set;
		}

		protected virtual bool TagliaValida29
		{
			get;
			set;
		}

		protected virtual bool TagliaValida3
		{
			get;
			set;
		}

		protected virtual bool TagliaValida30
		{
			get;
			set;
		}

		protected virtual bool TagliaValida4
		{
			get;
			set;
		}

		protected virtual bool TagliaValida5
		{
			get;
			set;
		}

		protected virtual bool TagliaValida6
		{
			get;
			set;
		}

		protected virtual bool TagliaValida7
		{
			get;
			set;
		}

		protected virtual bool TagliaValida8
		{
			get;
			set;
		}

		protected virtual bool TagliaValida9
		{
			get;
			set;
		}

		public virtual bool[] TaglieValide
		{
			get
			{
				bool[] tagliaValida1 = new bool[] { this.TagliaValida1, this.TagliaValida2, this.TagliaValida3, this.TagliaValida4, this.TagliaValida5, this.TagliaValida6, this.TagliaValida7, this.TagliaValida8, this.TagliaValida9, this.TagliaValida10, this.TagliaValida11, this.TagliaValida12, this.TagliaValida13, this.TagliaValida14, this.TagliaValida15, this.TagliaValida16, this.TagliaValida17, this.TagliaValida18, this.TagliaValida19, this.TagliaValida20, this.TagliaValida21, this.TagliaValida22, this.TagliaValida23, this.TagliaValida24, this.TagliaValida25, this.TagliaValida26, this.TagliaValida27, this.TagliaValida28, this.TagliaValida29, this.TagliaValida30 };
				return tagliaValida1;
			}
		}

		public virtual string UnitaMisura
		{
			get;
			set;
		}

		public virtual IList<Variante> Varianti
		{
			get;
			set;
		}

		public Articolo()
		{
		}

		public virtual IList<TagliaInfo> GetTaglie()
		{
			List<TagliaInfo> taglie = new List<TagliaInfo>();
			for (int i = 0; i < (int)this.Segnataglie.Taglie.Length; i++)
			{
				TagliaInfo tagliaInfo = new TagliaInfo()
				{
					Descrizione = this.Segnataglie.Taglie[i],
					Valida = this.TaglieValide[i]
				};
				taglie.Add(tagliaInfo);
			}
			return taglie;
		}

		public virtual IList<TagliaInfo> GetTaglieForVariante(Variante variante, bool disponibilitaAttivata, bool imballiAttivati, IArticoloRepository repository, Ordine ordineCorrente, params string[] codiciStatoOrdine)
		{
			if (variante == null)
			{
				throw new ArgumentNullException("variante");
			}
			List<TagliaInfo> taglie = new List<TagliaInfo>();
			int numeroTaglie = (int)this.Segnataglie.Taglie.Length;
			int[] quantitaDisponibili = variante.Quantita;
			string[] note = variante.Note;
			if (disponibilitaAttivata)
			{
				int[] quantitaImpegnate = repository.GetQuantitaImpegnateForVariante(variante, ordineCorrente, codiciStatoOrdine);
				for (int i = 0; i < numeroTaglie; i++)
				{
					quantitaDisponibili[i] = quantitaDisponibili[i] - quantitaImpegnate[i];
				}
			}
			for (int i = 0; i < numeroTaglie; i++)
			{
				List<TagliaInfo> tagliaInfos = taglie;
				TagliaInfo tagliaInfo = new TagliaInfo()
				{
					Descrizione = this.Segnataglie.Taglie[i],
					Valida = this.TaglieValide[i],
					DisponibilitaAttivata = disponibilitaAttivata,
					QuantitaInserita = 0,
					QuantitaDisponibile = quantitaDisponibili[i],
					Nota = note[i],
					QuantitaConfezione = this.QuantitaConfezione,
					ImballiAttivati = imballiAttivati
				};
				TagliaInfo tagliaInfo1 = tagliaInfo;
				bool? inEsaurimento = variante.InEsaurimento;
				tagliaInfo1.VarianteInEsaurimento = (inEsaurimento.HasValue ? inEsaurimento.GetValueOrDefault() : false);
				tagliaInfos.Add(tagliaInfo);
			}
			return taglie;
		}

		public virtual void SetTaglieValide(bool[] taglieValide)
		{
			if (taglieValide == null)
			{
				throw new ArgumentNullException("taglieValide");
			}
			bool[] t = new bool[(int)this.TaglieValide.Length];
			for (int i = 0; i < (int)t.Length; i++)
			{
				if (i < (int)taglieValide.Length)
				{
					t[i] = taglieValide[i];
				}
				else
				{
					t[i] = false;
				}
			}
			this.TagliaValida1 = t[0];
			this.TagliaValida2 = t[1];
			this.TagliaValida3 = t[2];
			this.TagliaValida4 = t[3];
			this.TagliaValida5 = t[4];
			this.TagliaValida6 = t[5];
			this.TagliaValida7 = t[6];
			this.TagliaValida8 = t[7];
			this.TagliaValida9 = t[8];
			this.TagliaValida10 = t[9];
			this.TagliaValida11 = t[10];
			this.TagliaValida12 = t[11];
			this.TagliaValida13 = t[12];
			this.TagliaValida14 = t[13];
			this.TagliaValida15 = t[14];
			this.TagliaValida16 = t[15];
			this.TagliaValida17 = t[16];
			this.TagliaValida18 = t[17];
			this.TagliaValida19 = t[18];
			this.TagliaValida20 = t[19];
			this.TagliaValida21 = t[20];
			this.TagliaValida22 = t[21];
			this.TagliaValida23 = t[22];
			this.TagliaValida24 = t[23];
			this.TagliaValida25 = t[24];
			this.TagliaValida26 = t[25];
			this.TagliaValida27 = t[26];
			this.TagliaValida28 = t[27];
			this.TagliaValida29 = t[28];
			this.TagliaValida30 = t[29];
		}

		public override string ToString()
		{
			return string.Concat(this.Codice, " - ", this.Descrizione);
		}
	}
}