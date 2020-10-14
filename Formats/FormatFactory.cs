namespace Formats
{
  public static class FormatFactory
  {
    public static FormatBase GetFormat( string type )
    {
      switch ( type )
      {
        case FormatType.Table:
          return new TableFormat();
        case FormatType.Detailed:
          return new DetailFormat();
        case FormatType.InList:
          return new InListFormat();
        default:
          return new TableFormat();
      }
    }
  }
}
