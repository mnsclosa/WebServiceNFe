using System;
using System.Xml.Serialization;

namespace ServiceNFe.Entities.NFe
{
	[Serializable()]
	[XmlRoot( ElementName = "total" )]
	public class Total
	{
		[XmlElement( ElementName = "ICMSTot",Order = 1 )]
		public IcmsTot icmsTot
		{
			get;set;
		}

		public Total()
		{
		}

		public Total( IcmsTot _icmsTot )
		{
			icmsTot = _icmsTot ?? throw new ArgumentNullException( nameof( _icmsTot ) );
		}
	}
}
