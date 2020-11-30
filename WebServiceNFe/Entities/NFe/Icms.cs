using System;
using System.Xml.Serialization;

namespace ServiceNFe.Entities.NFe
{
	[Serializable()]
	[XmlRoot( ElementName = "ICMS" )]
	public class Icms
	{
		[XmlElement( ElementName = "ICMS00",Order = 1 )]
		public Icms00 icms00
		{
			get;set;
		}

		[XmlElement( ElementName = "ICMS10",Order = 2 )]
		public Icms10 icms10
		{
			get;set;
		}

		public Icms()
		{
		}

		public Icms( Icms00 _icms00 )
		{
			icms00 = _icms00;
		}

		public Icms( Icms10 _icms10 )
		{
			icms10 = _icms10;
		}
	}
}
