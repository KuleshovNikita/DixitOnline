using Microsoft.Extensions.Configuration;
using Moq;

namespace DixitOnline.UnitTests.Utilities
{
    public static class MockConfigurationSetup
    {
        public static void Setup(Mock<IConfiguration> mockConfig)
        {
            mockConfig
                .Setup(x => x.GetSection("EnvironmentConstants:RoomCodeLength").Value)
                .Returns("15");
        }
    }
}
