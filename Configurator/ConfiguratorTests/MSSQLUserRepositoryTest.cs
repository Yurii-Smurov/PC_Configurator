using System.Diagnostics;
using Configurator;
using Configurator.Models.Components;
using Configurator.Models.PCBuider;
using Configurator.Models.UserModels;
using Configurator.Repositories.MSSQL;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace ConfiguratorTests
{
    [TestFixture]
    public class MSSQLUserRepositoryTest
    {
        private SQLUserRepository? _repos;
        private PC? _pc;
        private User? _user;
        [SetUp]
        public void SetUp()
        {
            Debug.WriteLine("Test Initialize");
            _repos = new SQLUserRepository(new UserDbContext());
            _pc = new PCBuilder()
            .AddComponent(new Processor())
            .AddComponent(new GraphicsCard())
            .AddComponent(new Motherboard())
            .AddComponent(new PowerUnit())
            .AddComponent(new ComputerCase())
            .AddComponent(new Memory())
            .AddComponent(new SSD())
            .AddComponent(new AirCoolingSystem())
            .Build();
            _user = new User("TestUser", "TestPassword", "testMail@test.com");
        }

        // Тест добавления пользователя в БД
        [Test]
        public void AddUser_ShouldAddUserToDatabase()
        {
            // Act
            _repos.AddUser(_user);

            // Assert
            var addedUser = _repos.GetUserByUsername("TestUser");
            ClassicAssert.IsNotNull(addedUser);
        }

        // Тест получения данных о существующем пользователе из БД по имени
        [Test]
        public void GetUserByUsername_ReturnsUser_WhenUsernameExists()
        {
            string username = "TestUser1";
            _repos.AddUser(new User("TestUser1", "TestPassword", "TestMail@test.com"));
            // Act
            var user = _repos.GetUserByUsername(username);

            // Assert
            ClassicAssert.IsNotNull(user);
            ClassicAssert.AreEqual(username, user.Username);
            Debug.WriteLine($"expected: {username}, actual: {user.Username}");
        }

        // Тест получения данных о несуществующем пользователе из БД по имени
        [Test]
        public void GetUserByUsername_ReturnsNull_WhenUsernameDoesNotExist()
        {
            // Act
            _user = _repos.GetUserByUsername("nonexistentuser");

            // Assert
            ClassicAssert.IsNull(_user);
        }

        // Тест добавления ПК к существующему пользователю
        [Test]
        public void AddPC_AddsPcForUser_WhenUserExists()
        {
            _repos.AddUser(_user);
            UserSession.GetInstance().CurrentUser = _repos.GetUserByUsername(_user.Username);
            // Act
            _repos.AddPC(_pc, UserSession.GetInstance().CurrentUser);
            _repos.RefreshUserSession();
            // Assert
            var addedPc = UserSession.GetInstance().CurrentUser.PCs.FirstOrDefault(p => p.PCId == 1);
            ClassicAssert.IsNotNull(addedPc);
            Debug.WriteLine("ПК найден");
            ClassicAssert.AreEqual(UserSession.GetInstance().CurrentUser.UserId, addedPc.User.UserId);
            Debug.WriteLine("ПК принадлежит заданному пользователю");
        }
    }

}