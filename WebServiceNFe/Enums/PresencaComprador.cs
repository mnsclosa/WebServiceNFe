namespace ServiceNFe.Enums
{
	/// <summary>
	/// 0=Não se aplica (por exemplo, Nota Fiscal complementar ou de ajuste);
	/// 1=Operação presencial;
	/// 2=Operação não presencial, pela Internet;
	/// 3=Operação não presencial, Teleatendimento;
	/// 4=NFC-e em operação com entrega a domicílio;
	/// 9=Operação não presencial, outros.
	/// </summary>
	public enum PresencaComprador : int
	{
		Nao_se_Aplica,
		Operacao_Presencial,
		Operacao_Internet,
		Operacao_Teleatendimento,
		NFCe_Entrega_domicilio,
		Operacao_nao_Presencial = 9
	}
}
