using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConectaWebServiceNFe.Servicos
{
	interface IWebService
	{
		delegate void Delegate_RelacionarCertObj( object pObjeto,X509Certificate2 X509Cert );
		void WebConsultaCadastroProducao( XmlNode xml,X509Certificate2 X509Cert );
	}
}
