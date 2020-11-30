using System;
using System.Xml.Serialization;

namespace ServiceNFe.Entities.NFe
{
	/// <summary>
	/// Esta classe foi criada somente para ficar mais fácil e didatica com a montagem da serialização da NFe
	/// </summary>
	[Serializable()]
	[XmlRoot( ElementName = "enderEmit" )]
	public class EnderDest : EnderEmit
	{
		public EnderDest()
		{
		}

		/// <summary>
		/// Construtor da classe
		/// </summary>
		/// <param name="logradouro">Rua, Avenida.. da Empresa (Herdado)</param>
		/// <param name="numero">Número da Empresa(Herdado)</param>
		/// <param name="complemento">Complemento do endereço. ex Bloco 2(Herdado)</param>
		/// <param name="bairro">Bairro da Empresa(Herdado)</param>
		/// <param name="codigoMunicipio">Utilizar a Tabela do IBGE (Anexo IX- Tabela de UF, Município e País).(Herdado)</param>
		/// <param name="municipio">Nome do Município(Herdado)</param>
		/// <param name="cEP">CEP da Empresa (Herdado)</param>
		/// <param name="telefone">Telefone da Empresa com DDD e sem a mascara</param>
		public EnderDest( string logradouro,string numero,string complemento,string bairro, string codigoMunicipio,string municipio,string cEP,string telefone ) :
					base( logradouro,numero,complemento,bairro,codigoMunicipio,municipio,cEP,telefone )
		{
		}

	}
}
