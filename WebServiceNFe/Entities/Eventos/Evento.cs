using System;
using System.Xml.Serialization;

namespace ServiceNFe.Entities.Eventos
{
	[Serializable()]
	[XmlRoot( ElementName = "evento",Namespace = @"http://www.portalfiscal.inf.br/nfe" )]
	public class Evento
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
		public InfEvento infEvento
		{
			get;set;
		}

		public Evento()
		{
		}

		public Evento( string _versao,InfEvento _infEvento )
		{
			versao = _versao ?? throw new ArgumentNullException( nameof( _versao ) );
			infEvento = _infEvento;
			infEvento = _infEvento;
		}
	}

}
