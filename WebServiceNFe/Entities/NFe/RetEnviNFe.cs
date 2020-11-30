using ServiceNFe.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ServiceNFe.Entities.NFe
{
	[Serializable()]
	[XmlRoot( ElementName = "retEnviNFe" )]
	public class RetEnviNFe
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
		public string Versao_Aplicacao
		{
			get; set;
		}

		/// <summary>
		/// Código do status da resposta.
		/// </summary>
		[XmlElement( ElementName = "cStat",Order = 3 )]
		public string CStat
		{
			get; set;
		}

		/// <summary>
		/// Descrição literal do status da resposta.
		/// 
		/// XMotivo trás a mensagem do erro ocorrido.
		/// Em CStat leio o valor do erro.
		/// O valor para retorno do evento 103 - Lote recebido com Sucesso
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

					switch( CStat )
					{
						case "103":
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
		[XmlElement( ElementName = "cUF",Order = 5 )]
		public string Codigo_Estado
		{
			get; set;
		}

		/// <summary>
		/// Preenchido com a data e hora do processamento (informado também no caso de rejeição).
		/// Formato: “AAAA-MM-DDThh:mm:ssTZD” (UTC - Universal Coordinated Time).
		/// </summary>
		[XmlElement( ElementName = "dhRecbto",Order = 6 )]
		public string DataHora_Recebimento
		{
			get; set;
		}

		[XmlElement( ElementName = "infRec",Order = 7 )]
		public InfRec infRec
		{
			get;set;
		}

		/// <summary>
		/// Dados do Protocolo de recebimento da NF-e gerado no caso do processamento síncrono do Lote de NF-e.
		/// Ver descrição do “protNFe” no item 4.2.2.
		/// </summary>
		[XmlElement( ElementName = "protNFe",Order = 8 )]
		public List<ProtNFe> L_protNFe
		{
			get; set;
		} = new List<ProtNFe>();

		public RetEnviNFe()
		{
		}
	}
}
