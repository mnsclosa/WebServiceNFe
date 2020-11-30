using System;
using System.Xml.Serialization;
using static ServiceNFe.Entities.Constantes;

namespace ServiceNFe.Entities.NFe
{
	[Serializable()]
	[XmlRoot( ElementName = "PISOutr" )]
	public class CofinsOutr
	{

		private decimal _valorbasecalculocofins;
		private decimal _aliquotacofins;
		private decimal _valorcofins;

		/// <summary>
		/// Código de Situação Tributária do COFINS
		/// 
		/// 01=Operação Tributável (base de cálculo = valor da operação alíquota normal( cumulativo/não cumulativo ));
		/// 02=Operação Tributável(base de cálculo = valor da operação(alíquota diferenciada));
		/// 03=Operação Tributável (base de cálculo = quantidade vendida x alíquota por unidade de produto);
		/// 04=Operação Tributável (tributação monofásica (alíquota zero));
		/// 05=Operação Tributável( Substituição Tributária );
		/// 06=Operação Tributável( alíquota zero );
		/// 07=Operação Isenta da Contribuição;
		/// 08=Operação Sem Incidência da Contribuição;
		/// 09=Operação com Suspensão da Contribuição;
		/// 49=Outras Operações de Saída;
		/// 50=Operação com Direito a Crédito - Vinculada Exclusivamente a Receita Tributada no Mercado Interno;
		/// 51=Operação com Direito a Crédito - Vinculada Exclusivamente a Receita Não Tributada no Mercado Interno;
		/// 52=Operação com Direito a Crédito – Vinculada Exclusivamente a Receita de Exportação;
		/// 53=Operação com Direito a Crédito - Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno;
		/// 54=Operação com Direito a Crédito - Vinculada a Receitas Tributadas no Mercado Interno e de Exportação;
		/// 55=Operação com Direito a Crédito - Vinculada a Receitas NãoTributadas no Mercado Interno e de Exportação;
		/// 56=Operação com Direito a Crédito - Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno, e de Exportação;
		/// 60=Crédito Presumido - Operação de Aquisição Vinculada Exclusivamente a Receita Tributada no Mercado Interno;
		/// 61=Crédito Presumido - Operação de Aquisição Vinculada Exclusivamente a Receita Não-Tributada no Mercado Interno;
		/// 62=Crédito Presumido - Operação de Aquisição Vinculada Exclusivamente a Receita de Exportação;
		/// 63=Crédito Presumido - Operação de Aquisição Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno;
		/// 64=Crédito Presumido - Operação de Aquisição Vinculada a Receitas Tributadas no Mercado Interno e de Exportação;
		/// 65=Crédito Presumido - Operação de Aquisição Vinculada a Receitas Não-Tributadas no Mercado Interno e de Exportação;
		/// 66=Crédito Presumido - Operação de Aquisição Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno, e de Exportação;
		/// 67=Crédito Presumido - Outras Operações;
		/// 70=Operação de Aquisição sem Direito a Crédito;
		/// 71=Operação de Aquisição com Isenção;
		/// 72=Operação de Aquisição com Suspensão;
		/// 73=Operação de Aquisição a Alíquota Zero;
		/// 74=Operação de Aquisição; sem Incidência da Contribuição;
		/// 75=Operação de Aquisição por Substituição Tributária;
		/// 98=Outras Operações de Entrada;
		/// 99=Outras Operações;
		/// 
		/// Não criarei o enum por não achar uma saida para a descrição de cada item.
		/// </summary>
		[XmlElement( ElementName = "CST",Order = 1 )]
		public string Cst
		{
			get; set;
		} = "99";

		/// <summary>
		/// Valor da BC do COFINS
		/// </summary>
		[XmlElement( ElementName = "vBC",Order = 2 )]
		public decimal ValorBaseCalculoCofins
		{
			get
			{
				return _valorbasecalculocofins.Round( DecimalValorTotal );
			}
			set
			{
				if( _valorbasecalculocofins != value )
					_valorbasecalculocofins = value;
			}
		}

		/// <summary>
		/// Alíquota do COFINS
		/// </summary>
		[XmlElement( ElementName = "pCOFINS",Order = 3 )]
		public decimal Aliquota_Cofins
		{
			get
			{
				return _aliquotacofins.Round( DecimalAliquota );
			}
			set
			{
				if( _aliquotacofins != value )
					_aliquotacofins = value;
			}
		}

		/// <summary>
		/// Valor do COFINS
		/// </summary>
		[XmlElement( ElementName = "vCOFINS",Order = 4 )]
		public decimal Valor_Cofins
		{
			get
			{
				_valorcofins = ValorBaseCalculoCofins * ( Aliquota_Cofins / 100.00M );
				return _valorcofins.Round( DecimalValorTotal );
			}
			set
			{
				if( _valorcofins != value )
					_valorcofins = value;
			}
		}

		public CofinsOutr()
		{
		}

		public CofinsOutr( string cst,decimal valor_BaseCalculoCofins,decimal aliquota_Cofins )
		{
			Cst = cst ?? throw new ArgumentNullException( nameof( cst ) );
			ValorBaseCalculoCofins = valor_BaseCalculoCofins;
			Aliquota_Cofins = aliquota_Cofins;
		}
	}
}
