using System.Diagnostics;
using System.Runtime.CompilerServices;
using Configurator;
using Configurator.Models.Components;
using Configurator.Models.PCBuider;
using Configurator.Models.UserModels;
using Configurator.Repositories.MSSQL;
using Microsoft.EntityFrameworkCore;

namespace ConfiguratorTests
{
    [TestClass]
    public class MSSQLUserRepositoryTest
    {
        private SQLUserRepository? _repos;
        private PC? _pc;
        private User? _user;
        private UserDbContext? _db;

        [TestInitialize]
        public void TestInitialize()
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
        [TestMethod]
        public void AddUser_ShouldAddUserToDatabase()
        {
            // Act
            _repos.AddUser(_user);

            // Assert
            var addedUser = _repos.GetUserByUsername("TestUser");
            Assert.IsNotNull(addedUser);
        }

        // Тест получения данных о существующем пользователе из БД по имени
        [TestMethod]
        public void GetUserByUsername_ReturnsUser_WhenUsernameExists()
        {
            string username = "TestUser1";
            _repos.AddUser(new User("TestUser1", "TestPassword", "TestMail@test.com"));
            // Act
            var user = _repos.GetUserByUsername(username);

            // Assert
            Assert.IsNotNull(user);
            Assert.AreEqual(username, user.Username);
            Debug.WriteLine($"expected: {username}, actual: {user.Username}");
        }

        // Тест получения данных о несуществующем пользователе из БД по имени
        [TestMethod]
        public void GetUserByUsername_ReturnsNull_WhenUsernameDoesNotExist()
        {
            // Act
            _user = _repos.GetUserByUsername("nonexistentuser");

            // Assert
            Assert.IsNull(_user);
        }

        // Тест добавления ПК к существующему пользователю
        [TestMethod]
        public void AddPC_AddsPcForUser_WhenUserExists()
        {
            _repos.AddUser(_user);
            UserSession.GetInstance().CurrentUser = _repos.GetUserByUsername(_user.Username);
            // Act
            _repos.AddPC(_pc, UserSession.GetInstance().CurrentUser);
            _repos.RefreshUserSession();
            // Assert
            var addedPc = UserSession.GetInstance().CurrentUser.PCs.FirstOrDefault(p => p.PCId == 1);
            Assert.IsNotNull(addedPc);
            Debug.WriteLine("ПК найден");
            Assert.AreEqual(UserSession.GetInstance().CurrentUser.UserId, addedPc.User.UserId);
            Debug.WriteLine("ПК принадлежит заданному пользователю");
        }
    }

}