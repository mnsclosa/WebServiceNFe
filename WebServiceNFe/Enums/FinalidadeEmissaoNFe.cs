namespace ServiceNFe.Enums
{
	/// <summary>
	/// 1=NF-e normal;
	/// 2=NF-e complementar;
	/// 3=NF-e de ajuste;
	/// 4=Devolução de mercadoria.
	/// </summary>
	public enum FinalidadeEmissaoNFe : int
	{
		NFe_Normal = 1,
		NFe_Complementar,
		NFe_de_Ajuste,
		Devolucao_de_mercadoria
	}
}
