namespace ServiceNFe.Enums
{
	/// <summary>
	/// 1=Operação interna;
	/// 2=Operação interestadual;
	/// 3=Operação com exterior.
	/// </summary>
	public enum IdentificadorDestino : int
	{
		Operacao_Interna = 1,
		Operacao_Interestadual,
		Operacao_com_Exterior
	}
}
