using System;
using System.Xml.Serialization;

namespace ServiceNFe.Entities.NFe
{
	[Serializable()]
	[XmlRoot( ElementName = "pag" )]
	public class Pag
	{
		[XmlElement( ElementName = "detPag",Order = 1 )]
		public DetPag detPag
		{
			get;set;
		}

		/// <summary>
		/// Construtor para a Serialização
		/// </summary>
		public Pag()
		{
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="detPag"></param>
		public Pag( DetPag detPag )
		{
			this.detPag = detPag ?? throw new ArgumentNullException( nameof( detPag ) );
		}
	}
}
