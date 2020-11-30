using System;
using System.Xml.Serialization;

namespace ServiceNFe.Entities.Eventos
{
	[Serializable()]
	[XmlRoot( ElementName = "infEvento" )]
	public class InfEvento
	{
		private string _dhevento;

		/// <summary>
		/// Identificador da TAG a ser assinada, a regra de	formação do Id é: “ID” + tpEvento + chave da NF-e + nSeqEvento
		/// </summary>
		[XmlAttribute]
		public string Id
		{
			get; set;
		}

		/// <summary>
		/// Código do órgão de recepção do Evento. Utilizar	a Tabela do IBGE, utilizar 90 para identificar o Ambiente Nacional
		/// </summary>
		[XmlElement( ElementName = "cOrgao",Order = 2 )]
		public string Corgao
		{
			get; set;
		}
		/// <summary>
		/// Identificação do Ambiente:1 – Produção;2 - Homologação
		/// </summary>
		[XmlElement( ElementName = "tpAmb",Order = 3 )]
		public int Tipo_de_Ambiente
		{
			get; set;
		} = 2;

		/// <summary>
		/// Informar o CNPJ ou o CPF do autor do Evento
		/// </summary>

		/// <summary>
		/// CNPJ do contribuinte/Consultado
		/// </summary>
		[XmlElement( ElementName = "CNPJ",Order = 4 )]
		public string CNPJ
		{
			get; set;
		}
		/// <summary>
		/// CPF do contribuinte/Consultado
		/// </summary>
		[XmlElement( ElementName = "CPF",Order = 5 )]
		public string CPF
		{
			get; set;
		}
		/// <summary>
		/// Chave de Acesso da NF-e vinculada ao Evento.
		/// </summary>
		//		[MaxLength
		[XmlElement( ElementName = "chNFe",Order = 6 )]
		public string ChaveNFe
		{
			get; set;
		}

		/// <summary>
		/// Data e hora do evento no formato AAAA-MMDDThh:mm:ssTZD (UTC - Universal 	Coordinated Time, onde TZD pode ser -02:00
		/// (Fernando de Noronha), -03:00 (Brasília) ou - 04:00 (Manaus), no horário de verão serão - 01:00, -02:00 e -03:00. Ex.: 2010-08-
		/// 19T13:00:15-03:00
		/// </summary>
		[XmlElement( ElementName = "dhEvento",Order = 7 )]
		public string DhEvento
		{
			get
			{
				return _dhevento.DataUtc();
			}
			set
			{
				if( _dhevento != value )
				{
					_dhevento = value;
				}
			}
		}

		/// <summary>
		/// Código do de evento = 110110 carta de correção e 110111 cancelamneto de NFe
		/// </summary>
		[XmlElement( ElementName = "tpEvento",Order = 8 )]
		public string TpEvento
		{
			get; set;
		}
		/// <summary>
		/// Sequencial do evento para o mesmo tipo de evento.Para maioria dos eventos será 1, nos  casos em que possa existir mais de um evento,
		/// como é o caso da carta de correção, o autor do evento deve numerar de forma sequencial.
		/// </summary>
		[XmlElement( ElementName = "nSeqEvento",Order = 9 )]
		public string NseqEvento
		{
			get; set;
		}

		/// <summary>
		/// Versão do evento
		/// </summary>
		[XmlElement( ElementName = "verEvento",Order = 10 )]
		public string VerEvento
		{
			get; set;
		}


		[XmlElement( ElementName = "detEvento",Order = 11 )]
		public DetEvento detEvento
		{
			get;set;
		}

		/// <summary>
		/// Inicializador para a Carta de Correção
		/// </summary>
		/// <param name="cNPJ"></param>
		/// <param name="cPF"></param>
		/// <param name="chaveNFe"></param>
		/// <param name="dhEvento"></param>
		/// <param name="tpEvento"></param>
		/// <param name="nseqEvento"></param>
		/// <param name="verEvento"></param>
		/// <param name="detEvento"></param>
		public InfEvento( string cNPJ,string cPF,string chaveNFe,string dhEvento,string tpEvento,string nseqEvento,string verEvento,DetEvento _detEvento )
		{
			CNPJ = cNPJ;
			CPF = cPF;
			ChaveNFe = chaveNFe ?? throw new ArgumentNullException( nameof( chaveNFe ) );
			DhEvento = dhEvento ?? throw new ArgumentNullException( nameof( dhEvento ) );
			TpEvento = tpEvento ?? throw new ArgumentNullException( nameof( tpEvento ) );
			NseqEvento = nseqEvento ?? throw new ArgumentNullException( nameof( nseqEvento ) );
			VerEvento = verEvento ?? throw new ArgumentNullException( nameof( verEvento ) );
			detEvento = _detEvento ?? throw new ArgumentNullException( nameof( detEvento ) );
			Id = "ID" + TpEvento + ChaveNFe + NseqEvento.PadLeft( 2,'0' );
		}

		/// <summary>
		/// Inicializador para o Cancelamento de NFe
		/// </summary>
		/// <param name="cNPJ"></param>
		/// <param name="cPF"></param>
		/// <param name="chaveNFe"></param>
		/// <param name="dhEvento"></param>
		/// <param name="tpEvento"></param>
		/// <param name="verEvento"></param>
		/// <param name="detEvento"></param>
		public InfEvento( string cNPJ,string cPF,string chaveNFe,string dhEvento,string tpEvento,string verEvento,DetEvento detEvento )
		{
			CNPJ = cNPJ;
			CPF = cPF;
			ChaveNFe = chaveNFe ?? throw new ArgumentNullException( nameof( chaveNFe ) );
			DhEvento = dhEvento ?? throw new ArgumentNullException( nameof( dhEvento ) );
			TpEvento = tpEvento ?? throw new ArgumentNullException( nameof( tpEvento ) );
			NseqEvento = "1";
			VerEvento = verEvento ?? throw new ArgumentNullException( nameof( verEvento ) );
			this.detEvento = detEvento ?? throw new ArgumentNullException( nameof( detEvento ) );
			Id = "ID" + TpEvento + ChaveNFe + NseqEvento.PadLeft( 2,'0' );
		}

		public InfEvento()
		{
		}
	}
}
