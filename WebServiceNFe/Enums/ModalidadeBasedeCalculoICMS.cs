namespace ServiceNFe.Enums
{
	/// 0=Margem Valor Agregado (%);
	/// 1=Pauta( Valor);
	/// 2=Preço Tabelado Máx. (valor);
	/// 3=Valor da operação.
	public enum ModalidadeBasedeCalculoICMS : int
	{
		MargemValorAgregado,
		PautaValor,
		PrecoTabeladoMax,
		ValordaOperacao
	}
}
