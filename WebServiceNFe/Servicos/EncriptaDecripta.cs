using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ServiceNFe.Servicos
{
	class EncriptaDecripta
	{
		public byte[] Chave
		{
			get; set;
		}
		public byte[] Vetor
		{
			get; set;
		}
		public Aes Algoritmo
		{
			get; set;
		}

		public EncriptaDecripta( byte[] chave )
		{
			Chave = chave;
			Vetor = new byte[] { 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16 };
			Algoritmo = Aes.Create();
		}

		public EncriptaDecripta( byte[] chave,byte[] vetor )
		{
			Chave = chave;
			Vetor = vetor;
			Algoritmo = Aes.Create();
		}

		public string Encriptar( string texto )
		{
			byte[] textoEncriptografado;

			byte[] textoemBytes = Encoding.UTF8.GetBytes( texto );

			MemoryStream memoriaCorrente = new MemoryStream();
			using( CryptoStream criptoCorrente = new CryptoStream( memoriaCorrente,Algoritmo.CreateEncryptor( Chave,Vetor ),CryptoStreamMode.Write ) )
			{
				criptoCorrente.Write( textoemBytes,0,textoemBytes.Length );
				criptoCorrente.FlushFinalBlock();
				textoEncriptografado = memoriaCorrente.ToArray();
			}
			Algoritmo.Dispose();
			return Convert.ToBase64String( textoEncriptografado );
		}

		public string Desencriptar( string textocriptografado )
		{
			var textoEncriptadoemBytes = Convert.FromBase64String( textocriptografado );
			byte[] symUnencryptedData;

			MemoryStream memoriaCorrente = new MemoryStream();
			using( CryptoStream criptoCorrente = new CryptoStream( memoriaCorrente,Algoritmo.CreateDecryptor( Chave,Vetor ),CryptoStreamMode.Write ) )
			{
				criptoCorrente.Write( textoEncriptadoemBytes,0,textoEncriptadoemBytes.Length );
				criptoCorrente.FlushFinalBlock();
				symUnencryptedData = memoriaCorrente.ToArray();
			}
			Algoritmo.Dispose();
			return System.Text.Encoding.Default.GetString( symUnencryptedData );
		}

	}
}
