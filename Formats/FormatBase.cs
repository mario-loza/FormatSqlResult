using System.Linq;

namespace Formats
{
  public abstract class FormatBase
  {
    protected int NrLines;
    protected int NrCells;

    protected FormatBase()
    {
      NrLines = 0;
      NrCells = 0;
    }

    public abstract string Process( string[] lines, bool commented, bool withLineNumbers );

    public abstract bool UsesLineNumber();
    public string[,] GetMatrix( string[] lines )
    {
      NrLines = lines.Length;
      NrCells = lines[ 0 ].Split( new char[] { '\t' } ).Count<string>();

      string[,] matrix = new string[NrLines, NrCells];
      for ( int i = 0; i < NrLines; i++ )
      {
        string text = lines[ i ];
        string[] currentRow = text.Split( new char[] { '\t' } );
        for ( int j = 0; j < NrCells; j++ )
        {
          matrix[ i, j ] = currentRow[ j ].Trim();
        }
      }

      return matrix;
    }
  }
}
