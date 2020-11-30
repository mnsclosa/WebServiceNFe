using System;
using System.Xml.Serialization;

/*
 * Como a classe Evento tem somente a versão em vez de criar um fonte para ele resolvi criar aqui dentro.
 * 
 */

namespace ServiceNFe.Entities.Eventos
{
	[Serializable()]
	[XmlRoot( ElementName = "envEvento",Namespace = @"http://www.portalfiscal.inf.br/nfe" )]
	public class EnvEvento
	{
		/// <summary>
		/// Versão do leiaute
		/// </summary>
		[XmlAttribute]
		public string versao
		{
			get; set;
		}

		/// <summary>
		/// Identificador de controle do Lote de envio do Evento. Número sequencial autoincremental único para
		/// identificação do Lote.A responsabilidade de gerar e controlar é exclusiva do autor do evento.
		/// O Web Service não faz qualquer uso deste identificador.
		/// </summary>
	
		[XmlElement( ElementName = "idLote",Order = 2 )]
		public string IdLote
		{
			get; set;
		}

		[XmlElement( ElementName = "evento",Order = 3 )]
		public Evento evento
		{
			get;set;
		}

		public EnvEvento()
		{
		}

		public EnvEvento( string _versao,string idLote )
		{
			versao = _versao ?? throw new ArgumentNullException( nameof( _versao ) );
			IdLote = idLote ?? throw new ArgumentNullException( nameof( idLote ) );
		}

		public EnvEvento( string _versao,string idLote,Evento _evento )
		{
			versao = _versao ?? throw new ArgumentNullException( nameof( _versao ) );
			IdLote = idLote;
			evento = _evento ?? throw new ArgumentNullException( nameof( _evento ) );
		}
	}
}
