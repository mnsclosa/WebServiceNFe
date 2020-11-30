using System;
using System.Xml.Serialization;
using static ServiceNFe.Entities.Constantes;

namespace ServiceNFe.Entities.NFe
{
	[Serializable()]
	[XmlRoot( ElementName = "ICMSTot" )]
	public class IcmsTot
	{
		private decimal _valorbasecalculoicms;
		private decimal _valoricms;
		private decimal _valoricmsdeson;
		private decimal _valorfundocombatepobreza;
		private decimal _valorbasecalculosubsttrib;
		private decimal _valorsubsttrib;
		private decimal _valorfundocombatepobrezaretidost;
		private decimal _valorfundocombatepobrezaretidoantst;
		private decimal _valortotalproduto;
		private decimal _valortotalfrete;
		private decimal _valortotalseguro;
		private decimal _valordesconto;
		private decimal _valorimpostoimportacao;
		private decimal _valoripi;
		private decimal _valoripidevol;
		private decimal _valorpis;
		private decimal _valorcofins;
		private decimal _outrasdespesas;
		private decimal _valortotalnfe;
		private decimal _valortotaltributos;

		/// <summary>
		/// Valor da BC do ICMS
		/// </summary>
		[XmlElement( ElementName = "vBC",Order = 1 )]
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
		/// Valor do ICMS
		/// </summary>
		[XmlElement( ElementName = "vICMS",Order = 2 )]
		public decimal Valor_Icms
		{
			get
			{
				return _valoricms.Round( DecimalValorTotal );
			}
			set
			{
				if( _valoricms != value )
					_valoricms = value;
			}
		}

		/// <summary>
		/// Valor Total do ICMS desonerado 
		/// </summary>
		[XmlElement( ElementName = "vICMSDeson",Order = 3 )]
		public decimal Valor_IcmsDeson
		{
			get
			{
				return _valoricmsdeson.Round( DecimalValorTotal );
			}
			set
			{
				if( _valoricmsdeson != value )
					_valoricmsdeson = value;
			}
		}

		/// <summary>
		/// Valor Total do FCP (Fundo de Combate à Pobreza)
		/// </summary>
		[XmlElement( ElementName = "vFCP",Order = 4 )]
		public decimal Valor_FundoCombatePobreza
		{
			get
			{
				return _valorfundocombatepobreza.Round( DecimalValorTotal );
			}
			set
			{
				if( _valorfundocombatepobreza != value )
					_valorfundocombatepobreza = value;
			}
		}

		/// <summary>
		/// Valor da BC do ICMS ST
		/// </summary>
		[XmlElement( ElementName = "vBCST",Order = 5 )]
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
		/// Valor Total do ICMS ST 
		/// </summary>
		[XmlElement( ElementName = "vST",Order = 6 )]
		public decimal Valor_SubstTrib
		{
			get
			{
				return _valorsubsttrib.Round( DecimalValorTotal );
			}
			set
			{
				if( _valorsubsttrib != value )
					_valorsubsttrib = value;
			}
		}

		/// <summary>
		/// Valor Total do FCP (Fundo de Combate à Pobreza) retido por substituição tributária
		/// 
		/// Corresponde ao total da soma dos campos id:N23d
		/// </summary>
		[XmlElement( ElementName = "vFCPST",Order = 7 )]
		public decimal Valor_FundoCombatePobrezaRetidoST
		{
			get
			{
				return _valorfundocombatepobrezaretidost.Round( DecimalValorTotal );
			}
			set
			{
				if( _valorfundocombatepobrezaretidost != value )
					_valorfundocombatepobrezaretidost = value;
			}
		}

		/// <summary>
		/// Valor Total do FCP retido anteriormente por Substituição Tributária
		/// 
		/// Corresponde ao total da soma dos campos id:N27d
		/// </summary>
		[XmlElement( ElementName = "vFCPSTRet",Order = 8 )]
		public decimal Valor_FundoCombatePobrezaRetidoAntST
		{
			get
			{
				return _valorfundocombatepobrezaretidoantst.Round( DecimalValorTotal );
			}
			set
			{
				if( _valorfundocombatepobrezaretidoantst != value )
					_valorfundocombatepobrezaretidoantst = value;
			}
		}

