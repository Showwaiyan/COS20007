using NUnit.Framework;
using NUnit.Framework.Legacy;
using SwinAdventure;

namespace UnitTests
{
    [TestFixture]
    public class TestIndentifiableObject
    {
        private IndentifiableObject testObject = new IndentifiableObject(new string[] { "105293041", "Show Wai Yan", "Miss Siti" });
        private IndentifiableObject testObjectEmpty = new IndentifiableObject(new string[] { });

        [Test]
        public void TestAreYou()
        {

            string testString = "105293041";

            ClassicAssert.True(testObject.AreYou(testString));
        }

        [Test]
        public void TestNotAreYou()
        {
            string testString = "1O5293O41";
            ClassicAssert.False(testObject.AreYou(testString));
        }

        [Test]
        public void TestCaseSensitive()
        {
            string testString = "inTI";
            testObject.AddIdentifier(testString);
            ClassicAssert.True(testObject.AreYou(testString));
        }

        [Test]
        public void TestFirstID()
        {
            string firstIndentifier = "105293041";
            ClassicAssert.AreEqual(firstIndentifier, testObject.FirstId);
        }

        [Test]
        public void TestFirstIdWithNoIDs()
        {
            string noIndentifier = "";
            ClassicAssert.AreEqual(noIndentifier, testObjectEmpty.FirstId);
        }

        [Test]
        public void TestAddID()
        {
            string[] testStrings = { "JavaScript", "Linux", "C#", "Rust", "DotNet" };

            foreach (string s in testStrings)
            {
                testObject.AddIdentifier(s);
            }

            foreach (string s in testStrings)
            {
                ClassicAssert.True(testObject.AreYou(s));
            }
        }

        [Test]
        public void TestPrivilegeEscalation()
        {
            string tutorialID = "105293041";
            string lastFourDigitStudentID = "3041";
            testObject.PrivilegeEscalation(lastFourDigitStudentID);

            ClassicAssert.AreEqual(tutorialID, testObject.FirstId);
        }

    }
}
