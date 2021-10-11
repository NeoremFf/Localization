using Localization.Exception;
using Localization.Manager;

namespace Localization
{
  // ReSharper disable once IdentifierTypo
  public static class Localizer
  {
    public static string Localize(this string key)
    {
      try
      {
        if (!LocalizeManager.Storage.Has(key))
          throw new LocalizeException("Can not get value for given key.", key);
        
        return LocalizeManager.Storage.Get(key, LocalizeManager.Language.Current);
      }
      catch (LocalizeException e)
      {
        LocalizeManager.Error.Display($"{e.Message}\nKey: {e.key}\n{e.StackTrace}" );

        return key;
      }
    }
  }
}