		/// <summary>
		/// Valor Total Bruto dos Produtos ou Serviços
		/// </summary>
		[XmlElement( ElementName = "vProd",Order = 9 )]
		public decimal Valor_TotalProduto
		{
			get
			{
				return _valortotalproduto;
			}
			set
			{
				if( _valortotalproduto != value )
					_valortotalproduto = value;
			}
		}
		/// <summary>
		/// Valor Total do Frete
		/// </summary>
		[XmlElement( ElementName = "vFrete",Order = 10 )]
		public decimal Valor_TotalFrete
		{
			get
			{
				return _valortotalfrete.Round( DecimalValorTotal );
			}
			set
			{
				if( _valortotalfrete != value )
					_valortotalfrete = value;
			}
		}

		/// <summary>
		/// Valor Total do Seguro
		/// </summary>
		[XmlElement( ElementName = "vSeg",Order = 11 )]
		public decimal Valor_TotalSeguro
		{
			get
			{
				return _valortotalseguro.Round( DecimalValorTotal );
			}
			set
			{
				if( _valortotalseguro != value )
					_valortotalseguro = value;
			}
		}

		/// <summary>
		/// Valor do Desconto
		/// </summary>
		[XmlElement( ElementName = "vDesc",Order = 12 )]
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
		/// Valor Total do II
		/// </summary>
		[XmlElement( ElementName = "vII",Order = 13 )]
		public decimal Valor_ImpostoImportacao
		{
			get
			{
				return _valorimpostoimportacao.Round( DecimalValorTotal );
			}
			set
			{
				if( _valorimpostoimportacao != value )
					_valorimpostoimportacao = value;
			}
		}

		/// <summary>
		/// Valor Total do IPI 
		/// </summary>
		[XmlElement( ElementName = "vIPI",Order = 14 )]
		public decimal Valor_IPI
		{
			get
			{
				return _valoripi.Round( DecimalValorTotal );
			}
			set
			{
				if( _valoripi != value )
					_valoripi = value;
			}
		}

		/// <summary>
		/// Valor Total do IPI devolvido
		/// 
		/// Deve ser informado quando preenchido o Grupo Tributos Devolvidos na emissão de nota finNFe = 4( devolução ) nas 
		/// operações com não contribuintes do IPI.Corresponde ao total da soma dos campos id:UA04.
		/// </summary>
		[XmlElement( ElementName = "vIPIDevol",Order = 15 )]
		public decimal Valor_IPIDevol
		{
			get
			{
				return _valoripidevol.Round( DecimalValorTotal );
			}
			set
			{
				if( _valoripidevol != value )
					_valoripidevol = value;
			}
		}

		/// <summary>
		/// Valor do PIS 
		/// </summary>
		[XmlElement( ElementName = "vPIS",Order = 16 )]
		public decimal Valor_PIS
		{
			get
			{
				return _valorpis.Round( DecimalValorTotal );
			}
			set
			{
				if( _valorpis != value )
					_valorpis = value;
			}
		}

		/// <summary>
		/// Valor do COFINS 
		/// </summary>
		[XmlElement( ElementName = "vCOFINS",Order = 17 )]
		public decimal Valor_COFINS
		{
			get
			{
				return _valorcofins.Round( DecimalValorTotal );
			}
			set
			{
				if( _valorcofins != value )
					_valorcofins = value;
			}
		}

		/// <summary>
		/// Outras despesas acessórias
		/// </summary>
		[XmlElement( ElementName = "vOutro",Order = 18 )]
		public decimal Outras_Despesas
		{
			get
			{
				return _outrasdespesas.Round( DecimalValorTotal );
			}
			set
			{
				if( _outrasdespesas != value )
					_outrasdespesas = value;
			}
		}

		/// <summary>
		/// Valor Total da NF-e
		/// </summary>
		[XmlElement( ElementName = "vNF",Order = 19 )]
		public decimal Valor_TotalNFe
		{
			get
			{
				return _valortotalnfe.Round( DecimalValorTotal );
			}
			set
			{
				if( _valortotalnfe != value )
					_valortotalnfe = value;
			}
		}
		/// <summary>
		/// Valor aproximado total de tributos federais, estaduais e municipais.
		/// </summary>
		[XmlElement( ElementName = "vTotTrib",Order = 20 )]
		public decimal Valor_TotalTributos
		{
			get
			{
				return _valortotaltributos.Round( DecimalValorTotal );
			}
			set
			{
				if( _valortotaltributos != value )
					_valortotaltributos = value;
			}
		}

