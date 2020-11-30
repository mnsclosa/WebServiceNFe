using System;
using System.Xml.Serialization;

namespace ServiceNFe.Entities.NFe
{
	[Serializable()]
	[XmlRoot( ElementName = "det" )]
	public class Det
	{
		static int _nitem = 1;

		/// <summary>
		/// Faz a indicação de quantros itens ha na NFe.
		/// </summary>
		[XmlAttribute]
		public int nItem
		{
			get
			{
				return _nitem++;
			}
			set
			{
				if( _nitem != value )
					_nitem = value;
			}
		}

		[XmlElement( ElementName = "prod",Order = 2 )]
		public Prod prod
		{
			get;set;
		}

		[XmlElement( ElementName = "imposto",Order = 3 )]
		public Imposto imposto
		{
			get;set;
		}

		public Det()
		{
		}

		public Det( Prod _prod,Imposto _imposto )
		{
			prod = _prod ?? throw new ArgumentNullException( nameof( _prod ) );
			imposto = _imposto ?? throw new ArgumentNullException( nameof( _imposto ) );
		}
	}
}
