# recipe-api
A project that stores data about various recipes and exposes it to the public for consumption.

# run the project
Clone the project from github repository, open solution in visual studio, make sure RecipeStorage.API is set a default project and run/debug the solution.

# architecture
The project is separated in three different projects.
The StorageRecipe.Data project is used to access the database. I've chosen to use EntityFramework Core, as it is quick the set up and easy to prototype an API with.
Another pro of this approach is that we can use in-memory database to set up some testing data easily or use unit/integration tests as well.

The RecipeStorage.Services layer contains the services that connect the datalayer with the presentation layer (RecipeStorage.API). By using dependency injection we can "easily" switch out the datalayer is we think that EF Core is the wrong approach or we want to change database in the future.

RecipeStorage.Common  contains business objects that are shared between Services and API layer of the project, such as DTOs.

The RecipeStorage.API is the public API that can be consumed by third parties, it uses Swagger for documentation so third-parties can see which response and requests they can make when implementing a client.

Finally, RecipeStorage.Tests.UnitTests is the unit test project, using the xUnit framework. Here are unit tests that can be run to test the application.

# assumptions
In this I assume that there's a separate API that handles authentication and the RecipeStorage.API will receive requests with a token.

# other
I have implement the Git Flow idea of commits. The main branch is called 'main' and then there's a 'develop' branch where all the development work is committed to. Each 'task' is done in a feature branch which can be found in 'feature/name_of_task'. When a feature is finished a PR is done to merge the feature into the develop branch, at the end of the day/sprint a PR is done to merge all the work from develop into main, which will then be deployed to UAT and/or production.

I have set up an initial feature which has the basis of the architecture in it, such as projects, swagger documentation, initial unit tests and api setup.
I have used a separate business object layer (RecipeStorage.Common) and business logic layer (RecipeStorage.Services).

While I was working on the project I would consider the following architecture

AuthenticationAPI, which would login a user, create a JWT token and send this over to the RecipeStorage API. We then can either query the userdatabase to find the role or have role stored in the token. Based on that the user will have access to modifiy data.
CountryAPI, this api would simply return a list of countries and perhaps regions within the country, as recipes are usually region specific.

Ingredient quantity: Every recipe has ingredients in different quantities, I have used a string for now but it would make sense to convert this to a look up table so we can change the amount needed based on the users preferred measurements (US or metric for example)

