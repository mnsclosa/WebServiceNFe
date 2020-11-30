using System;
using System.Xml.Serialization;

namespace ServiceNFe.Entities.InutilizacaoNumeracao
{
	[Serializable()]
	[XmlRoot( ElementName = "retInutNFe",Namespace = @"http://www.portalfiscal.inf.br/nfe" )]
	public class RetInutNFe : InutNFe
	{
		public RetInutNFe( string _versao ) : base( _versao )
		{
			versao = _versao;
		}

		public RetInutNFe()
		{
		}
	}
}
