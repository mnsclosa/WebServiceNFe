using ServiceNFe.Entities.Exceptions;
using System;
using System.Xml.Serialization;

namespace ServiceNFe.Entities.NFe
{
	[Serializable()]
	[XmlRoot( ElementName = "protNFe" )]
	public class ProtNFe
	{
		/// <summary>
		/// Versão do leiaute
		/// </summary>
		[XmlAttribute]
		public string versao
		{
			get; set;
		}

		[XmlElement( ElementName = "infProt",Order = 1 )]
		public InfProt infProt
		{
			get;set;
		}

		/// <summary>
		/// Construtor para a Seriualização.
		/// </summary>
		public ProtNFe()
		{
		}
	}
}
