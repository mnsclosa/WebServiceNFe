using System;
using System.Xml.Serialization;

namespace ServiceNFe.Entities.NFe
{
	[Serializable()]
	[XmlRoot( ElementName = "NFe",Namespace = @"http://www.portalfiscal.inf.br/nfe" )]

	public class NFe
	{
		[XmlElement( ElementName = "infNFe",Order = 1 )]
		public InfNFe infNFe
		{
			get;set;
		}

		public NFe()
		{
		}

		public NFe( InfNFe _infNFe )
		{
			infNFe = _infNFe;
		}
	}
}
