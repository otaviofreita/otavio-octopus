using System;

public static class PlayerObserverManager
{
    public static event Action<int> OnMoedaCollected;
    public static event Action<int> OnEstrelaCollected;

    public static void NotifyMoedaCollected(int playerIndex)
    {
        OnMoedaCollected?.Invoke(playerIndex);
    }

    public static void NotifyEstrelaCollected(int playerIndex)
    {
        OnEstrelaCollected?.Invoke(playerIndex);
    }
}