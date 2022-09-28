using DixitOnline.Business.Services;
using DixitOnline.DataAccess;
using DixitOnline.Models.RoomData;
using DixitOnline.ServiceResulting;
using DixitOnline.UnitTests.Utilities;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;

namespace DixitOnline.UnitTests.Business
{
    public class RoomServiceTests
    {
        private Mock<IGenericRepository<RoomModel>> _repo;
        private Mock<IConfiguration> _config;

        [SetUp]
        public void Setup()
        {
            _config = new Mock<IConfiguration>();
            _repo = new Mock<IGenericRepository<RoomModel>>();

            MockConfigurationSetup.Setup(_config);
        }

        [Test]
        public void GenerateRoomCode_GeneratesNewCodeSuccessfully()
        {
            var result = ArrangeAndActRoomCodeGenerating(new GenericServiceResult<int?>(1).Success())
                    as ServiceResult<string>;

            Assert.IsFalse(string.IsNullOrEmpty(result!.Value));
        }

        [Test]
        public void GenerateRoomCode_GeneratesFailIfRepoFailed()
        {
            var result = ArrangeAndActRoomCodeGenerating(new GenericServiceResult<int?>(1).Fail());

            Assert.IsFalse(result.IsSuccessful);
        }

        [Test]
        public void GenerateRoomCode_GeneratesRandomNumberIfNoRoomsFound()
        {
            _repo
                .Setup(x => x.Max(r => r.RoomId))
                .Returns(Task.FromResult(new GenericServiceResult<int?>(null).Success()));
            var sut = GetNewSut();

            void action() => sut.GenerateRoomCode();

            Assert.DoesNotThrow(action);
        }

        private RoomService GetNewSut()
            => new RoomService(_repo.Object, _config.Object);

        private AbstractServiceResult ArrangeAndActRoomCodeGenerating(AbstractServiceResult repoResult)
        {
            _repo
                .Setup(x => x.Max(r => r.RoomId))
                .Returns(Task.FromResult(repoResult));
            var sut = GetNewSut();

            return sut.GenerateRoomCode();
        }
    }
}
