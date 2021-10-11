namespace Localization.Exception
{
  public class LocalizeException : System.Exception
  {
    public readonly string key;
    
    public LocalizeException(string message, string wrongKey) : base(message) => 
      key = wrongKey;
  }
}