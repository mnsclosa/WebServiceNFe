using System.Globalization;

/// <summary>
/// Usei o namespace System e não acompanhei o diretório onde se encontra a classe para ficar mais fácil a utilização desta classe
/// dentro do programa, pois o namespace System é sempre carregado.
/// </summary>
namespace System
{
	public static class Extensoes
	{
		#region string
		/// <summary>
		/// Retira o acento de uma string
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static string RetiraAcento( this string str )
		{
			string strtmp = null;

			if( string.IsNullOrEmpty( str ) == false )
			{
				string[] caracteracentuado = new string[256];
				caracteracentuado['é'] = "e";
				caracteracentuado['ú'] = "u";
				caracteracentuado['í'] = "i";
				caracteracentuado['ó'] = "o";
				caracteracentuado['á'] = "a";
				caracteracentuado['É'] = "E";
				caracteracentuado['Ú'] = "U";
				caracteracentuado['Í'] = "I";
				caracteracentuado['Ó'] = "O";
				caracteracentuado['Á'] = "A";
				caracteracentuado['è'] = "e";
				caracteracentuado['ù'] = "u";
				caracteracentuado['ì'] = "i";
				caracteracentuado['ò'] = "o";
				caracteracentuado['à'] = "a";
				caracteracentuado['È'] = "E";
				caracteracentuado['Ù'] = "U";
				caracteracentuado['Ì'] = "I";
				caracteracentuado['Ò'] = "O";
				caracteracentuado['À'] = "A";
				caracteracentuado['õ'] = "o";
				caracteracentuado['ã'] = "a";
				caracteracentuado['ñ'] = "n";
				caracteracentuado['Õ'] = "O";
				caracteracentuado['Ã'] = "A";
				caracteracentuado['Ñ'] = "N";
				caracteracentuado['ê'] = "e";
				caracteracentuado['û'] = "u";
				caracteracentuado['î'] = "i";
				caracteracentuado['ô'] = "o";
				caracteracentuado['â'] = "a";
				caracteracentuado['Ê'] = "E";
				caracteracentuado['Û'] = "U";
				caracteracentuado['Î'] = "I";
				caracteracentuado['Ô'] = "O";
				caracteracentuado['Â'] = "A";
				caracteracentuado['ë'] = "e";
				caracteracentuado['ÿ'] = "y";
				caracteracentuado['ü'] = "u";
				caracteracentuado['ï'] = "i";
				caracteracentuado['ö'] = "o";
				caracteracentuado['ä'] = "a";
				caracteracentuado['Ë'] = "E";
				caracteracentuado['Ü'] = "U";
				caracteracentuado['Ï'] = "I";
				caracteracentuado['Ö'] = "O";
				caracteracentuado['Ä'] = "A";
				caracteracentuado['ç'] = "c";
				caracteracentuado['Ç'] = "C";

				for( int conta = 0;conta < str.Length;conta++ )
				{

					if( str[conta] > 0x7E )
						strtmp += caracteracentuado[str[conta]];
					else
						strtmp += str[conta];
				}
			}
			return strtmp;
		}

		/// <summary>
		/// Cria a Data no formato UTC exigido pela NFe no formato Texto
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static string DataUtc( this string str )
		{
			DateTime dt = Convert.ToDateTime( str,new CultureInfo("pt-BR" ));
			return dt.Year + "-" +
					dt.Month.ToString( new CultureInfo( "pt-BR" ) ).PadLeft( 2,'0' ) + "-" +
					dt.Day.ToString( new CultureInfo( "pt-BR" )).PadLeft( 2,'0' ) + "T" +
					dt.Hour.ToString( new CultureInfo( "pt-BR" )).PadLeft( 2,'0' ) + ":" +
					dt.Minute.ToString( new CultureInfo( "pt-BR" )).PadLeft( 2,'0' ) + ":00-03:00";
		}

		/// <summary>
		/// Cria a Data no formato UTC exigido pela NFe no formato Texto
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static string DataAAAAMMDD( this string str )
		{
			DateTime dt = Convert.ToDateTime( str,new CultureInfo( "pt-BR" ) );
			return dt.Year + "-" +
					dt.Month.ToString( new CultureInfo( "pt-BR" ) ).PadLeft( 2,'0' ) + "-" +
					dt.Day.ToString( new CultureInfo( "pt-BR" ) ).PadLeft( 2,'0' );
		}

		/// <summary>
		/// Faz o Arredondamento de um numero que esta como string em decimais.
		/// </summary>
		/// <param name="val">Valor a ser arredondado.</param>
		/// <param name="casasdecimais">Quantidade de casas decimais</param>
		/// <returns></returns>
		public static string Round( this string val,int casasdecimais )
		{
			if( string.IsNullOrEmpty( val ) == false )
				return Convert.ToDecimal( val,new CultureInfo( "pt-BR" ) ).ToString( "N" + casasdecimais,CultureInfo.CreateSpecificCulture( "en-US" ) );
			else
				return null;
		}
		#endregion
		#region decimal
		/// <summary>
		/// Faz o Arredondamento de numeros decimais.
		/// </summary>
		/// <param name="val">Valor a ser arredondado.</param>
		/// <param name="casasdecimais">Quantidade de casas decimais</param>
		/// <returns></returns>
		public static decimal Round( this decimal val,int casasdecimais )
		{
			return Math.Round( val,casasdecimais );
		}
		#endregion
	}
}
