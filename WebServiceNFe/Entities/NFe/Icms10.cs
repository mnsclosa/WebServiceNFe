using ServiceNFe.Enums;
using System;
using System.Xml.Serialization;
using static ServiceNFe.Entities.Constantes;

namespace ServiceNFe.Entities.NFe
{
	[Serializable()]
	[XmlRoot( ElementName = "ICMS10" )]
	public class Icms10 : IcmsBase
	{
		private decimal _percentualmargemvaloradicionadosubsttrib;
		private decimal _percentualreducaobasecalculosubsttrib;
		private decimal _valorbasecalculosubsttrib;
		private decimal _aliquotaicmssubsttrib;
		private decimal _valoricmssubsttrib;

		/* a classe icms00 termina com o order 7 na serialização */

		/// <summary>
		/// Modalidade de determinação da BC do ICMS ST
		/// 
		/// 0=Preço tabelado ou máximo sugerido;
		/// 1=Lista Negativa( valor);
		/// 2=Lista Positiva( valor);
	/// 3=Lista Neutra( valor);
		/// 4=Margem Valor Agregado(%);
		/// 5=Pauta( valor);
		/// </summary>
		[XmlElement( ElementName = "modBCST",Order = 8 )]
		public int Modalidade_BaseCalculoSubst_Trib
		{
			get;set;
		}

		/// <summary>
		/// Percentual da margem de valor Adicionado do ICMS ST
		/// </summary>
		[XmlElement( ElementName = "pMVAST",Order = 9 )]
		public decimal Percentual_MargemValorAdicionadoSubstTrib
		{
			get
			{
				return _percentualmargemvaloradicionadosubsttrib.Round( DecimalAliquota );
			}
			set
			{
				if( _percentualmargemvaloradicionadosubsttrib != value )
					_percentualmargemvaloradicionadosubsttrib = value;
			}
		}

		/// <summary>
		/// Percentual da Redução de BC do ICMS ST
		/// </summary>
		[XmlElement( ElementName = "pRedBCST",Order = 10 )]
		public decimal Percentual_ReducaoBaseCalculoSubstTrib
		{
			get
			{
				return _percentualreducaobasecalculosubsttrib.Round( DecimalAliquota );
			}
			set
			{
				if( _percentualreducaobasecalculosubsttrib != value )
					_percentualreducaobasecalculosubsttrib = value;
			}
		}

		/// <summary>
		/// Valor da BC do ICMS ST
		/// </summary>
		[XmlElement( ElementName = "vBCST",Order = 11 )]
		public decimal Valor_BaseCalculoSubstTrib
		{
			get
			{
				return _valorbasecalculosubsttrib.Round( DecimalValorTotal );
			}
			set
			{
				if( _valorbasecalculosubsttrib != value )
					_valorbasecalculosubsttrib = value;
			}
		}

		/// <summary>
		/// Alíquota do imposto do ICMS ST
		/// </summary>
		[XmlElement( ElementName = "pICMSST",Order = 12 )]
		public decimal Aliquota_IcmsSubstTrib
		{
			get
			{
				return _aliquotaicmssubsttrib.Round( DecimalAliquota );
			}
			set
			{
				if( _aliquotaicmssubsttrib != value )
					_aliquotaicmssubsttrib = value;
			}
		}

		/// <summary>
		/// Valor do ICMS ST
		/// 
		/// Valor do ICMS ST retido
		/// </summary>
		[XmlElement( ElementName = "vICMSST",Order = 13 )]
		public decimal Valor_IcmsSubstTrib
		{
			get
			{
				return _valoricmssubsttrib.Round( DecimalValorTotal );
			}
			set
			{
				if( _valoricmssubsttrib != value )
					_valoricmssubsttrib = value;
			}
		}

		/// <summary>
		/// Construtor padrão para a serialização.
		/// </summary>
		public Icms10()
		{
		}

		/// <summary>
		/// Grupo Tributação do ICMS = 10.
		/// Tributada integralmente.
		/// </summary>
		/// <param name="origem_Mercadoria">0 - Nacional, exceto as indicadas nos códigos 3, 4, 5 e 8;
		/// 1 - Estrangeira - Importação direta, exceto a indicada no código 6;
		/// 2 - Estrangeira - Adquirida no mercado interno, exceto a indicada no código 7;
		/// 3 - Nacional, mercadoria ou bem com Conteúdo de Importação superior a 40% e inferior ou igual a 70%;
		/// 4 - Nacional, cuja produção tenha sido feita em conformidade com os processos produtivos básicos de que tratam as
		///		legislações citadas nos Ajustes;
		/// 5 - Nacional, mercadoria ou bem com Conteúdo de Importação inferior ou igual a 40%;
		/// 6 - Estrangeira - Importação direta, sem similar nacional, constante em lista da CAMEX e gás natural;
		/// 7 - Estrangeira - Adquirida no mercado interno, sem similar nacional, constante lista CAMEX e gás natural.
		/// 8 - Nacional, mercadoria ou bem com Conteúdo de Importação superior a 70%;</param>
		/// <param name="modalidade_BaseCalculoICMS">0=Margem Valor Agregado (%);
		/// 1=Pauta( Valor);
		/// 2=Preço Tabelado Máx. (valor);
		/// 3=Valor da operação.</param>
		/// <param name="valor_BaseCalculoICMS">Valor da BC do ICMS</param>
		/// <param name="aliquota_ImpostoICMS">Alíquota do imposto</param>
		/// <param name="modalidade_BaseCalculoSubst_Trib"></param>
		/// <param name="percentual_MargemValorAdicionadoSubstTrib"></param>
		/// <param name="percentual_ReducaoBaseCalculoSubstTrib"></param>
		/// <param name="valor_BaseCalculoSubstTrib"></param>
		/// <param name="aliquota_IcmsSubstTrib"></param>
		/// <param name="valor_IcmsSubstTrib"></param>
		public Icms10( OrigemMercadoria origem_Mercadoria,ModalidadeBasedeCalculoICMS modalidade_BaseCalculoICMS,decimal valor_BaseCalculoICMS,
						decimal aliquota_ImpostoICMS,ModalidadeBasedeCaloculoSubst_Trib modalidade_BaseCalculoSubst_Trib,decimal percentual_MargemValorAdicionadoSubstTrib,
						decimal percentual_ReducaoBaseCalculoSubstTrib,decimal valor_BaseCalculoSubstTrib,decimal aliquota_IcmsSubstTrib,
						decimal valor_IcmsSubstTrib ) : base( origem_Mercadoria,modalidade_BaseCalculoICMS,valor_BaseCalculoICMS,aliquota_ImpostoICMS )
		{
			Cst = "10";
			Modalidade_BaseCalculoSubst_Trib = (int)modalidade_BaseCalculoSubst_Trib;
			Percentual_MargemValorAdicionadoSubstTrib = percentual_MargemValorAdicionadoSubstTrib;
			Percentual_ReducaoBaseCalculoSubstTrib = percentual_ReducaoBaseCalculoSubstTrib;
			Valor_BaseCalculoSubstTrib = valor_BaseCalculoSubstTrib;
			Aliquota_IcmsSubstTrib = aliquota_IcmsSubstTrib;
			Valor_IcmsSubstTrib = valor_IcmsSubstTrib;
		}
	}
}
