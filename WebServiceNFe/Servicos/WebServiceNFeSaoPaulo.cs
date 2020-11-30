using ServiceNFe.Enums;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace ServiceNFe.Servicos
{
	class WebServiceNFeSaoPaulo : WebServiceNFe
	{
		/// <summary>
		/// Consulta o cadastro do contribuinte por IE, CPF ou CNPJ.
		/// </summary>
		/// <param name="xml"></param>
		/// <param name="X509Cert"></param>
		/// <returns></returns>
		public override XmlNode ConsultaCadastro( XmlNode xml,X509Certificate2 X509Cert )
		{
			if( Tipodeambiente == TipodeAmbiente.Producao )
			{
				/* verifico qual o ambiente será utilizado */
				ConsultaCadastroContribuinte4.CadConsultaCadastro4 cadConsultaCadastro4 = new ConsultaCadastroContribuinte4.CadConsultaCadastro4();

				RelacionarCertObj( cadConsultaCadastro4,X509Cert );
				return cadConsultaCadastro4.consultaCadastro( xml );
			}
			else
			{
				/* verifico qual o ambiente será utilizado */
				Homologacao_ConsultaCadastroContribuinte4.CadConsultaCadastro4 cadConsultaCadastro4 = new Homologacao_ConsultaCadastroContribuinte4.CadConsultaCadastro4();

				RelacionarCertObj( cadConsultaCadastro4,X509Cert );
				return cadConsultaCadastro4.consultaCadastro( xml );
			}
		}

		/// <summary>
		/// Verifica se os serviços da receita federal do Estado consultado estão OK.
		/// </summary>
		/// <param name="xml"></param>
		/// <param name="X509Cert"></param>
		/// <returns></returns>
		public override XmlNode StatusServico( XmlNode xml,X509Certificate2 X509Cert )
		{
			if( Tipodeambiente == TipodeAmbiente.Producao )
			{
				NFeStatusServico4.NFeStatusServico4 nFeStatusServico4 = new NFeStatusServico4.NFeStatusServico4();
				RelacionarCertObj( nFeStatusServico4,X509Cert );
				return nFeStatusServico4.nfeStatusServicoNF( xml );
			}
			else
			{
				Homologacao_NFeStatusServico4.NFeStatusServico4 nFeStatusServico4 = new Homologacao_NFeStatusServico4.NFeStatusServico4();
				RelacionarCertObj( nFeStatusServico4,X509Cert );
				return nFeStatusServico4.nfeStatusServicoNF( xml );
			}
		}
		/// <summary>
		/// Inutiliza um range de numeros da NFe
		/// </summary>
		/// <param name="xml"></param>
		/// <param name="X509Cert"></param>
		/// <returns></returns>
		public override XmlNode InutilizaNumeracao( XmlNode xml,X509Certificate2 X509Cert )
		{
			if( Tipodeambiente == TipodeAmbiente.Producao )
			{
				Inutilizacao4.NFeInutilizacao4 nFeInutilizacao4 = new Inutilizacao4.NFeInutilizacao4();
				RelacionarCertObj( nFeInutilizacao4,X509Cert );
				return nFeInutilizacao4.nfeInutilizacaoNF( xml );
			}
			else
			{
				Homologacao_Inutilizacao4.NFeInutilizacao4 nFeInutilizacao4 = new Homologacao_Inutilizacao4.NFeInutilizacao4();
				RelacionarCertObj( nFeInutilizacao4,X509Cert );
				return nFeInutilizacao4.nfeInutilizacaoNF( xml );
			}
		}

		/// <summary>
		/// Faz a consulta da situação da NFe
		/// </summary>
		/// <param name="xml"></param>
		/// <param name="X509Cert"></param>
		/// <returns></returns>
		public override XmlNode ConsultaProtocolo( XmlNode xml,X509Certificate2 X509Cert )
		{
			if( Tipodeambiente == TipodeAmbiente.Producao )
			{
				NFeConsultaProtocolo4.NFeConsultaProtocolo4 nFeConsultaProtocolo4 = new NFeConsultaProtocolo4.NFeConsultaProtocolo4();
				RelacionarCertObj( nFeConsultaProtocolo4,X509Cert );
				return nFeConsultaProtocolo4.nfeConsultaNF( xml );
			}
			else
			{
				Homologacao_NFeConsultaProtocolo4.NFeConsultaProtocolo4 nFeConsultaProtocolo4 = new Homologacao_NFeConsultaProtocolo4.NFeConsultaProtocolo4();
				RelacionarCertObj( nFeConsultaProtocolo4,X509Cert );
				return nFeConsultaProtocolo4.nfeConsultaNF( xml );
			}
		}

		/// <summary>
		/// Gera a carta de correção ou cancelamento da NFe especificada
		/// </summary>
		/// <param name="xml"></param>
		/// <param name="X509Cert"></param>
		/// <returns></returns>
		public override XmlNode CartadeCorrecaoCancelamento( XmlNode xml,X509Certificate2 X509Cert )
		{
			if( Tipodeambiente == TipodeAmbiente.Producao )
			{
				RecepcaoEvento4.NFeRecepcaoEvento4 nFeRecepcaoEvento4 = new RecepcaoEvento4.NFeRecepcaoEvento4();
				RelacionarCertObj( nFeRecepcaoEvento4,X509Cert );
				return nFeRecepcaoEvento4.nfeRecepcaoEvento( xml );
			}
			else
			{
				Homologacao_RecepcaoEvento4.NFeRecepcaoEvento4 nFeRecepcaoEvento4 = new Homologacao_RecepcaoEvento4.NFeRecepcaoEvento4();
				RelacionarCertObj( nFeRecepcaoEvento4,X509Cert );
				return nFeRecepcaoEvento4.nfeRecepcaoEvento( xml );
			}
		}

		public override XmlNode AutorizaNFe( XmlNode xml,X509Certificate2 X509Cert )
		{
			if( Tipodeambiente == TipodeAmbiente.Producao )
			{
				NFeAutorizacao4.NFeAutorizacao4 nFeAutorizacao4 = new NFeAutorizacao4.NFeAutorizacao4();
				RelacionarCertObj( nFeAutorizacao4,X509Cert );
				return nFeAutorizacao4.nfeAutorizacaoLote( xml );
			}
			else
			{
				Homologacao_NFeAutorizacao4.NFeAutorizacao4 nFeAutorizacao4 = new Homologacao_NFeAutorizacao4.NFeAutorizacao4();
				RelacionarCertObj( nFeAutorizacao4,X509Cert );
				return nFeAutorizacao4.nfeAutorizacaoLote( xml );
			}
		}

		public override XmlNode AutorizaRetNFe( XmlNode xml,X509Certificate2 X509Cert )
		{
			if( Tipodeambiente == TipodeAmbiente.Producao )
			{
				NFeRetAutorizacao4.NFeRetAutorizacao4 nFeRetAutorizacao4 = new NFeRetAutorizacao4.NFeRetAutorizacao4();
				RelacionarCertObj( nFeRetAutorizacao4,X509Cert );
				return nFeRetAutorizacao4.nfeRetAutorizacaoLote( xml );
			}
			else
			{
				Homologacao_NFeRetAutorizacao4.NFeRetAutorizacao4 nFeRetAutorizacao4 = new Homologacao_NFeRetAutorizacao4.NFeRetAutorizacao4();
				RelacionarCertObj( nFeRetAutorizacao4,X509Cert );
				return nFeRetAutorizacao4.nfeRetAutorizacaoLote( xml );
			}
		}
	}
}
