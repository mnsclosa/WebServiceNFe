using System;
using System.Xml.Serialization;
using static ServiceNFe.Entities.Constantes;

namespace ServiceNFe.Entities.NFe
{
	[Serializable()]
	[XmlRoot( ElementName = "fat" )]
	public class Fat
	{
		private decimal _valororiginal;
		private decimal _valordesconto;
		private decimal _valorliquidofatura;

		/// <summary>
		/// Número da Fatura
		/// </summary>
		[XmlElement( ElementName = "nFat",Order = 1 )]
		public string Numero_Fatura
		{
			get; set;
		}

		/// <summary>
		/// Valor Original da Fatura
		/// </summary>
		[XmlElement( ElementName = "vOrig",Order = 2 )]
		public decimal Valor_Original
		{
			get
			{
				return _valororiginal.Round( DecimalValorTotal );
			}
			set
			{
				if( _valororiginal != value )
					_valororiginal = value;
			}
		}

		/// <summary>
		/// Valor do desconto
		/// </summary>
		[XmlElement( ElementName = "vDesc",Order = 3 )]
		public decimal Valor_Desconto
		{
			get
			{
				return _valordesconto.Round( DecimalValorTotal );
			}
			set
			{
				if( _valordesconto != value )
					_valordesconto = value;
			}
		}

		/// <summary>
		/// Valor Líquido da Fatura
		/// </summary>
		[XmlElement( ElementName = "vLiq",Order = 4 )]
		public decimal Valor_LiquidoFatura
		{
			get
			{
				return _valorliquidofatura.Round( DecimalValorTotal );
			}
			set
			{
				if( _valorliquidofatura != value )
					_valorliquidofatura = value;
			}
		}

		/// <summary>
		/// Construtor padrão para a serialização.
		/// </summary>
		public Fat()
		{
		}

		/// <summary>
		/// Grupo Fatura
		/// </summary>
		/// <param name="numero_Fatura">Número da Fatura</param>
		/// <param name="valor_Original">Valor Original da Fatura</param>
		/// <param name="valor_Desconto">Valor do desconto</param>
		/// <param name="valor_LiquidoFatura">Valor Líquido da Fatura</param>
		public Fat( string numero_Fatura,decimal valor_Original,decimal valor_Desconto,decimal valor_LiquidoFatura )
		{
			Numero_Fatura = numero_Fatura ?? throw new ArgumentNullException( nameof( numero_Fatura ) );
			Valor_Original = valor_Original;
			Valor_Desconto = valor_Desconto;
			Valor_LiquidoFatura = valor_LiquidoFatura;
		}
	}
}
