using Microsoft.VisualStudio.TestTools.UnitTesting;
using PP;

namespace PP.Test
{
    [TestClass]
    public class AbonementBusinessTests
    {
        [TestMethod]
        public void Test_BlockPurchase_WhenAlreadyHasActiveSubscription()
        {
            // Arrange: у клиента уже есть 1 активный абонемент
            int activeCount = 1;
            string error;

            // Act: пытаемс€ проверить возможность покупки
            bool canBuy = AppLogic.CanPurchaseNewAbonement(activeCount, out error);

            // Assert: система должна запретить покупку
            Assert.IsFalse(canBuy);
            Assert.AreEqual("” клиента уже есть действующий абонемент. Ќельз€ оформить второй, пока не истечет срок текущего.", error);
        }

        [TestMethod]
        public void Test_AllowPurchase_WhenNoActiveSubscriptions()
        {
            // Arrange: у клиента 0 активных абонементов
            int activeCount = 0;
            string error;

            // Act
            bool canBuy = AppLogic.CanPurchaseNewAbonement(activeCount, out error);

            // Assert: система должна разрешить
            Assert.IsTrue(canBuy);
            Assert.AreEqual(string.Empty, error);
        }

        [TestMethod]
        public void Test_Status_ExpiredByVisits()
        {
            // ѕроверка: если визитов 0, статус должен быть "»счерпаны", даже если дата еще ок
            string status = AppLogic.GetSubscriptionStatus(DateTime.Today.AddDays(10), 0);
            Assert.AreEqual("¬изиты исчерпаны", status);
        }
    }
}
