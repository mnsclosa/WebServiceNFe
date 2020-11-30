using ServiceNFe.Enums;
using System.Xml.Serialization;
using static ServiceNFe.Entities.Constantes;
using System;

namespace ServiceNFe.Entities.NFe
{
	public class IcmsBase
	{
		private decimal _valorbasecalculoicms;
		private decimal _aliquotaimpostoicms;
		private decimal _valoricms;

		/// <summary>
		/// 0 - Nacional, exceto as indicadas nos códigos 3, 4, 5 e 8;
		/// 1 - Estrangeira - Importação direta, exceto a indicada no código 6;
		/// 2 - Estrangeira - Adquirida no mercado interno, exceto a indicada no código 7;
		/// 3 - Nacional, mercadoria ou bem com Conteúdo de Importação superior a 40% e inferior ou igual a 70%;
		/// 4 - Nacional, cuja produção tenha sido feita em conformidade com os processos produtivos básicos de que tratam as
		///		legislações citadas nos Ajustes;
		/// 5 - Nacional, mercadoria ou bem com Conteúdo de Importação inferior ou igual a 40%;
		/// 6 - Estrangeira - Importação direta, sem similar nacional, constante em lista da CAMEX e gás natural;
		/// 7 - Estrangeira - Adquirida no mercado interno, sem similar nacional, constante lista CAMEX e gás natural.
		/// 8 - Nacional, mercadoria ou bem com Conteúdo de Importação superior a 70%;
		/// </summary>
		[XmlElement( ElementName = "orig",Order = 1 )]
		public int Origem_Mercadoria
		{
			get; set;
		}

		/// <summary>
		/// 00=Tributada integralmente.
		/// </summary>
		[XmlElement( ElementName = "CST",Order = 2 )]
		public string Cst
		{
			get; set;
		}

		/// <summary>
		/// Modalidade de determinação da BC do ICMS
		/// 
		/// 0=Margem Valor Agregado (%);
		/// 1=Pauta( Valor);
		/// 2=Preço Tabelado Máx. (valor);
		/// 3=Valor da operação.
		/// </summary>
		[XmlElement( ElementName = "modBC",Order = 3 )]
		public int Modalidade_BaseCalculoICMS
		{
			get; set;
		}

		/// <summary>
		/// Valor da BC do ICMS
		/// </summary>
		[XmlElement( ElementName = "vBC",Order = 5 )]
		public decimal Valor_BaseCalculoICMS
		{
			get
			{
				return _valorbasecalculoicms.Round( DecimalValorTotal );
			}
			set
			{
				if( _valorbasecalculoicms != value )
					_valorbasecalculoicms = value;
			}
		}
		/// <summary>
		/// Alíquota do imposto
		/// </summary>
		[XmlElement( ElementName = "pICMS",Order = 6 )]
		public decimal Aliquota_ImpostoICMS
		{
			get
			{
				return _aliquotaimpostoicms.Round( DecimalAliquota );
			}
			set
			{
				if( _aliquotaimpostoicms != value )
					_aliquotaimpostoicms = value;
			}
		}

		/// <summary>
		/// Valor do ICMS
		/// </summary>
		[XmlElement( ElementName = "vICMS",Order = 7 )]
		public decimal Valor_Icms
		{
			get
			{
				_valoricms = Valor_BaseCalculoICMS * ( Aliquota_ImpostoICMS / 100.00M );
				return _valoricms.Round( DecimalValorTotal );
			}
			set
			{
				if( _valoricms != value )
					_valoricms = value;
			}
		}

		public IcmsBase()
		{
		}
		public IcmsBase( OrigemMercadoria origem_Mercadoria,ModalidadeBasedeCalculoICMS modalidade_BaseCalculoICMS,decimal valor_BaseCalculoICMS,
				decimal aliquota_ImpostoICMS )
		{
			Cst = "00";
			Origem_Mercadoria = (int)origem_Mercadoria;
			Modalidade_BaseCalculoICMS = (int)modalidade_BaseCalculoICMS;
			Valor_BaseCalculoICMS = valor_BaseCalculoICMS;
			Aliquota_ImpostoICMS = aliquota_ImpostoICMS;
		}

	}
}
