using ServiceNFe.Entities.ConsultaCadastro;
using ServiceNFe.Entities.ConsultaSituacaoNFe;
using ServiceNFe.Entities.ConsultaStatusServico;
using ServiceNFe.Entities.Eventos;
using ServiceNFe.Entities.InutilizacaoNumeracao;
using ServiceNFe.Entities.NFe;
using ServiceNFe.Enums;
using ServiceNFe.Servicos;
using System;
using System.Globalization;
using System.Threading;

namespace ServiceNFe
{
	class Program
	{
		static void Main( string[] args )
		{
			ConectaWebServiceNFe cws = new ConectaWebServiceNFe( new WebServiceNFeSaoPaulo(),TipodeAmbiente.Homologacao,"SP","35" );

			AutorizaNFe( cws );
		}

		static void AutorizaNFe( ConectaWebServiceNFe cws )
		{
			/* cnpj ou cpf da NFe correspondente a NFe, lembrando que deverá corresponder ao do certificado digital */
			string cnpj = null;
			string cpf = null;
			string ie = null;
			string im = null;
			string numeroNFe = null;

			Ide ide = new Ide( "Venda","55","2",numeroNFe,TipoOperacao.Saida,IdentificadorDestino.Operacao_Interna,"3550308",
								TipoDanfe.Sem_geracao_de_DANFE,TipoEmissao.Emissao_Normal,FinalidadeEmissaoNFe.NFe_Normal,OperacaoConsumidor.Consumidor_Final,
								PresencaComprador.Operacao_nao_Presencial,ProcessoEmissao.EmissaoNFe_com_Aplicativo_contribuinte,"2.2.1.397" );
			EnderEmit enderEmit = new EnderEmit( "Rua da Empresa","99","Complemento da Empresa","Bairro da Empresa","3550308","Sao Paulo","12345678","1122222222" );
			Emit emit = new Emit( cnpj,cpf,"Razao Social da Empresa","Nome Fantasia da Empresa",enderEmit,ie,im,"4751200",RegimeTributario.Regime_Normal );
			EnderDest enderDest = new EnderDest( "RUA DO CLIENTE 1","345",null,"BAIRRO DO CLIENTE 1","3537701","PIACATU","11111111","1122222222" );
			Dest dest = new Dest( cnpj,cpf,null,"Nome da Empresa",enderDest,IndicadorIEDestino.Contribuinte_ICMS,ie,null,null );
			Prod prod = new Prod( "1","SEM GTIN","Etiqueta","48211000","5101","PC",10.000M,10.00000M,"SEM GTIN","PC",10.000M,10.00000M,null,null,null,null,
									IndicaItemTotal.ValorCompoe,"123456","000001" );

			Icms00 icms00 = new Icms00( OrigemMercadoria.Nacional,ModalidadeBasedeCalculoICMS.ValordaOperacao,100.00M,12.00M );
			Icms icms = new Icms( icms00 );
			//Icms10 icms10 = new Icms10( OrigemMercadoria.Nacional,ModalidadeBasedeCalculoICMS.ValordaOperacao,100.00M,12.00M,
			//							ModalidadeBasedeCaloculoSubst_Trib.MargemValorAgregado,13.00M,14.00M,15.00M,16.00M,17.00M );
			//Icms icms = new Icms( icms10 );

			PisOutr pisOutr = new PisOutr( "99",0.00M,0.00M );
			Pis pis = new Pis( pisOutr );
			CofinsOutr cofinsOutr = new CofinsOutr( "99",0.00M,0.00M );
			Cofins cofins = new Cofins( cofinsOutr );

			Imposto imposto = new Imposto( 25.45M,icms,pis,cofins );

			Det det = new Det( prod,imposto );
			IcmsTot icmsTot = new IcmsTot( 200.00M,24.00M,0.00M,0.00M,0.00M,0.00M,0.00M,0.00M,200.00M,0.00M,0.00M,0.00M,0.00M,0.00M,0.00M,0.00M,0.00M,0.00M,200.00M,50.90M );

			Total total = new Total( icmsTot );

			Transporta transporta = new Transporta( "69097228000148",null,"Transportadora","ISENTO",null,"Sao Paulo","SP" );

			Transp transp = new Transp( ModalidadeFrete.PorContadoEmitente,transporta );
			Fat fat = new Fat( "001",200.00M,0.00M,200.00M );
			Dup dup = new Dup( "001",DateTime.Today.ToShortDateString(),66.66M );
			Cobr cobr = new Cobr( fat,dup );
			dup = new Dup( "002",DateTime.Today.ToShortDateString(),66.67M );
			cobr.AddDup( dup );
			dup = new Dup( "003",DateTime.Today.ToShortDateString(),66.67M );
			cobr.AddDup( dup );

			DetPag detPag = new DetPag( IndicaFormadePagamento.Pagamento_a_Prazo, FormadePagamento.BoletoBancario,200.00M );
			Pag pag = new Pag( detPag );
			InfAdic infAdic = new InfAdic( null,"Teste de Dados Adicionais" );
			InfNFe infNFe = new InfNFe( "4.00",ide,emit,dest,det,total,transp,cobr,pag,infAdic );
			infNFe.AddDet( det );

			NFe nFe = new NFe( infNFe );

			/* envio a NFe */
			RetEnviNFe retEnviNFe = cws.AutorizaNFe( nFe,"nfe_v4.00.xsd","enviNFe_v4.00.xsd","1",IndicaSincronismo.ProcessoSincrono );

			/* se o tempo de espera for maior que 5, seguro o programa antes de solicitar o recibo de entrega */
			if( retEnviNFe.infRec.Tempo_Medio > 5 )
				Thread.Sleep( 1000 * retEnviNFe.infRec.Tempo_Medio );

			/* leio o recibo da NFe enviada */
			RetConsReciNFe retConsReciNFe = cws.AutorizaRetNFe( retEnviNFe,"consReciNFe_v4.00.xsd" );
		}

