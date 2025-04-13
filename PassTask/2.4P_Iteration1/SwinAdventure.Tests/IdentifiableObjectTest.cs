using Xunit;
using SwinAdventure;

namespace SwinAdventure.Tests
{
    public class IndentifiableObjectTest
    {
        private IndentifiableObject testObject = new IndentifiableObject(new string[] { "105293041", "Show Wai Yan", "Miss Siti" });
        private IndentifiableObject testObjectEmpty = new IndentifiableObject(new string[] { });

        [Fact]
        public void TestAreYou()
        {

            string testString = "105293041";

            Assert.True(testObject.AreYou(testString));
        }

        [Fact]
        public void TestNotAreYou()
        {
            string testString = "1O5293O41";
            Assert.False(testObject.AreYou(testString));
        }

        [Fact]
        public void TestCaseSensitive()
        {
            string testString = "inTI";
            testObject.AddIdentifier(testString);
            Assert.True(testObject.AreYou(testString));
        }

        [Fact]
        public void TestFirstID()
        {
            string firstIndentifier = "105293041";
            Assert.Equal(firstIndentifier, testObject.FirstId);
        }

        [Fact]
        public void TestFirstIdWithNoIDs()
        {
            string noIndentifier = "";
            Assert.Equal(noIndentifier, testObjectEmpty.FirstId);
        }

        [Fact]
        public void TestAddID()
        {
            string[] testStrings = { "JavaScript", "Linux", "C#", "Rust", "DotNet" };

            foreach (string s in testStrings)
            {
                testObject.AddIdentifier(s);
            }

            foreach (string s in testStrings)
            {
                Assert.True(testObject.AreYou(s));
            }
        }

        [Fact]
        public void TestPrivilegeEscalation()
        {
            string tutorialID = "C1";
            string lastFourDigitStudentID = "3041";
            testObject.PrivilegeEscalation(lastFourDigitStudentID);

            Assert.Equal(tutorialID, testObject.FirstId);
        }

    }
}
