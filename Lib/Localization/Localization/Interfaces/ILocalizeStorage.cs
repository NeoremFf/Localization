using System.Collections.Generic;

namespace Localization.Interfaces
{
  public interface ILocalizeStorage
  {
    void   Set(Dictionary<string, string[]> storage);
    string Get(string key, Language.Language language);
    bool   Has(string key);
  }
}