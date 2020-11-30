using ServiceNFe.Enums;
using ServiceNFe.Servicos;
using System;
using System.Xml.Serialization;

namespace ServiceNFe.Entities.ConsultaStatusServico
{
	[Serializable()]
	[XmlRoot( ElementName = "consStatServ",Namespace = @"http://www.portalfiscal.inf.br/nfe" )]

	public class ConsStatServ
	{
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
		[XmlElement( ElementName = "tpAmb",Order = 2 )]
		public int TipodeAmbiente
		{
			get; set;
		}

		/// <summary>
		/// Código da UF consultada
		/// </summary>
		[XmlElement( ElementName = "cUF",Order = 6 )]
		public string CodigoEstado
		{
			get; set;
		}

		/// <summary>
		/// Serviço solicitado ‘STATUS’
		/// </summary>
		[XmlElement( ElementName = "xServ",Order = 11 )]
		public string NomeServico
		{
			get;set;
		}

		public ConsStatServ()
		{
		}

		public ConsStatServ( string _versao )
		{
			versao = _versao;
		}
	}
}
