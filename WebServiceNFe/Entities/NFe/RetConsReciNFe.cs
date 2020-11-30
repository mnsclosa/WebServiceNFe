using ServiceNFe.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ServiceNFe.Entities.NFe
{
	[Serializable()]
	[XmlRoot( ElementName = "retConsReciNFe" )]
	public class RetConsReciNFe
	{
		private string _xmotivo;

		/// <summary>
		/// Versão do leiaute
		/// </summary>
		[XmlAttribute]
		public string versao
		{
			get; set;
		}

		/// <summary>
		/// Identificação do Ambiente:1 – Produção;2 - Homologação
		/// </summary>
		[XmlElement( ElementName = "tpAmb",Order = 1 )]
		public int Tipo_deAmbiente
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
		/// Número do Recibo gerado pelo Portal da Secretaria de Fazenda Estadual( vide item 5.5).
		/// </summary>
		[XmlElement( ElementName = "nRec",Order = 3 )]
		public string Numero_Recibo
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
		/// O valor para retorno do evento 104 - Lote processado
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
						case "104":
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
		/// Código da UF que atendeu a solicitação.
		/// </summary>
		[XmlElement( ElementName = "cUF",Order = 6 )]
		public string Codigo_Estado
		{
			get; set;
		}

		/// <summary>
		/// Preenchido com a data e hora do processamento (informado também no caso de rejeição).
		/// Formato: “AAAA-MM-DDThh:mm:ssTZD” (UTC - Universal Coordinated Time).
		/// </summary>
		[XmlElement( ElementName = "dhRecbto",Order = 7 )]
		public string DataHora_Recebimento
		{
			get; set;
		}

		/// <summary>
		/// Código da Mensagem (v2.0) Campo de uso da SEFAZ para enviar mensagem de interesse da SEFAZ para o emissor. (NT 2011/004)
		/// </summary>
		[XmlElement( ElementName = "cMsg ",Order = 8 )]
		public string Codigo_Mensagem
		{
			get; set;
		}

		/// <summary>
		/// Código da Mensagem (v2.0) Campo de uso da SEFAZ para enviar mensagem de interesse da SEFAZ para o emissor. (NT 2011/004)
		/// </summary>
		[XmlElement( ElementName = "xMsg ",Order = 9 )]
		public string Descricao_Mensagem
		{
			get; set;
		}

		[XmlElement( ElementName = "protNFe",Order = 10 )]
		public List<ProtNFe> L_protNFe
		{
			get; set;
		} = new List<ProtNFe>();

		/// <summary>
		/// Construtor para a Serialização
		/// </summary>
		public RetConsReciNFe()
		{
		}
	}
}
