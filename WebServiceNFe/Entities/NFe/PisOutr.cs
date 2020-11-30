using System;
using System.Xml.Serialization;
using static ServiceNFe.Entities.Constantes;

namespace ServiceNFe.Entities.NFe
{
	[Serializable()]
	[XmlRoot( ElementName = "PISOutr" )]
	public class PisOutr
	{

		private decimal _valorbasecalculopis;
		private decimal _aliquotapis;
		private decimal _valorpis;

		/// <summary>
		/// Código de Situação Tributária do PIS
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
		/// Valor da BC do PIS
		/// </summary>
		[XmlElement( ElementName = "vBC",Order = 2 )]
		public decimal Valor_BaseCalculoPis
		{
			get
			{
				return _valorbasecalculopis.Round( DecimalValorTotal );
			}
			set
			{
				if( _valorbasecalculopis != value )
					_valorbasecalculopis = value;
			}
		}

		/// <summary>
		/// Alíquota do PIS
		/// </summary>
		[XmlElement( ElementName = "pPIS",Order = 3 )]
		public decimal Aliquota_Pis
		{
			get
			{
				return _aliquotapis.Round( DecimalAliquota );
			}
			set
			{
				if( _aliquotapis != value )
					_aliquotapis = value;
			}
		}

		/// <summary>
		/// Valor do PIS
		/// </summary>
		[XmlElement( ElementName = "vPIS",Order = 4 )]
		public decimal Valor_Pis
		{
			get
			{
				_valorpis = Valor_BaseCalculoPis * ( Aliquota_Pis / 100.00M );
				return _valorpis.Round( DecimalValorTotal );
			}
			set
			{
				if( _valorpis != value )
					_valorpis = value;
			}
		}

		public PisOutr()
		{
		}

		public PisOutr( string cst,decimal valor_BaseCalculoPis,decimal aliquota_Pis )
		{
			Cst = cst ?? throw new ArgumentNullException( nameof( cst ) );
			Valor_BaseCalculoPis = valor_BaseCalculoPis;
			Aliquota_Pis = aliquota_Pis;
		}
	}
}
