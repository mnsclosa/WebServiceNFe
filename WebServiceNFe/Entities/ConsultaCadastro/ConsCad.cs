using System;
using System.Xml.Serialization;

namespace ServiceNFe.Entities.ConsultaCadastro
{
	[Serializable()]
	[XmlRoot( ElementName = "ConsCad",Namespace = @"http://www.portalfiscal.inf.br/nfe" )]
	public class ConsCad
	{
		/// <summary>
		/// Versão do leiaute
		/// </summary>
		[XmlAttribute]
		public string versao
		{
			get; set;
		}
		public ConsCad()
		{
		}

		public ConsCad( string _versao )
		{
			versao = _versao;
		}

		public ConsCad( InfCons _infCons,string versao )
			:this ( versao )
		{
			infCons = _infCons;
		}

		[XmlElement( ElementName = "infCons",Order = 2 )]
		public InfCons infCons
		{
			get;set;
		}
	}
}
