using System;
using System.Xml.Serialization;

namespace ServiceNFe.Entities.NFe
{
	[Serializable()]
	[XmlRoot( ElementName = "COFINS" )]
	public class Cofins
	{
		[XmlElement( ElementName = "COFINSOutr",Order = 1 )]
		public CofinsOutr cofinsOutr
		{
			get;set;
		}

		public Cofins()
		{
		}

		public Cofins( CofinsOutr _cofinsOutr )
		{
			cofinsOutr = _cofinsOutr ?? throw new ArgumentNullException( nameof( _cofinsOutr ) );
		}
	}
}
