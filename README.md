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

# assumptions
In this I assume that there's a separate API that handles authentication and the RecipeStorage.API will receive requests with a token.