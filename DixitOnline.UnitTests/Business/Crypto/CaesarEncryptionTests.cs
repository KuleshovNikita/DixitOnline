using DixitOnline.Business.Crypto;
using NUnit.Framework;

namespace DixitOnline.UnitTests.Business.Crypto
{
    public class CaesarEncryptionTests
    {
        private readonly CaesarEncryption _encryption = new CaesarEncryption();

        [Test]
        public void CreatesNewKey_InRightFormat()
        {
            var roomCode = _encryption.Encrypt("123456789101112");

            Assert.IsFalse(string.IsNullOrEmpty(roomCode));
            Assert.IsTrue(roomCode.Length == 16);
            Assert.IsTrue(roomCode.Last() == '=');
        }

        [Test]
        public void CreatesDifferentKeys_ForSameValue()
        {
            var keysCount = 3;
            var key = "123456789101112";
            var results = new List<string>();

            for(int i = 0; i < keysCount; i++)
            {
                results.Add(_encryption.Encrypt(key));
            }

            Assert.IsTrue(results.Distinct().Count() == keysCount);
        }
    }
}
