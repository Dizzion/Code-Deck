using System;
using Xunit;
using Moq;
using CodeDeckAPI.Data;
using Microsoft.EntityFrameworkCore;
using CodeDeckAPI.Controllers;
using AutoMapper;
using CodeDeckAPI.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CodeDeckAPI.Dtos;
using CodeDeckAPI.Profiles;

namespace CodeDeckAPI.Tests
{
    public class CodeDeckControllerTests : IDisposable
    {
        Mock<ICodeCardRepo> mockRepo;
        CodeCardProfile realProfile;
        MapperConfiguration configuration;
        IMapper mapper;

        public CodeDeckControllerTests()
        {
            mockRepo = new Mock<ICodeCardRepo>();
            realProfile = new CodeCardProfile();
            configuration = new MapperConfiguration(cfg => cfg.AddProfile(realProfile));
            mapper = new Mapper(configuration);
        }

        public void Dispose()
        {
            mockRepo = null;
            mapper = null;
            configuration = null;
            realProfile = null;
        }

        //ACTION 1 Tests: GET /api/CodeDeck
        //TEST 1.1 REQUEST RESOURCES WHEN NONE EXIST – RETURN "NOTHING"
        [Fact]
        public void GetAllCards_ReturnZeroResources_WhenDBIsEmpty()
        {
            //Arrange
            mockRepo.Setup(repo =>
                repo.GetAllCards()).Returns(GetCodeCards(0));

            var controller = new CodeCardController(mockRepo.Object, mapper);
            //Act
            var result = controller.GetAllCards();
            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }
        //TEST 1.2: RETURNING A COUNT OF 1 FOR A SINGLE CODECARD RESOURCE
        [Fact]
        public void GetAllCards_ReturnsOneResource_WhenDBHasOneResource()
        {
            //Arrange
            mockRepo.Setup(repo =>
                repo.GetAllCards()).Returns(GetCodeCards(1));

            var controller = new CodeCardController(mockRepo.Object, mapper);
            //Act
            var result = controller.GetAllCards();
            //Assert
            var okResult = result.Result as OkObjectResult;
            var codeCards = okResult.Value as List<CodeCardReadDto>;

            Assert.Single(codeCards);
        }
        //TEST 1.3: RETURNING A 200OK WHEN DB HAS 1 RESOURCE
        [Fact]
        public void GetAllCards_Returns200Ok_WhenDBHasOneResource()
        {
            //Arrange
            mockRepo.Setup(repo =>
                repo.GetAllCards()).Returns(GetCodeCards(1));

            var controller = new CodeCardController(mockRepo.Object, mapper);
            //Act
            var result = controller.GetAllCards();
            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }
        //TEST 1.4: RETURNING A COUNT OF N FOR N CODECARD Resources
        [Fact]
        public void GetAllCards_ReturnNItems_WhenDBHasNResources()
        {
            //Arrange
            var rand = new Random();
            var num = rand.Next(21);
            mockRepo.Setup(repo =>
                repo.GetAllCards()).Returns(GetCodeCards(num));

            var controller = new CodeCardController(mockRepo.Object, mapper);
            //Act
            var result = controller.GetAllCards();
            //Assert
            var okResult = result.Result as OkObjectResult;
            var codeCards = okResult.Value as List<CodeCardReadDto>;

            Assert.Equal(num, codeCards.Count());

        }
        //TEST 1.5: RETURNS THE EXPECTED TYPE FOR 1 RESOURCE
        [Fact]
        public void GetAllCards_ReturnsTheCorrectType_WhenDBHasOneResource()
        {
            //Arrange
            mockRepo.Setup(repo =>
                repo.GetAllCards()).Returns(GetCodeCards(1));

            var controller = new CodeCardController(mockRepo.Object, mapper);
            //Act
            var result = controller.GetAllCards();
            //Assert
            Assert.IsType<ActionResult<IEnumerable<CodeCardReadDto>>>(result);
        }

