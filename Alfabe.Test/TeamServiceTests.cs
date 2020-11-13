using Alfabe.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver.Core.Configuration;
using System.Collections.Generic;

namespace Alfabe.Test
{
    [TestClass]
    public class TeamServiceTests
    {
        private TeamService service;
        [TestInitialize]
        public void Setup()
        {
            IMongoDBSettings settings = new MongoDBSettings
            {
                ConnectionString = "mongodb://localhost:27017",
                Database = "NBADatabase",
                Collection = "teams"

            };
            service = new TeamService(settings);
        }
        [TestMethod]
        public void GetAll_Should_Return_Teams()
        {
         
            List<Team> teams = service.GetAll();
            Assert.AreNotEqual(0, teams.Count);
        }
        [TestMethod]
        public void GetSingle_Should_Any_Team_By_Id()
        {
            string id = "5fad3e81604e3162edb44f08";
            Team team = service.GetSingle(id);
            Assert.AreNotEqual(null, team);
            Assert.AreEqual("Hawks", team.Name);
        }
        [TestMethod]
        public void Create_Should_Insert_New_Team()
        {
            Team team = new Team
            {
                Name = "Los Angeles",
                Region ="Lakers",
                Abbrevation = "LA",
                Popularity = 10
            };
            var inserted = service.Create(team);
            Assert.AreNotEqual(0, inserted.Id);
            Assert.AreEqual(24, inserted.Id.Length);
        }
        [TestMethod]
        public void Delete_Should_Remove_Team()
        {
            var id = "5fae68478d1a68abd4db5e26";
            var deletedCount = service.Delete(id);
            Assert.AreEqual(1, deletedCount);
        }
        [TestMethod]
        public void Update_Should_Change_Info()
        {
            string id = "5fae68478d1a68abd4db5e26";
            Team currentInfo = new Team
            {
                Id = "5fae68478d1a68abd4db5e26",
                Name = "UpdatedLakers",
            };
            long updatedCount = service.Update(id, currentInfo);
            Assert.AreEqual(1, updatedCount);
        }
    }
}
