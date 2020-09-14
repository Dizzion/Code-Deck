using System;
using CodeDeckAPI.Models;
using Xunit;

namespace CodeDeckAPI.Tests
{
    public class CodeDeckTests : IDisposable
    {
        CodeCard testCodeCard;

        public CodeDeckTests()
        {
            testCodeCard = new CodeCard
            {
                Challenge = "Challenging",
                JavaAnswer = "Answer",
                JavaScriptAnswer = "Answer",
                PythonAnswer = "Answer",
                CAnswers = "Answer"
            };
        }
        public void Dispose()
        {
            testCodeCard = null;
        }
        [Fact]
        public void CanChangeChallenge()
        {
            //Arrange

            //Act
            testCodeCard.Challenge = "Execute Unit Tests";
            //Assert
            Assert.Equal("Execute Unit Tests", testCodeCard.Challenge);
        }
        [Fact]
        public void CanChangeJavaAnswer()
        {
            //Arrange

            //Act
            testCodeCard.JavaAnswer = "Execute Java Answers";
            //Assert
            Assert.Equal("Execute Java Answers", testCodeCard.JavaAnswer);
        }
        [Fact]
        public void CanChangeJavaScriptAnswer()
        {
            //Arrange

            //Act
            testCodeCard.JavaScriptAnswer = "Execute JavaScript Answers";
            //Assert
            Assert.Equal("Execute JavaScript Answers", testCodeCard.JavaScriptAnswer);
        }
        [Fact]
        public void CanChangePythonAnswer()
        {
            //Arrange

            //Act
            testCodeCard.PythonAnswer = "Execute Python Answers";
            //Assert
            Assert.Equal("Execute Python Answers", testCodeCard.PythonAnswer);
        }
        [Fact]
        public void CanChangeCAnswer()
        {
            //Arrange

            //Act
            testCodeCard.CAnswers = "Execute C Answers";
            //Assert
            Assert.Equal("Execute C Answers", testCodeCard.CAnswers);
        }
    }
}