using System;
using System.Xml.Serialization;

namespace ServiceNFe.Entities.NFe
{
	[Serializable()]
	[XmlRoot( ElementName = "PIS" )]
	public class Pis
	{
		[XmlElement( ElementName = "PISOutr",Order = 1 )]
		public PisOutr pisOutr
		{
			get;set;
		}

		public Pis()
		{
		}

		public Pis( PisOutr _pisOutr )
		{
			pisOutr = _pisOutr ?? throw new ArgumentNullException( nameof( _pisOutr ) );
		}
	}
}
