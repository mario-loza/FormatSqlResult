using System;
using System.Collections.Generic;

namespace Formats
{
  public class DetailFormat : FormatBase
  {
    public override bool UsesLineNumber() { return false; }

    public override string Process( string[] lines, bool commented, bool withLineNumbers )
    {
      string result = string.Empty;
      string prefix = commented ? "--" : string.Empty;

      var matrix = GetMatrix( lines );

      //Transpose Matrix
      string[,] transMatrix = new string[NrCells, NrLines];
      for ( int i = 0; i < NrCells; i++ )
      {
        for ( int j = 0; j < NrLines; j++ )
        {
          transMatrix[ i, j ] = matrix[ j, i ];
        }
      }

      List<int> list = new List<int>();
      for ( int i = 0; i < NrLines; i++ )
      {
        list.Add( 0 );
      }

      for ( int i = 0; i < NrCells; i++ )
      {
        for ( int j = 0; j < NrLines; j++ )
        {
          if ( transMatrix[ i, j ].Length > list[ j ] )
          {
            list[ j ] = transMatrix[ i, j ].Length;
          }
        }
      }

      for ( int i = 0; i < NrCells; i++ )
      {
        string detailData = "";
        for ( int j = 0; j < NrLines; j++ )
        {
          if ( j == 0 )
          {
            detailData += transMatrix[ i, j ].PadLeft( list[ j ] ) + ": ";
          }
          else
          {
            detailData += transMatrix[ i, j ].PadRight( list[ j ] ) + " | ";
          }
        }

        detailData = detailData.Substring( 0, detailData.Length - 3 );

        result += prefix + detailData + Environment.NewLine;
      }

      return result;
    }
  }
}
