using ServiceNFe.Servicos;
using System;
using System.Xml.Serialization;

namespace ServiceNFe.Entities.InutilizacaoNumeracao
{
	[Serializable()]
	[XmlRoot( ElementName = "inutNFe",Namespace = @"http://www.portalfiscal.inf.br/nfe" )]
	public class InutNFe
	{
		[XmlAttribute]
		public string versao
		{
			get; set;
		}

		public InutNFe()
		{
		}

		public InutNFe( string _versao )
		{
			versao = _versao;
		}

		public InutNFe( InfInut _infInut,string _versao ) : this( _versao )
		{
			infInut = _infInut;
		}

		[XmlElement( ElementName = "infInut",Order = 2 )]
		public InfInut infInut
		{
			get;set;
		}
	}
}
