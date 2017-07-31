namespace Task01Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Configuration;
    using System.Data.Common;

    using Task01;


	[TestClass]
    public class OrderDALTest
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private static DbProviderFactory factory = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["DefaultConnection"].ProviderName);
        //библиотека толком не подключается
        //пришлось скинуть файлы в тестовый проект
		//todo pn а чего ты хотел, если у тебя классы в библиотеки были internal?
        private OrdersDAL DAL = new OrdersDAL(factory, connectionString);

        [TestMethod]
        public void Test_Inserting1()
        {
            Order ord = new Order(null, 1, 1, 12);
            DAL.Insert(ord);

        }
    }
}
