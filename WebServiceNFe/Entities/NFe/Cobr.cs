using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ServiceNFe.Entities.NFe
{
	[Serializable()]
	[XmlRoot( ElementName = "cobr" )]
	public class Cobr
	{
		[XmlElement( ElementName = "fat",Order = 1 )]
		public Fat fat
		{
			get; set;
		}

		[XmlElement( ElementName = "dup",Order = 2 )]
		public List<Dup> L_dup
		{
			get;
		} = new List<Dup>();

		public Cobr()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="fat"></param>
		/// <param name="_dup"></param>
		public Cobr( Fat fat,Dup _dup ) : this( _dup )
		{
			this.fat = fat ?? throw new ArgumentNullException( nameof( fat ) );
		}

		/// <summary>
		/// Insere um item na List da classe Dup
		/// </summary>
		/// <param name="_dup"></param>
		public Cobr( Dup _dup )
		{
			AddDup( _dup );
		}

		/// <summary>
		/// Insere um item na List da classe Dup
		/// </summary>
		/// <param name="_dup"></param>
		public void AddDup( Dup _dup )
		{
			L_dup.Add( _dup );
		}

	}
}