		static void CancelamentodeNFe( ConectaWebServiceNFe cws )
		{
			/* cnpj ou cpf da NFe correspondente a NFe, lembrando que deverá corresponder ao do certificado digital */
			string cnpj = null;
			string cpf = null;

			/* chave e numero do protocolo que terá o cancelamento da NFe, ambos obrigatórios */
			string chaveNFe = null;
			string numeroprotocolo = null;

			Evento Evento = new Evento( "1.00",new InfEvento( cnpj,cpf,chaveNFe,
												 DateTime.Now.ToString( new CultureInfo( "pt-BR" ) ),"110111","1.00",
												 new DetEvento( "1.00","Cancelamento",numeroprotocolo,"Erro de varias coisas inclusive de Correção À ÿ Ç â ô" ) ) );

			RetEnvEvento retEnvEvento = cws.CancelaNFe( Evento,"envEventoCancNFe_v1.00.xsd" );
		}

		static void CartadeCorrecao( ConectaWebServiceNFe cws )
		{
			/* cnpj ou cpf da NFe que se emitirá a carta de correção, lembrando que deverá corresponder ao do certificado digital */
			string cnpj = null;
			string cpf = null;

			/* chave que terá a carta de correção, campo obrigatório */
			string chaveNFe = null;

			Evento Evento = new Evento( "1.00",new InfEvento( cnpj,cpf,chaveNFe,
												 DateTime.Now.ToString( new CultureInfo( "pt-BR" )),"110110","7","1.00",
												 new DetEvento( "1.00","Carta de Correcao","Erro de varias coisas inclusive de Correção À ÿ Ç â ô" ) ) );

			RetEnvEvento retEnvEvento = cws.CartadeCorrecao( Evento,"envCCe_v1.00.xsd" );
		}

		static void ConsultaProtocolo( ConectaWebServiceNFe cws )
		{
			/* Chave que será utilizada para consultar o protocolo de autorização da NFe */
			string chaveNFe = null;

			ConsSitNFe consSitNFe = new ConsSitNFe( "4.00",chaveNFe );
			RetConsSitNFe retConsSitNFe = cws.ConsultaProtocolo( consSitNFe,"consSitNFe_v4.00.xsd" );
		}
		static void InutilizaNumeracao( ConectaWebServiceNFe cws )
		{
			/* cnpj que será utilizado para inutilizar uma númeração da NFe, este deverá corresponder ao cnpj do certificado digital */
			string cnpj = null;

			InutNFe inutNFe = new InutNFe( new InfInut( "20",cnpj,"55",3,6,6,"Inutilização para teste" ),"4.00" );
			RetInutNFe retInutNFe = cws.InutilizaNumeracao( inutNFe,"inutNFe_v4.00.xsd" );
		}

		static void consultaStatusServico( ConectaWebServiceNFe cws )
		{
			ConsStatServ consStatServ = new ConsStatServ( "4.00" );
			RetConsStatServ retConsStatServ = cws.ConsultaStatus( consStatServ );
		}

		static void consultacadastro( ConectaWebServiceNFe cws )
		{
			/* inserir o cpf ou cnpj ou a ie a ser consultados somente um deles poderá ser utilizado, dependendo do estado não tem consulta por cpf */
			string cpf = null;
			string cnpj = null;
			string ie = null;

			RetConsCad retConsCad = cws.ConsultaCadastro( new ConsCad( new InfCons( cpf,cnpj,ie ),"2.00" ) );
		}
	}
}
