using System;
using System.Xml.Serialization;

namespace ServiceNFe.Entities.Eventos
{
	[Serializable()]
	[XmlRoot( ElementName = "retEvento" )]
	public class RetEvento
	{
		/// <summary>
		/// Versão do leiaute
		/// </summary>
		[XmlAttribute]
		public string versao
		{
			get; set;
		}

		[XmlElement( ElementName = "infEvento",Order = 2 )]
		public RetInfEvento infEvento
		{
			get;set;
		}

		public RetEvento()
		{
		}
	}

}
