using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formats
{
  public class TableFormat: FormatBase 
  {

    public override bool UsesLineNumber() { return true; }

    public override string Process(string[] lines, bool commented, bool withLineNumbers)
    {
      string result = string.Empty;
      string prefix = commented ? "--" : string.Empty;
     
      var matrix = GetMatrix(lines);

      List<int> list = new List<int>();
      for (int i = 0; i < NrCells; i++)
      {
        list.Add(0);
      }
      for (int i = 0; i < NrLines; i++)
      {
        for (int j = 0; j < NrCells; j++)
        {
          if (matrix[i, j].Length > list[j])
          {
            list[j] = matrix[i, j].Length;
          }
        }
      }

      int totalWidth = list.Sum() + list.Count * 3 + 1;
      string separator = (withLineNumbers ? " " : "") + "=".PadRight(totalWidth, '=') + Environment.NewLine;

      //Header
      result += prefix + separator;
      for (int i = 0; i < 1; i++)
      {
        string line = "| ";
        for (int j = 0; j < NrCells; j++)
        {
          line = line + matrix[i, j].PadRight(list[j]) + " | ";
        }

        result = result + prefix + (withLineNumbers ? " " : "" ) + line.TrimEnd(new char[0]) + Environment.NewLine;
      }
      result += prefix + separator;

      //Body
      int bodyStart = 1;

      for (int i = bodyStart; i < NrLines; i++)
      {
        string text2 = "| ";
        for (int j = 0; j < NrCells; j++)
        {
          text2 = text2 + matrix[i, j].PadRight(list[j]) + " | ";
        }

        result = result + prefix + (!withLineNumbers ? "" : i < 1 ? " " : Convert.ToString(i)) + text2.TrimEnd(new char[0]) + Environment.NewLine;

      }

     //footer
        result += prefix + separator;

      return result;
    }
    
  }
}
