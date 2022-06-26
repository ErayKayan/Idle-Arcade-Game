using System;

public class EventBroker
{
    public static event Action UpdateMoneyUI;
    public static void UpdateMoney()
    {
        UpdateMoneyUI?.Invoke();
    }
}

