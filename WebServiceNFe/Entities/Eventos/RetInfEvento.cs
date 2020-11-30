using ServiceNFe.Entities.Exceptions;
using System;
using System.Xml.Serialization;

namespace ServiceNFe.Entities.Eventos
{
	[Serializable()]
	[XmlRoot( ElementName = "infEvento" )]
	public class RetInfEvento
	{
		private string _xmotivo;

		/// <summary>
		/// Identificador da TAG a ser assinada, a regra de	formação do Id é: “ID” + tpEvento + chave da NF-e + nSeqEvento
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
		public string TipodeAmbiente
		{
			get; set;
		}

		/// <summary>
		/// Versão da aplicação que processou o evento.
		/// </summary>
		[XmlElement( ElementName = "verAplic",Order = 2 )]
		public string VerAplic
		{
			get; set;
		}

		/// <summary>
		/// Código do órgão de recepção do Evento. Utilizar	a Tabela do IBGE, utilizar 90 para identificar o Ambiente Nacional
		/// </summary>
		[XmlElement( ElementName = "cOrgao",Order = 3 )]
		public string Corgao
		{
			get; set;
		}

		/// <summary>
		/// Código do status da resposta.
		/// </summary>
		[XmlElement( ElementName = "cStat",Order = 4 )]
		public string CStat
		{
			get; set;
		}
		/// <summary>
		/// Descrição literal do status da resposta.
		/// 
		/// XMotivo trás a mensagem do erro ocorrido.
		/// Em CStat leio o valor do erro.
		/// Os valores para Consulta Cadastro do Contribuinte 135 - Recebido pelo Sistema de Registro de Eventos, com vinculação do evento na NFe
		///	
		/// </summary>
		[XmlElement( ElementName = "xMotivo",Order = 5 )]
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

					switch( CStat )
					{
						case "135":
						{
						}
						break;
						default:
						{
							throw new NFeException( "cStat= " + CStat + "\r\nMotivo= " + XMotivo );
						}
					}
				}
			}
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
		/// Código do de evento = 110110 carta de correção e 110111 cancelamneto de NFe
		/// </summary>
		[XmlElement( ElementName = "tpEvento",Order = 7 )]
		public string TpEvento
		{
			get; set;
		}

		/// <summary>
		/// Descrição do Evento – “Carta de Correção registrada”
		/// </summary>
		[XmlElement( ElementName = "xEvento",Order = 8 )]
		public string Xevento
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
		/// Informar o CNPJ ou o CPF do autor do Evento
		/// </summary>

		/// <summary>
		/// CNPJ do contribuinte/Consultado
		/// </summary>
		[XmlElement( ElementName = "CNPJDest",Order = 10 )]
		public string CNPJDest
		{
			get; set;
		}

		[XmlElement( ElementName = "CPFDest",Order = 11 )]
		public string CPFDest
		{
			get; set;
		}

		/// <summary>
		/// email do destinatário informado na NF-e.
		/// </summary>
		[XmlElement( ElementName = "emailDest",Order = 12 )]
		public string EmailDest
		{
			get; set;
		}
		/// <summary>
		/// Data e hora do evento no formato AAAA-MMDDThh:mm:ssTZD (UTC - Universal 	Coordinated Time, onde TZD pode ser -02:00
		/// (Fernando de Noronha), -03:00 (Brasília) ou - 04:00 (Manaus), no horário de verão serão - 01:00, -02:00 e -03:00. Ex.: 2010-08-
		/// 19T13:00:15-03:00
		/// </summary>
		[XmlElement( ElementName = "dhRegEvento",Order = 13 )]
		public string DhRegEvento
		{
			get;
			set;
		}

		/// <summary>
		/// Número do Protocolo da NF-e 1 posição( 1-Secretaria da Fazenda Estadual, 2-RFB ),
		///								2 posições para o código da UF,
		///								2 posições para o ano e 10 posições para o sequencial no ano.
		/// </summary>
		[XmlElement( ElementName = "nProt",Order = 14 )]
		public string Nprot
		{
			get; set;
		}
		public RetInfEvento()
		{
		}
	}
}
