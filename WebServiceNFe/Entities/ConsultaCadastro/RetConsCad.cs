using System;
using System.Xml.Serialization;

namespace ServiceNFe.Entities.ConsultaCadastro
{
	[Serializable()]
	[XmlRoot( ElementName = "retConsCad",Namespace = @"http://www.portalfiscal.inf.br/nfe" )]
	public class RetConsCad : ConsCad
	{
		public RetConsCad()
		{
		}

		public RetConsCad( string _versao ) : base( _versao )
		{
			versao = _versao;
		}
	}
}
