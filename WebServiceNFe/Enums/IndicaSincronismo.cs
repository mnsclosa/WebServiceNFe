namespace ServiceNFe.Enums
{
	/// <summary>
	/// 0=Não.
	/// 1=Empresa solicita processamento síncrono do Lote de NF-e( sem a geração de Recibo para consulta futura );
	/// Nota: O processamento síncrono do Lote corresponde a entrega da resposta do processamento das NF-e do Lote, sem a geração
	/// de um Recibo de Lote para consulta futura.A resposta de forma síncrona pela SEFAZ Autorizadora só ocorrerá se:
	/// - a empresa solicitar e constar unicamente uma NFe no Lote;
	/// - a SEFAZ Autorizadora implementar o processamento síncrono para a resposta do Lote de NF-e.
	/// </summary>

	public enum IndicaSincronismo : int
	{
		ProcessoAssincrono,
		ProcessoSincrono
	}
}
