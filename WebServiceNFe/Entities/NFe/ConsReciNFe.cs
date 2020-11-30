using System;
using System.Xml.Serialization;

namespace ServiceNFe.Entities.NFe
{
	[Serializable()]
	[XmlRoot( ElementName = "consReciNFe",Namespace = @"http://www.portalfiscal.inf.br/nfe" )]
	public class ConsReciNFe
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
		[XmlElement( ElementName = "tpAmb",Order = 1 )]
		public int Tipo_deAmbiente
		{
			get; set;
		}

		/// <summary>
		/// Número do Recibo gerado pelo Portal da Secretaria de Fazenda Estadual( vide item 5.5).
		/// </summary>
		[XmlElement( ElementName = "nRec",Order = 2 )]
		public string Numero_Recibo
		{
			get; set;
		}

		/// <summary>
		/// Construtor para a Serialização
		/// </summary>
		public ConsReciNFe()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="versao">Versão do layout da NFe</param>
		/// <param name="numero_Recibo">Número do recibo da NFe emitida</param>
		public ConsReciNFe( string _versao,string numero_Recibo )
		{
			versao = _versao ?? throw new ArgumentNullException( nameof( _versao ) );
			Numero_Recibo = numero_Recibo ?? throw new ArgumentNullException( nameof( numero_Recibo ) );
		}
	}
}
