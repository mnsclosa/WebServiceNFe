using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceNFe.Enums
{
	/// <summary>
	/// 0=Valor do item (vProd) não compõe o valor total da NF-e
	/// 1=Valor do item( vProd) compõe o valor total da NF-e( vProd)(v2.0)
	/// </summary>
	public enum IndicaItemTotal : int
	{
		Valor_nao_Compoe,
		ValorCompoe
	}
}
