namespace ServiceNFe.Enums
{
	/// 01=Dinheiro
	/// 02=Cheque
	/// 03=Cartão de Crédito
	/// 04=Cartão de Débito
	/// 05=Crédito Loja
	/// 10=Vale Alimentação
	/// 11=Vale Refeição
	/// 12=Vale Presente
	/// 13=Vale Combustível
	/// 15=Boleto Bancário
	/// 90= Sem pagamento
	/// 99=Outros

	public enum FormadePagamento : int
	{
		Dinheiro = 1,
		Cheque,
		CartaodeCredito,
		CartaodeDebito,
		CreditoLoja,
		ValeAlimentacao = 10,
		ValeRefeicao,
		ValePresente,
		ValeCombustivel,
		BoletoBancario = 15,
		SemPagamento = 90,
		Outros = 99
	}
}
