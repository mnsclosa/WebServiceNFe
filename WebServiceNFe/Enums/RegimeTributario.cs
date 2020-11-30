using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceNFe.Enums
{
	/// <summary>
	/// 1=Simples Nacional;
	/// 2=Simples Nacional, excesso sublimite de receita bruta;
	/// 3=Regime Normal. ( v2.0).
	/// </summary>
	public enum RegimeTributario :int
	{
		Simples_Nacional = 1,
		Simples_Nacional_Sublimite_Receita_Bruta,
		Regime_Normal
	}
}