		/// <summary>
		/// Construtor padrão para a serialização.
		/// </summary>
		public IcmsTot()
		{
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="valor_BaseCalculoICMS">Base de Cálculo do ICMS</param>
		/// <param name="valor_Icms">Valor Total do ICMS</param>
		/// <param name="valor_IcmsDeson">Valor Total do ICMS desonerado</param>
		/// <param name="valor_FundoCombatePobreza">Valor Total do FCP (Fundo de Combate à Pobreza)</param>
		/// <param name="valor_BaseCalculoSubstTrib">Base de Cálculo do ICMS ST</param>
		/// <param name="valor_SubstTrib">Valor Total do ICMS ST</param>
		/// <param name="valor_FundoCombatePobrezaRetidoST">Valor Total do FCP (Fundo de Combate à Pobreza) retido por substituição tributária</param>
		/// <param name="valor_FundoCombatePobrezaRetidoAntST">Valor Total do FCP retido anteriormente por Substituição	Tributária</param>
		/// <param name="valor_TotalProduto">Valor Total dos produtos e serviços</param>
		/// <param name="valor_TotalFrete">Valor Total do Frete</param>
		/// <param name="valor_TotalSeguro">Valor Total do Seguro</param>
		/// <param name="valor_Desconto">Valor Total do Desconto</param>
		/// <param name="valor_ImpostoImportacao">Valor Total do II </param>
		/// <param name="valor_IPI">Valor Total do IPI</param>
		/// <param name="valor_IPIDevol"></param>
		/// <param name="valor_PIS"></param>
		/// <param name="valor_COFINS">Valor da COFINS</param>
		/// <param name="outras_Despesas">Outras Despesas acessórias</param>
		/// <param name="valor_TotalNFe">Valor Total da NF-e</param>
		/// <param name="valor_TotalTributos">Valor aproximado total de tributos federais,estaduais e municipais.</param>
		public IcmsTot( decimal valor_BaseCalculoICMS,decimal valor_Icms,decimal valor_IcmsDeson,decimal valor_FundoCombatePobreza,decimal valor_BaseCalculoSubstTrib,
						decimal valor_SubstTrib,decimal valor_FundoCombatePobrezaRetidoST,decimal valor_FundoCombatePobrezaRetidoAntST,decimal valor_TotalProduto,
						decimal valor_TotalFrete,decimal valor_TotalSeguro,decimal valor_Desconto,decimal valor_ImpostoImportacao,decimal valor_IPI,
						decimal valor_IPIDevol,decimal valor_PIS,decimal valor_COFINS,decimal outras_Despesas,decimal valor_TotalNFe,decimal valor_TotalTributos )
		{
			Valor_BaseCalculoICMS = valor_BaseCalculoICMS;
			Valor_Icms = valor_Icms;
			Valor_IcmsDeson = valor_IcmsDeson;
			Valor_FundoCombatePobreza = valor_FundoCombatePobreza;
			Valor_BaseCalculoSubstTrib = valor_BaseCalculoSubstTrib;
			Valor_SubstTrib = valor_SubstTrib;
			Valor_FundoCombatePobrezaRetidoST = valor_FundoCombatePobrezaRetidoST;
			Valor_FundoCombatePobrezaRetidoAntST = valor_FundoCombatePobrezaRetidoAntST;
			Valor_TotalProduto = valor_TotalProduto;
			Valor_TotalFrete = valor_TotalFrete;
			Valor_TotalSeguro = valor_TotalSeguro;
			Valor_Desconto = valor_Desconto;
			Valor_ImpostoImportacao = valor_ImpostoImportacao;
			Valor_IPI = valor_IPI;
			Valor_PIS = valor_PIS;
			Valor_IPIDevol = valor_IPIDevol;
			Valor_COFINS = valor_COFINS;
			Outras_Despesas = outras_Despesas;
			Valor_TotalNFe = valor_TotalNFe;
			Valor_TotalTributos = valor_TotalTributos;
		}
	}
}