        //ACTION 2 Tests: GET /api/CodeDeck/{id}
        //TEST 2.1 INVALID RESOURCE ID – 404 NOT FOUND RETURN CODE
        [Fact]
        public void GetCodeCardById_Returns404NotFound_WhenNonExistentIDProvided()
        {
            //Arrange
            mockRepo.Setup(repo =>
                repo.GetCodeCardById(0)).Returns(() => null);

            var controller = new CodeCardController(mockRepo.Object, mapper);
            //Act
            var result = controller.GetCodeCardById(1);
            //Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }
        //TEST 2.2 VALID RESOURCE ID – 200 OK RETURN CODE
        [Fact]
        public void GetCodeCardById_Returns200Ok_WhenValidIDProvided()
        {
            //Arrange
            mockRepo.Setup(repo =>
                repo.GetCodeCardById(1)).Returns(
                    new CodeCard 
                    {
                        CardId = 1,
                        Challenge = "Mock",
                        JavaAnswer = "Mock",
                        JavaScriptAnswer = "Mock",
                        PythonAnswer = "Mock",
                        CAnswers = "Mock"
                    }
                );

            var controller = new CodeCardController(mockRepo.Object, mapper);
            //Act
            var result = controller.GetCodeCardById(1);
            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }
        //TEST 2.3 VALID RESOURCE ID – CHECK CORRECT RESOURCE TYPE
        [Fact]
        public void GetCodeCardByIdReturnsTheCorrectType()
        {
            //Arrange
            mockRepo.Setup(repo =>
                repo.GetCodeCardById(1)).Returns(
                    new CodeCard 
                    {
                        CardId = 1,
                        Challenge = "Mock",
                        JavaAnswer = "Mock",
                        JavaScriptAnswer = "Mock",
                        PythonAnswer = "Mock",
                        CAnswers = "Mock"
                    }
                );

            var controller = new CodeCardController(mockRepo.Object, mapper);
            //Act
            var result = controller.GetCodeCardById(1);
            //Assert
            Assert.IsType<ActionResult<CodeCardReadDto>>(result);
        }

        //ACTION 3 Tests: POST /api/CodeDeck
        //TEST 3.1 VALID OBJECT SUBMITTED – RETURNS CORRECT RESOURCE TYPE
        [Fact]
        public void CreateCodeCard_ReturnsCorrectResourceType_WhenValidObject()
        {
            //Arrange
            mockRepo.Setup(repo =>
                repo.GetCodeCardById(1)).Returns(
                    new CodeCard 
                    {
                        CardId = 1,
                        Challenge = "Mock",
                        JavaAnswer = "Mock",
                        JavaScriptAnswer = "Mock",
                        PythonAnswer = "Mock",
                        CAnswers = "Mock"
                    }
                );

            var controller = new CodeCardController(mockRepo.Object, mapper);
            //Act
            var result = controller.CreateCodeCard(new CodeCardCreateDto { });
            //Assert
            Assert.IsType<ActionResult<CodeCardReadDto>>(result);
        }
        //TEST 3.2 VALID OBJECT SUBMITTED – 201 CREATED RETURN CODE
        [Fact]
        public void CreateCodeCard_Returns201Created_WhenValidObjectSubmitted()
        {
            //Arrange
            mockRepo.Setup(repo =>
                repo.GetCodeCardById(1)).Returns(
                    new CodeCard 
                    {
                        CardId = 1,
                        Challenge = "Mock",
                        JavaAnswer = "Mock",
                        JavaScriptAnswer = "Mock",
                        PythonAnswer = "Mock",
                        CAnswers = "Mock"
                    }
                );
            
            var controller = new CodeCardController(mockRepo.Object, mapper);
            //Act
            var result = controller.CreateCodeCard(new CodeCardCreateDto { });
            //Assert
            Assert.IsType<CreatedAtRouteResult>(result.Result);
        }

        //ACTION 4 Tests: PUT /api/CodeDeck/{id}
        //TEST 4.1 VALID OBJECT SUBMITTED - 204 NO CONTENT RETURN
        [Fact]
        public void UpdateCodeCard_Returns204NoContent_WhenValidObjectSubmitted()
        {
            //Arrange
            mockRepo.Setup(repo =>
                repo.GetCodeCardById(1)).Returns(
                    new CodeCard 
                    {
                        CardId = 1,
                        Challenge = "Mock",
                        JavaAnswer = "Mock",
                        JavaScriptAnswer = "Mock",
                        PythonAnswer = "Mock",
                        CAnswers = "Mock"
                    }
                );

            var controller = new CodeCardController(mockRepo.Object, mapper);
            //Act
            var result = controller.UpdateCodeCard(1, new CodeCardUpdateDto { });
            //Assert
            Assert.IsType<NoContentResult>(result);
        }
        //TEST 4.2 NON EXISTENT RESOURCE ID - 404 NOT FOUND RETURN
        [Fact]
        public void UpdateCodeCard_Returns404NotFound_WhenNonExistentResourceIDSubmitted()
        {
            //Arrange
            mockRepo.Setup(repo =>
                repo.GetCodeCardById(0)).Returns(() => null);

            var controller = new CodeCardController(mockRepo.Object, mapper);
            //Act
            var result = controller.UpdateCodeCard(0, new CodeCardUpdateDto { });
            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        //ACTION 5 Tests: PATCH /api/CodeDeck/{id}
        //TEST 5.1 NON EXISTENT RESOURCE ID - 404 NOT FOUND RETURN
        [Fact]
        public void PartialCodeCardUpdate_Returns404NotFound_WhenNonExistentResourceIDSubmitted()
        {
            //Arrange
            mockRepo.Setup(repo =>
                repo.GetCodeCardById(0)).Returns(() => null);

            var controller = new CodeCardController(mockRepo.Object, mapper);
            //Act
            var result = controller.PartialCodeCardUpdate(0, new Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<CodeCardUpdateDto> { });
            //Assert
            Assert.IsType<NotFoundResult>(result);
        }
    


        //Private Support Method
        private List<CodeCard> GetCodeCards(int num)
        {
            var codeCards = new List<CodeCard>();
            if (num > 0)
            {
                for (int i = 0; i < num; i++)
                {
                    codeCards.Add(new CodeCard
                    {
                        CardId = i,
                        Challenge = "Challenge",
                        Difficulty = Difficulty.Easy,
                        JavaAnswer = "Java Answer",
                        JavaScriptAnswer = "JavaScript Answer",
                        PythonAnswer = "Python Answer",
                        CAnswers = "C Answer"
                    });
                }
            }
            return codeCards;
        }
    }
}