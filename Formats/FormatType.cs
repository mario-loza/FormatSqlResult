using System.Collections.Generic;

namespace Formats
{
  public static class FormatType
  {
    public const string Table = "Table";
    public const string Detailed = "Detailed";
    public const string InList = "In List";

    public static List<string> GetTypeList()
    {
      return new List<string>() { Table, Detailed, InList };
    }
  }
}
