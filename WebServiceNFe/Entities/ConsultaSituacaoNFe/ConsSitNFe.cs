using ServiceNFe.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace ServiceNFe.Entities.ConsultaSituacaoNFe
{
	[Serializable()]
	[XmlRoot( ElementName = "consSitNFe",Namespace = @"http://www.portalfiscal.inf.br/nfe" )]
	public class ConsSitNFe
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
		/// Serviço solicitado ‘CONSULTAR’
		/// </summary>
		[XmlElement( ElementName = "xServ",Order = 3 )]
		public string NomeServico
		{
			get;set;
		}
		/// <summary>
		/// Chave de Acesso da NF-e consultada.
		/// </summary>
		//		[MaxLength
		[StringLength(44, MinimumLength = 44, ErrorMessage = "Este campo tem o limite de 44 caracteres")]
		[XmlElement( ElementName = "chNFe",Order = 10 )]
		public string ChaveNFe
		{
			get; set;
		}

		public ConsSitNFe()
		{
		}

		public ConsSitNFe( string _versao,string chaveNFe )
		{
			versao = _versao ?? throw new ArgumentNullException( nameof( _versao ) );
			ChaveNFe = chaveNFe ?? throw new ArgumentNullException( nameof( chaveNFe ) );
		}
	}
}
