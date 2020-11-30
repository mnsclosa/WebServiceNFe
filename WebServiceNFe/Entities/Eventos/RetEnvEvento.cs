using ServiceNFe.Entities.Exceptions;
using System;
using System.Xml.Serialization;

namespace ServiceNFe.Entities.Eventos
{
	[Serializable()]
	[XmlRoot( ElementName = "retEnvEvento"/*,Namespace = @"http://www.portalfiscal.inf.br/nfe"*/ )]
	public class RetEnvEvento
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
		/// Identificador de controle do Lote de envio do Evento. Número sequencial autoincremental único para
		/// identificação do Lote. A responsabilidade de gerar e controlar é exclusiva do autor do evento.
		/// O Web Service não faz qualquer uso deste identificador.
		/// </summary>
		[XmlElement( ElementName = "idLote",Order = 3 )]
		public string IdLote
		{
			get; set;
		}

		/// <summary>
		/// Identificação do Ambiente:1 – Produção;2 - Homologação
		/// </summary>
		[XmlElement( ElementName = "tpAmb",Order = 4 )]
		public string Tipo_deAmbiente
		{
			get; set;
		}

		/// <summary>
		/// Versão da aplicação que processou o evento.
		/// </summary>
		[XmlElement( ElementName = "verAplic",Order = 5 )]
		public string Versao_Aplicacao
		{
			get; set;
		}

		/// <summary>
		/// Código do órgão de recepção do Evento. Utilizar	a Tabela do IBGE, utilizar 90 para identificar o Ambiente Nacional
		/// </summary>
		[XmlElement( ElementName = "cOrgao",Order = 6 )]
		public string Corgao
		{
			get; set;
		}

		/// <summary>
		/// Código do status da resposta.
		/// </summary>
		[XmlElement( ElementName = "cStat",Order = 7 )]
		public string CStat
		{
			get; set;
		}

		/// <summary>
		/// Descrição literal do status da resposta.
		/// 
		/// XMotivo trás a mensagem do erro ocorrido.
		/// Em CStat leio o valor do erro.
		/// Os valores para retorno de evento 128 - Lote de Evento Processado
		///	
		/// </summary>
		[XmlElement( ElementName = "xMotivo",Order = 8 )]
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
						case "128":
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

		[XmlElement( ElementName = "retEvento",Order = 9 )]
		public RetEvento retevento
		{
			get;set;
		}

		public RetEnvEvento()
		{
		}
	}
}
