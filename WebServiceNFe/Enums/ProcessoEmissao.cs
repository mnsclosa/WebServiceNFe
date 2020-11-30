namespace ServiceNFe.Enums
{
	/// <summary>
	/// 0=Emissão de NF-e com aplicativo do contribuinte;
	/// 1=Emissão de NF-e avulsa pelo Fisco;
	/// 2=Emissão de NF-e avulsa, pelo contribuinte com seu certificado digital, através do site do Fisco;
	/// 3=Emissão NF-e pelo contribuinte com aplicativo fornecido pelo Fisco
	/// </summary>
	public enum ProcessoEmissao :int
	{
		EmissaoNFe_com_Aplicativo_contribuinte,
		EmissaoNFe_Avulsa_Fisco,
		EmissaoNFe_Avulsa_CertificadoDigital_Fisco,
		EmissaoNFe_Aplicativo_Fisco
	}
}
