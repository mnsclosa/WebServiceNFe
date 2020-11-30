using ServiceNFe.Entities.Exceptions;
using System;
using System.Xml.Serialization;

namespace ServiceNFe.Entities.ConsultaStatusServico
{
	[Serializable()]
	[XmlRoot( ElementName = "retConsStatServ",Namespace = @"http://www.portalfiscal.inf.br/nfe" )]
	public class RetConsStatServ : ConsStatServ
	{
		private string _xmotivo;

		/*
		 * A Order = 1,versao e Order = 2,tpAmb estão no ConsStatServ.cs
		 * 
		 */

		/// <summary>
		/// Versão do Aplicativo que processou a consulta.
		/// A versão deve ser iniciada com a sigla da UF nos casos de WS próprio ou a sigla SVAN ou SVRS nos demais casos.
		/// </summary>
		[XmlElement( ElementName = "verAplic",Order = 3 )]
		public string VerAplic
		{
			get; set;
		}

		/// <summary>
		/// Código do status da resposta.
		/// </summary>
		[XmlElement( ElementName = "cStat",Order = 4 )]
		public string CStat
		{
			get;set;
		}
		/// <summary>
		/// Descrição literal do status da resposta.
		/// 
		/// XMotivo trás a mensagem do erro ocorrido.
		/// Em CStat leio o valor do erro.
		/// Os valores para Consulta Cadastro do Contribuinte 107 - Serviço em Operação.
		///													  108 - Serviço Paralisado Temporariamente,
		///													  109 -	Serviço Paralisado sem Previsão
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
						case "107":
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

		/*
		 * A Order = 6, cUF esta no ConsStatServ.cs
		 * 
		 */


		/// <summary>
		/// Preenchido com a data e hora do processamento.
		/// Formato: “AAAA-MM-DDThh:mm:ssTZD” (UTC - Universal Coordinated Time).
		/// </summary>
		[XmlElement( ElementName = "dhRecbto",Order = 7 )]
		public string DhRecbto
		{
			get; set;
		}
		/// <summary>
		/// Tempo médio de resposta do serviço (em segundos) dos últimos 5 minutos( item 5.7 do amnual)
		/// </summary>
		[XmlElement( ElementName = "tMed",Order = 8 )]
		public string TMed
		{
			get; set;
		}

		/// <summary>
		/// Preencher com data e hora previstas para o	retorno do Web Service, no formato AAA-MMDDTHH:MM:SS
		/// </summary>
		[XmlElement( ElementName = "dhRetorno",Order = 9 )]
		public string DhRetorno
		{
			get; set;
		}

		/// <summary>
		/// Informações adicionais para o Contribuinte
		/// </summary>
		[XmlElement( ElementName = "xObs",Order = 10 )]
		public string XObs
		{
			get; set;
		}
	}
}
