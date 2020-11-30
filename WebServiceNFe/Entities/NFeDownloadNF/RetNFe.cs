using System;
using System.Xml.Serialization;

namespace ServiceNFe.Entities.NFeDownloadNF
{
	[Serializable()]
	[XmlRoot( ElementName = "retNFe" )]
	public class RetNFe
	{
		/// <summary>
		/// Chave de Acesso da NF-e consultada.
		/// </summary>
		//		[MaxLength
		[XmlElement( ElementName = "chNFe",Order = 9 )]
		public string ChaveNFe
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
		/// Código do status da resposta (vide item 5) do manual do Sefaz
		/// </summary>
		[XmlElement( ElementName = "xMotivo",Order = 5 )]
		public string XMotivo
		{
			get;set;
		}

		/// <summary>
		/// Estrutura “procNFe”, compactado no padrão gZip, o tipo do campo é base64Binary.
		/// </summary>
		[XmlElement( ElementName = "procNFeZip",Order = 5 )]
		public string ProcNFeZip
		{
			get; set;
		}

		/// <summary>
		/// Estrutura “procNFe”, compactado no padrão gZip, o tipo do campo é base64Binary.
		/// </summary>
		[XmlElement( ElementName = "schema",Order = 5 )]
		public string Schema
		{
			get; set;
		}
	}
}
