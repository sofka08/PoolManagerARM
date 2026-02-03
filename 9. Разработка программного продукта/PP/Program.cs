using System;
using System.Windows.Forms;
using PP;

namespace PP
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Authorization authForm = new Authorization();
            Application.Run(authForm);
        }
    }
}
public static class AppLogic
{
    // Тщательная проверка: можно ли оформить новый абонемент?
    public static bool CanPurchaseNewAbonement(int activeSubscriptionsCount, out string errorMessage)
    {
        if (activeSubscriptionsCount > 0)
        {
            errorMessage = "У клиента уже есть действующий абонемент. Нельзя оформить второй, пока не истечет срок текущего.";
            return false;
        }

        errorMessage = string.Empty;
        return true;
    }

    // Проверка статуса абонемента по дате и количеству визитов
    public static string GetSubscriptionStatus(DateTime expiryDate, int remainingVisits)
    {
        if (remainingVisits <= 0) return "Визиты исчерпаны";
        if (expiryDate < DateTime.Today) return "Истек по дате";
        return "Активен";
    }
}
