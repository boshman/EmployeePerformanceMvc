EmployeePerformanceMvc - A project for learning the ins and outs of ASP.Net 4 MVC
======================

The only purpose of this project is for a couple classic ASP.Net web page developers to figure out how MVC works and why the ASP.Net community is moving in this direction. The goal is to be objective, but some of us are very skeptical that MVC with it's magic around naming conventions, is really such a good idea.

To get a feel for what MVC can do, we are going to build an employee performance evaluation system. The system will allow employees to enter a list of goals and then to review those goals with their manager. The Home page will provide a list of employees and will allow for filtering, paging and sorting. The filter box will use jQuery autocomplete to help users build filters.

Managers will be able to create Employees. Employees will do self-appraisals. Managers will appraise their employees. All of these functions will have associated CRUD Views.

Entity Framework will be used to access the database. Forms authentication and OAuth will be implemented.

A Unit Testing project is also included in the solution so we can learn how that works as well.

GitHub Markdown
---------------

GitHub formats the text in this README.md based on what they call Markdown.

For markdown rules, see https://help.github.com/articles/github-flavored-markdown

Techniques Learned
------------------

ENTITY FRAMEWORK (EF)
To use EF, first go to the NuGet Package Manager and add it to the project (if it isn't by default).

Next, you'll need to create a class that inherits from DbContext. This class will need to have a DbSet property for each class that will be mapped to a new table in the database.

    public DbSet<Employee> Employees { get; set; }

EF uses the inherited class to find the classes that will be mapped to new tables in the database. The properties in the found classes will be the columns in the new tables. There needs to be connectionString in the web.config file with the connection information.

Unless the logged in Windows user is the same user that will be the owner of the database, you need to create a new database in SQL Server and make sure the name is in the Initial Catalog of the Data Source in the connection string.

After that's done, you can run the website from Visual Studio and EF will go through the leg work of building out the tables for you in the database.

In order to setup migrations in EF (so you can add a Seed method to initially load the tables) run the following in the NuGet Package Manager Console:

    Enable-Migrations -ContextTypeName Name-of-the-class-that-inherits-from-DbContext

This will generate a Migrations folder and add a Configurations.cs file. Here you'll find a seed method that you can use to add a loop for loading tables like so:

    protected override void Seed(MvcMovie.Models.MovieDBContext context)
    {
        //  This method will be called after migrating to the latest version.
    
        //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
        //  to avoid creating duplicate seed data. E.g.
        //
        for (int i = 0; i <= 1000; i++)
        {
            context.Movies.AddOrUpdate(m => m.Title,
                new MvcMovie.Models.Movie{ Title = "Movie_" + i.ToString(), ReleaseDate = Convert.ToDateTime("1/1/1970"), Genre = "Drama", Director = "Steven Spielberg" });
        }
    }
        
        
