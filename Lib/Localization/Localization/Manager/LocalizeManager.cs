using Localization.Exception;
using Localization.Interfaces;

namespace Localization.Manager
{
  public static class LocalizeManager
  {
    private static ILocalizeStorage          _storage;
    private static ILocalizeLanguage         _language;
    private static ILocalizeExceptionDisplay _errorDisplay;

    private static bool _initialized;

    private static bool _canRewrite = true;
    
    public static void Init( 
      ILocalizeStorage          storage,
      ILocalizeLanguage         language,
      ILocalizeExceptionDisplay errorDisplay)
    {
      if (!_canRewrite)
        throw new LocalizeSecureManagerException("You try to re write Manager but it mark as security (not rewritable).");
      
      _storage      = storage;
      _language     = language;
      _errorDisplay = errorDisplay;

      _initialized  = true;
    }

    public static void SecurityInit(
      ILocalizeStorage storage,
      ILocalizeLanguage language,
      ILocalizeExceptionDisplay errorDisplay)
    {
      _canRewrite = false;
      
      Init(storage, language, errorDisplay);
    }

    internal static ILocalizeStorage Storage
    {
      get
      {
        if (!_initialized)
          throw new LocalizeManagerException("Manager not initialized but you try to get access to data.");
        
        return _storage;
      }
    }

    internal static ILocalizeLanguage Language
    {
      get
      {
        if (!_initialized)
          throw new LocalizeManagerException("Manager not initialized but you try to get access to data.");
        
        return _language;
      }
    }

    internal static ILocalizeExceptionDisplay Error
    {
      get
      {
        if (!_initialized)
          throw new LocalizeManagerException("Manager not initialized but you try to get access to data.");
        
        return _errorDisplay;
      }
    }
  }
}