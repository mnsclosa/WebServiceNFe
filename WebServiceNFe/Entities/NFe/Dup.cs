using System;
using System.Globalization;
using System.Xml.Serialization;
using static ServiceNFe.Entities.Constantes;

namespace ServiceNFe.Entities.NFe
{
	[Serializable()]
	[XmlRoot( ElementName = "fat" )]
	public class Dup
	{
		private string _datavencimento;
		private decimal _valorduplicata;

		/// <summary>
		/// Número da Fatura
		/// </summary>
		[XmlElement( ElementName = "nDup",Order = 1 )]
		public string Numero_Duplicata
		{
			get; set;
		}

		/// <summary>
		/// Data de vencimento
		/// 
		/// Formato: “AAAA-MM-DD”
		/// </summary>
		[XmlElement( ElementName = "dVenc",Order = 2 )]
		public string Data_Vencimento
		{
			get
			{
				return DateTime.Now.ToString( new CultureInfo( "pt-BR" ) ).DataAAAAMMDD();
			}
			set
			{
				if( _datavencimento != value )
					_datavencimento = value;
			}
		}

		/// <summary>
		/// Valor da duplicata
		/// </summary>
		[XmlElement( ElementName = "vDup",Order = 3 )]
		public decimal Valor_Duplicata
		{
			get
			{
				return _valorduplicata.Round( DecimalValorTotal );
			}
			set
			{
				if( _valorduplicata != value )
					_valorduplicata = value;
			}
		}

		/// <summary>
		/// Construtor padrão para a serialização.
		/// </summary>
		public Dup()
		{
		}

		/// <summary>
		/// Grupo Duplicata
		/// </summary>
		/// <param name="numero_Duplicata">Número da Duplicata</param>
		/// <param name="data_Vencimento">Data de vencimento,Formato: “AAAA-MM-DD”
		///	O formato será gerado automáticamente.</param>
		/// <param name="valor_Duplicata"></param>
		public Dup( string numero_Duplicata,string data_Vencimento,decimal valor_Duplicata )
		{
			Numero_Duplicata = numero_Duplicata ?? throw new ArgumentNullException( nameof( numero_Duplicata ) );
			Data_Vencimento = data_Vencimento ?? throw new ArgumentNullException( nameof( data_Vencimento ) );
			Valor_Duplicata = valor_Duplicata;
		}
	}
}
