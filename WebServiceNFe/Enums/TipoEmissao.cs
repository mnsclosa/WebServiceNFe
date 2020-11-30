namespace ServiceNFe.Enums
{
	/// <summary>
	/// 1=Emissão normal (não em contingência);
	/// 2=Contingência FS-IA, com impressão do DANFE em formulário de segurança;
	/// 3=Contingência SCAN( Sistema de Contingência do Ambiente Nacional );
	/// 4=Contingência DPEC( Declaração Prévia da Emissão em Contingência );
	/// 5=Contingência FS-DA, com impressão do DANFE em formulário de segurança;
	/// 6=Contingência SVC-AN( SEFAZ Virtual de Contingência do AN);
	/// 7=Contingência SVC-RS( SEFAZ Virtual de Contingência do RS);
	/// 9=Contingência off-line da NFC-e (as demais opções de contingência são válidas também para a NFC-e).
	/// 
	/// Para a NFC-e somente estão disponíveis e são válidas as opções de contingência 5 e 9.
	/// </summary>
	public enum TipoEmissao
	{
		Emissao_Normal = 1,
		Contingencia_FS_IA,
		Contingencia_SCAN,
		Contingencia_DPEC,
		Contingencia_FS_DA,
		Contingencia_SVC_AN,
		Contingencia_SVC_RS,
		Contingencia_Off_Line_NFCe = 9
	}
}
