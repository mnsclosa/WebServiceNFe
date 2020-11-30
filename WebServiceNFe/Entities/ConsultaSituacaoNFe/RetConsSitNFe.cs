using ServiceNFe.Entities.Exceptions;
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace ServiceNFe.Entities.ConsultaSituacaoNFe
{
	[Serializable()]
	[XmlRoot( ElementName = "retConsSitNFe",Namespace = @"http://www.portalfiscal.inf.br/nfe" )]
	public class RetConsSitNFe : ConsSitNFe
	{
		private string _xmotivo;

		/// <summary>
		/// Versão do Aplicativo que processou a consulta.
		/// A versão deve ser iniciada com a sigla da UF nos casos de WS próprio ou a sigla SVAN ou SVRS nos demais casos.
		/// </summary>
		[XmlElement( ElementName = "verAplic",Order = 5 )]
		public string VerAplic
		{
			get; set;
		}

		/// <summary>
		/// Código do status da resposta.
		/// </summary>
		[XmlElement( ElementName = "cStat",Order = 6 )]
		public string CStat
		{
			get; set;
		}

		/// <summary>
		/// Descrição literal do status da resposta.
		/// 
		/// XMotivo trás a mensagem do erro ocorrido.
		/// Em CStat leio o valor do erro.
		/// Os valores para Consulta Cadastro do Contribuinte 100 - 100-Autorizado o Uso.
		///													  101 - Cancelamento de NF-e Homologado,
		///													  110 - Uso Denegado.
		///													  150 - Uso	autorizado fora de prazo
		///													  151 - Cancelado fora de prazo.
		///	
		/// </summary>
		
		[StringLength( 255,MinimumLength = 1,ErrorMessage = "Este campo tem o limite de 255 caracteres" )]
		[XmlElement( ElementName = "xMotivo",Order = 7 )]
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
						case "100":
						case "101":
						case "110":
						case "150":
						case "151":
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
		/// Código da UF que atendeu a solicitação. (35=São Paulo)
		/// </summary>
		[XmlElement( ElementName = "cUF",Order = 8 )]
		public string CodigoEstado
		{
			get; set;
		}

		/// <summary>
		/// Preenchido com a data e hora do processamento.
		/// Formato: “AAAA-MM-DDThh:mm:ssTZD” (UTC - Universal Coordinated Time).
		/// </summary>
		[XmlElement( ElementName = "dhRecbto",Order = 9 )]
		public string DhRecbto
		{
			get; set;
		}

		/*
		 * O campo ChNFe esta na classe herdada.
		 */

		/// <summary>
		/// Protocolo de autorização ou denegação de uso do	NF-e( vide item 4.2.2). Informar se localizada uma NF-e com 
		///	cStat = 100-uso autorizado, 150-uso autorizado fora de prazo ou 110-uso denegado.( NT 2012/003)
		/// </summary>
		[XmlElement( ElementName = "protNFe",Order = 11 )]
		public string ProtNFe
		{
			get; set;
		}

		/// <summary>
		/// Protocolo de homologação de cancelamento de	NF-e( vide item 4.3.2). Informar se localizada uma NF-e com 
		/// cStat = 101-cancelado ou 151-cancelado fora de prazo. ( NT 2012/003)
		/// </summary>
		[XmlElement( ElementName = "retCancNFe",Order = 12 )]
		public string RetCancNFe
		{
			get; set;
		}

		/// <summary>
		/// Informação do evento e respectivo Protocolo de	registro de Evento
		/// </summary>
		[XmlElement( ElementName = "procEventoNFe",Order = 13 )]
		public string ProcEventoNFe
		{
			get; set;
		}
	}
}
