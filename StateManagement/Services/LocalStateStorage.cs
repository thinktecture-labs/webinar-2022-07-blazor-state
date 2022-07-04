using Blazored.LocalStorage;
using Fluxor.Persist.Storage;

namespace StateManagement.Services;

public class LocalStateStorage : IStringStateStorage
{
    private ILocalStorageService _localStorage { get; set; }

    public LocalStateStorage(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public async ValueTask<string> GetStateJsonAsync(string statename)
    {
        return await _localStorage.GetItemAsStringAsync(statename);
    }

    public async ValueTask StoreStateJsonAsync(string statename, string json)
    {
        await _localStorage.SetItemAsStringAsync(statename, json);
    }
}
