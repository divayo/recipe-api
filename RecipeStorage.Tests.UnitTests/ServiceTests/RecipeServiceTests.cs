using Microsoft.Extensions.Logging;
using Moq;
using RecipeStorage.Common.Dto.Requests;
using RecipeStorage.Common.Exceptions;
using RecipeStorage.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RecipeStorage.Tests.UnitTests.ServiceTests
{
    public class RecipeServiceTests
    {

        [Fact]
        public async Task GetRecipeAsync_Success()
        {
            // arrange
            var dbContext = Helpers.DbContextHelper.GetInMemoryDbContext("getrecipeasync_success");
            DataService.AddSeedData(dbContext);
            var logger = new Mock<ILogger<RecipeService>>();
            IRecipeService service = new RecipeService(dbContext, logger.Object);
            var dto = new GetRecipeRequestDto { RecipeId = 1 };

            // act
            var result = await service.GetRecipeAsync(dto);

            // assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task GetRecipeAsync_NotFoundException()
        {
            // arrange
            var dbContext = Helpers.DbContextHelper.GetInMemoryDbContext("getrecipeasync_fail");
            var logger = new Mock<ILogger<RecipeService>>();
            IRecipeService service = new RecipeService(dbContext, logger.Object);
            var dto = new GetRecipeRequestDto { RecipeId = 0 };

            // act
            Task result() => service.GetRecipeAsync(dto);

            // assert
            await Assert.ThrowsAsync<RecipeNotFoundException>(result);
        }

        [Fact]
        public async Task CreateRecipeAsync_Success()
        {
            // arrange
            var dbContext = Helpers.DbContextHelper.GetInMemoryDbContext("createrecipeasync_success");
            var logger = new Mock<ILogger<RecipeService>>();
            IRecipeService service = new RecipeService(dbContext, logger.Object);
            var dto = new PostRecipeRequestDto { Name = "test_recipe", ShortDescription = "A short description" };

            // act
            var result = await service.CreateRecipeAsync(dto);

            // assert
            Assert.True(result);
            Assert.Equal(1, dbContext.Recipes.Count());
        }
    }
}
