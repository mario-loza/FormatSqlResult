using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Formats
{
  public class InListFormat : FormatBase
  {
    public override bool UsesLineNumber() { return false; }

    public override string Process( string[] lines, bool commented, bool withLineNumbers = false)
    {
      string prefix = commented ? "--" : string.Empty;
      string result = prefix + " IN (";

      foreach ( var line in lines )
      {
        if (line.Trim() != string.Empty)
          result += " " + line.Trim() + ",";
      }
    
      return result.Substring(0,result.Length-1)+ " ) ";
    }
  }
}
