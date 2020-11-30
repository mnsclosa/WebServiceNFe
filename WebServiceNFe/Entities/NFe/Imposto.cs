using System;
using System.Xml.Serialization;

namespace ServiceNFe.Entities.NFe
{
	[Serializable()]
	[XmlRoot( ElementName = "imposto" )]
	public class Imposto
	{
		/// <summary>
		/// Valor aproximado total de tributos federais,estaduais e municipais.
		/// Grupo ISSQN mutuamente exclusivo com os grupos ICMS e II, isto é, se o grupo ISSQN for informado os grupos ICMS e II não
		/// serão informados e vice-versa
		/// </summary>
		[XmlElement( ElementName = "vTotTrib",Order = 1 )]
		public decimal Valor_TotalTributo
		{
			get; set;
		}

		[XmlElement( ElementName = "ICMS",Order = 2 )]
		public Icms icms
		{
			get;set;
		}

		[XmlElement( ElementName = "PIS",Order = 3 )]
		public Pis pis
		{
			get;set;
		}

		[XmlElement( ElementName = "COFINS",Order = 4 )]
		public Cofins cofins
		{
			get;set;
		}

		public Imposto()
		{
		}

		public Imposto( decimal valor_TotalTributo,Icms _icms,Pis _pis,Cofins _cofins )
		{
			Valor_TotalTributo = valor_TotalTributo;
			icms = _icms ?? throw new ArgumentNullException( nameof( _icms ) );
			pis = _pis ?? throw new ArgumentNullException( nameof( _pis ) );
			cofins = _cofins ?? throw new ArgumentNullException( nameof( _cofins ) );
		}
	}
}
