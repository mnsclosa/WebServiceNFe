using ServiceNFe.Entities.Exceptions;
using ServiceNFe.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace ServiceNFe.Entities.InutilizacaoNumeracao
{
	[Serializable()]
	public class InfInut
	{
		private string _xmotivo;
		private string _justificativa;

		/// <summary>
		/// Identificador da TAG a ser assinada formada com Código da UF + Ano(2 posições) + CNPJ + modelo + série + número inicial e número final
		/// precedida do literal “ID”
		/// </summary>
		[XmlAttribute]
		public string Id
		{
			get; set;
		}
		/// <summary>
		/// Identificação do Ambiente:1 – Produção;2 - Homologação
		/// </summary>
		[XmlElement( ElementName = "tpAmb",Order = 1 )]
		public int TipodeAmbiente
		{
			get; set;
		}
		/// <summary>
		/// Versão do Aplicativo que processou a consulta.
		/// A versão deve ser iniciada com a sigla da UF nos casos de WS próprio ou a sigla
		/// SVAN ou SVRS nos demais casos.
		/// </summary>
		[XmlElement( ElementName = "verAplic",Order = 2 )]
		public string VersaoAplicacao
		{
			get; set;
		}
		/// <summary>
		/// Código do status da	resposta
		/// </summary>
		[XmlElement( ElementName = "cStat",Order = 3 )]
		public string Status
		{
			get; set;
		}
		/// <summary>
		/// Descrição do Status da resposta
		/// XMotivo trás a mensagem do erro ocorrido.
		/// Em CStat leio o valor do erro.
		/// Os valores para Consulta Cadastro do Contribuinte 102 - inutlização OK.
		///	
		/// </summary>
		[XmlElement( ElementName = "xMotivo",Order = 4 )]
		public string XMotivo
		{
			get
			{
				return _xmotivo;
			}
			set
			{
				if( _xmotivo != value )
				{
					_xmotivo = value;

					switch( Status )
					{
						case "102":
						{
						}
						break;
						default:
						{
							throw new NFeException( "cStat= " + Status + "\r\nXMotivo= " + XMotivo );
						}
					}
				}
			}
		}

		/// <summary>
		/// Serviço solicitado ‘INUTILIZAR’
		/// </summary>
		[XmlElement( ElementName = "xServ",Order = 5 )]
		public string NomeServico
		{
			get;set;
		}

		/// <summary>
		/// Código da UF que atendeu a solicitação. (35=São Paulo)
		/// </summary>
		[XmlElement( ElementName = "cUF",Order = 6 )]
		public string CodigoEstado
		{
			get; set;
		}
		/// <summary>
		/// Ano de inutilização da numeração
		/// </summary>
		[XmlElement( ElementName = "ano",Order = 7 )]
		public string Ano
		{
			get; set;
		}
		/// <summary>
		/// CNPJ do emitente
		/// </summary>
		[XmlElement( ElementName = "CNPJ",Order = 8 )]
		public string CNPJ
		{
			get; set;
		}
		/// <summary>
		/// Modelo do documento (55 ou 65)
		/// </summary>
		[XmlElement( ElementName = "mod",Order = 9 )]
		public string Modelo
		{
			get; set;
		}
		/// <summary>
		/// Série da NF-e
		/// </summary>
		[XmlElement( ElementName = "serie",Order = 10 )]
		public int Serie
		{
			get; set;
		}
		/// <summary>
		/// Número da NF-e inicial a ser inutilizada
		/// </summary>
		[XmlElement( ElementName = "nNFIni",Order = 11 )]
		public int NumeroInicial
		{
			get; set;
		}
		/// <summary>
		/// Número da NF-e final a ser inutilizada
		/// </summary>
		[XmlElement( ElementName = "nNFFin",Order = 12 )]
		public int NumeroFinal
		{
			get; set;
		}

		/// <summary>
		/// Preenchido com a data e hora do processamento (informado também no caso de rejeição).
		/// Formato: “AAAA-MM-DDThh:mm:ssTZD” (UTC -Universal Coordinated Time).
		/// </summary>
		[XmlElement( ElementName = "dhRecbto",Order = 13 )]
		public string DataRecebimento
		{
			get; set;
		}

		/// <summary>
		/// Informar a justificativa do pedido de inutilização
		/// </summary>
		[StringLength( 255,MinimumLength = 15,ErrorMessage = "Este campo tem o limite de 44 caracteres" )]
		[XmlElement( ElementName = "xJust",Order = 14 )]
		public string Justificativa
		{
			get
			{
				return _justificativa.RetiraAcento();
			}
			set
			{
				if( _justificativa != value )
				{
					_justificativa = value;
				}
			}
		}

		/// <summary>
		/// Número do Protocolo de Inutilização (vide item 5.8 no manual da NFe).
		/// </summary>
		[XmlElement( ElementName = "nProt",Order = 15 )]
		public string NumeroProtocolo
		{
			get;
			set;
		}

		public InfInut( string ano,string cNPJ,string modelo,int serie,int numeroInicial,int numeroFinal,string justificativa )
		{
			Ano = ano ?? throw new ArgumentNullException( nameof( ano ) );
			CNPJ = cNPJ ?? throw new ArgumentNullException( nameof( cNPJ ) );
			Modelo = modelo ?? throw new ArgumentNullException( nameof( modelo ) );
			Serie = serie;
			NumeroInicial = numeroInicial;
			NumeroFinal = numeroFinal;
			Justificativa = justificativa;
		}

		public InfInut()
		{
		}
	}
}
