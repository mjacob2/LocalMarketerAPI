using System;
using System.Data.Common;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using LocalMarketer.ApplicationServices;
using LocalMarketer.DataAccess;
using LocalMarketer.DataAccess.Entities;

namespace Tests
{
        /// <summary>
        /// Provides in memory SqLite conection to in memory database.
        /// </summary>
        public class InMemorySqliteConnection : IDisposable
        {
                private readonly DbConnection connection;

                private readonly DbContextOptions<LocalMarketerDbContext> contextOptions;

                private bool disposedValue;

                private string saltForPasswordHash = Hasher.GetSalt();

                private DateTime today = DateTime.ParseExact("2023-01-01", "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);

                private DateTime oneMonthFromToday = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);

                private DateTime threeMonthsFromToday = DateTime.ParseExact("2023-03-01", "yyyy-MM-dd",
                       System.Globalization.CultureInfo.InvariantCulture);

                private DateTime sixMonthsFromToday = DateTime.ParseExact("2023-06-01", "yyyy-MM-dd",
       System.Globalization.CultureInfo.InvariantCulture);

                /// <summary>
                /// Initializes a new instance of the <see cref="InMemorySqliteConnection"/> class.
                /// </summary>
                public InMemorySqliteConnection()
                {
                        this.connection = new SqliteConnection("Filename=:memory:");

                        this.connection.Open();

                        this.contextOptions = new DbContextOptionsBuilder<LocalMarketerDbContext>()
                            .UseSqlite(this.connection)
                            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                            .Options;

                        using var context = new LocalMarketerDbContext(this.contextOptions);

                        GenerateUsers(context);

                        GenerateClients(context);

                        GenerateProfiles(context);

                        GeneratePackages(context);

                        GenerateDeals(context);

                        GenerateToDos(context);
                }
                private void GenerateUsers(LocalMarketerDbContext context)
                {
                        if (context.Database.EnsureCreated())
                        {
                                using var viewCommand = context.Database.GetDbConnection().CreateCommand();
                                viewCommand.CommandText = @"
                                                        CREATE VIEW AllResources AS
                                                        SELECT Url
                                                        FROM Users;";
                                viewCommand.ExecuteNonQuery();
                        }

                        context.AddRange(
                                new User
                                {
                                        Id = 1,
                                        CreationDate = today,
                                        Firstname = "Marek",
                                        Lastname = "Jakubicki",
                                        Email = "mjakubicki@localmarketer.pl",
                                        Phone = "692409120",
                                        Password = Hasher.HashPassword("password", this.saltForPasswordHash),
                                        Salt = this.saltForPasswordHash,
                                        Role = User.Roles.Administrator.ToString(),
                                        AccesDenied = false,
                                },
                                new User
                                {
                                        Id = 2,
                                        CreationDate = today,
                                        Firstname = "John",
                                        Lastname = "Kowalski",
                                        Email = "jkowalski@localmarketer.pl",
                                        Phone = "111222333",
                                        Password = Hasher.HashPassword("password", this.saltForPasswordHash),
                                        Salt = this.saltForPasswordHash,
                                        Role = User.Roles.Seller.ToString(),
                                        AccesDenied = false,
                                },
                                new User
                                {
                                        Id = 3,
                                        CreationDate = today,
                                        Firstname = "Eva",
                                        Lastname = "Flow",
                                        Email = "eflow@localmarketer.pl",
                                        Phone = "112233",
                                        Password = Hasher.HashPassword("password", this.saltForPasswordHash),
                                        Salt = this.saltForPasswordHash,
                                        Role = User.Roles.Seller.ToString(),
                                        AccesDenied = false,
                                },
                                new User
                                {
                                        Id = 4,
                                        CreationDate = today,
                                        Firstname = "Paola",
                                        Lastname = "Kifos",
                                        Email = "pkifos@localmarketer.pl",
                                        Phone = "111222333",
                                        Password = Hasher.HashPassword("password", this.saltForPasswordHash),
                                        Salt = this.saltForPasswordHash,
                                        Role = User.Roles.LocalMarketer.ToString(),
                                        AccesDenied = false,
                                },
                                new User
                                {
                                        Id = 5,
                                        CreationDate = today,
                                        Firstname = "Jagoda",
                                        Lastname = "Miłosz",
                                        Email = "jmilos@localmarketer.pl",
                                        Phone = "111222333",
                                        Password = Hasher.HashPassword("password", this.saltForPasswordHash),
                                        Salt = this.saltForPasswordHash,
                                        Role = User.Roles.LocalMarketer.ToString(),
                                        AccesDenied = false,
                                }
                                );

                        context.SaveChanges();
                }
                private void GenerateClients(LocalMarketerDbContext context)
                {
                        if (context.Database.EnsureCreated())
                        {
                                using var viewCommand = context.Database.GetDbConnection().CreateCommand();
                                viewCommand.CommandText = @"
                                                        CREATE VIEW AllResources AS
                                                        SELECT Url
                                                        FROM Clients;";
                                viewCommand.ExecuteNonQuery();
                        }

                        context.AddRange(
                                new Client
                                {
                                        Id = 1,
                                        CreationDate = today,
                                        Name = "First Client",
                                        GoogleGroupId = "111222333",
                                        FirstName = "John",
                                        LastName = "Wick",
                                        Phone = "111222333",
                                        Email = "email1@gmail.com",
                                        Source = "Source1",
                                        Description = "Some description",
                                        CreatorId = 1, // Administrator


                                },
                                new Client
                                {
                                        Id = 2,
                                        CreationDate = today,
                                        Name = "Second Client",
                                        GoogleGroupId = "111222333",
                                        FirstName = "Anna",
                                        LastName = "Wee",
                                        Phone = "222333444",
                                        Email = "email2@gmail.com",
                                        Source = "Source2",
                                        Description = "Some description 2",
                                        CreatorId = 2, // Seller
                                },
                                new Client
                                {
                                        Id = 3,
                                        CreationDate = today,
                                        Name = "Third Client",
                                        GoogleGroupId = "111222333",
                                        FirstName = "Thomas",
                                        LastName = "Jefferson",
                                        Phone = "333444555",
                                        Email = "email3@gmail.com",
                                        Source = "Source3",
                                        Description = "Some description 3",
                                        CreatorId = 3, // Seller
                                }
                                );

                        context.SaveChanges();
                }
                private void GenerateProfiles(LocalMarketerDbContext context)
                {
                        if (context.Database.EnsureCreated())
                        {
                                using var viewCommand = context.Database.GetDbConnection().CreateCommand();
                                viewCommand.CommandText = @"
                                                        CREATE VIEW AllResources AS
                                                        SELECT Url
                                                        FROM Profiles;";
                                viewCommand.ExecuteNonQuery();
                        }

                        context.AddRange(
                                new Profile
                                {
                                        Id = 1,
                                        CreationDate = today,
                                        Name = "Profile_1",
                                        GoogleProfileId = "333444555666",
                                        CreatorId = 1, //Administrator
                                        UserId = 1, // Administrator
                                        ClientId = 1,
                                        Source = "Source1",
                                        WebsiteUrl = "www.website1.com",
                                        ProfileUrl = "www.profile1Url.com",
                                        Description = "Some description 1",
                                        Voivodeship = "dolnośląskie",
                                        City = "Wrocław",
                                        Street = "Lesna 1/3",
                                        PostCode = "50-078",
                                        NIP = "8971803272",
                                        REGON = "360170795",
                                        Phone = "555666777",
                                        Email = "kontakt@profile1.com",
                                        CustomerService = "combined",
                                },
                                new Profile
                                {
                                        Id = 2,
                                        CreationDate = today,
                                        Name = "Profile_2",
                                        GoogleProfileId = "3334445556626",
                                        CreatorId = 2, //Seller
                                        UserId = 4, // LocalMarketer
                                        ClientId = 2,
                                        Source = "Source1",
                                        WebsiteUrl = "www.website2.com",
                                        ProfileUrl = "www.profile2Url.com",
                                        Description = "Some description 2",
                                        Voivodeship = "dolnośląskie",
                                        City = "Wrocław",
                                        Street = "Rynek 4",
                                        PostCode = "50-002",
                                        NIP = "8971803272",
                                        REGON = "360170795",
                                        Phone = "555666777",
                                        Email = "kontakt@profile2.com",
                                        CustomerService = "localonly",
                                },
                                new Profile
                                {
                                        Id = 3,
                                        CreationDate = today,
                                        Name = "Profile_3",
                                        GoogleProfileId = "33234445556626",
                                        CreatorId = 3, //Seller
                                        UserId = 5, // LocalMarketer
                                        ClientId = 3,
                                        Source = "Source1",
                                        WebsiteUrl = "www.website3.com",
                                        ProfileUrl = "www.profile3Url.com",
                                        Description = "Some description 3",
                                        Voivodeship = "dolnośląskie",
                                        City = "Trzebnica",
                                        Street = "Słoneczna 3/18",
                                        PostCode = "55-100",
                                        NIP = "8971803272",
                                        REGON = "360170795",
                                        Phone = "555666777",
                                        Email = "kontakt@profile4.com",
                                        CustomerService = "localonly",
                                },
                                new Profile
                                {
                                        Id = 4,
                                        CreationDate = today,
                                        Name = "Profile_4",
                                        GoogleProfileId = "332344454556626",
                                        CreatorId = 3, //Seller
                                        UserId = 5, // LocalMarketer
                                        ClientId = 3,
                                        Source = "Source1",
                                        WebsiteUrl = "www.website4.com",
                                        ProfileUrl = "www.profile4Url.com",
                                        Description = "Some description 4",
                                        Voivodeship = "dolnośląskie",
                                        City = "Olesnica",
                                        Street = "Jabłonkowa 43",
                                        PostCode = "55-123",
                                        NIP = "8971803272",
                                        REGON = "360170795",
                                        Phone = "555666777",
                                        Email = "kontakt@profile4.com",
                                        CustomerService = "localonly",
                                }
                                );

                        context.SaveChanges();
                }
                private void GenerateDeals(LocalMarketerDbContext context)
                {
                        if (context.Database.EnsureCreated())
                        {
                                using var viewCommand = context.Database.GetDbConnection().CreateCommand();
                                viewCommand.CommandText = @"
                                                        CREATE VIEW AllResources AS
                                                        SELECT Url
                                                        FROM Deals;";
                                viewCommand.ExecuteNonQuery();
                        }

                        context.AddRange(
                                new Deal
                                {
                                        Id = 1,
                                        CreationDate = today,
                                        CreatorId = 1, //Administrator
                                        ProfileId = 1,
                                        EndDate = oneMonthFromToday,
                                        Name = "Pakiet Premium 1",
                                        PackageId = 1,
                                        Price = 1000,
                                        Description = "Some description",
                                        Stage = "InProgress",

                                },
                                new Deal
                                {
                                        Id = 2,
                                        CreationDate = today,
                                        CreatorId = 1, //Administrator
                                        ProfileId = 2,
                                        EndDate = threeMonthsFromToday,
                                        Name = "Pakiet Exclusive 2",
                                        PackageId = 2,
                                        Price = 3000,
                                        Description = "Some description",
                                        Stage = "InProgress",

                                },
                                new Deal
                                {
                                        Id = 3,
                                        CreationDate = today,
                                        CreatorId = 1, //Administrator
                                        ProfileId = 3,
                                        EndDate = threeMonthsFromToday,
                                        Name = "Pakiet Exclusive 2.2",
                                        PackageId = 2,
                                        Price = 3000,
                                        Description = "Some description",
                                        Stage = "InProgress",

                                },
                                new Deal
                                {
                                        Id = 4,
                                        CreationDate = today,
                                        CreatorId = 1, //Administrator
                                        ProfileId = 4,
                                        EndDate = threeMonthsFromToday,
                                        Name = "Pakiet Platinium 3",
                                        PackageId = 3,
                                        Price = 3000,
                                        Description = "Some description",
                                        Stage = "InProgress",

                                }
                                );

                        context.SaveChanges();
                }
                private void GeneratePackages(LocalMarketerDbContext context)
                {
                        if (context.Database.EnsureCreated())
                        {
                                using var viewCommand = context.Database.GetDbConnection().CreateCommand();
                                viewCommand.CommandText = @"
                                                        CREATE VIEW AllResources AS
                                                        SELECT Url
                                                        FROM Packages;";
                                viewCommand.ExecuteNonQuery();
                        }

                        context.AddRange(
                                new Package
                                {
                                        Id = 1,
                                        Name = "Premium 1",
                                        MinimumPrice = 1000,
                                        DurationInMonths = 1,

                                },
                                new Package
                                {
                                        Id = 2,
                                        Name = "Exclusive 2",
                                        MinimumPrice = 2500,
                                        DurationInMonths = 3,

                                },
                                new Package
                                {
                                        Id = 3,
                                        Name = "Platinium 3",
                                        MinimumPrice = 5000,
                                        DurationInMonths = 6,

                                }
                                );

                        context.SaveChanges();
                }
                private void GenerateToDos(LocalMarketerDbContext context)
                {
                        if (context.Database.EnsureCreated())
                        {
                                using var viewCommand = context.Database.GetDbConnection().CreateCommand();
                                viewCommand.CommandText = @"
                                                        CREATE VIEW AllResources AS
                                                        SELECT Url
                                                        FROM Activities;";
                                viewCommand.ExecuteNonQuery();
                        }

                        context.AddRange(
                                new ToDo
                                {
                                        Id = 1,
                                        CreationDate = today,
                                        CreatorId = 1, // Administrator
                                        Title = "Task 1",
                                        DealId = 1,
                                        DueDate = oneMonthFromToday,
                                        Description = " description 1",
                                        IsFinished = false,
                                },
                                new ToDo
                                {
                                        Id = 2,
                                        CreationDate = today,
                                        CreatorId = 1, // Administrator
                                        Title = "Task 2",
                                        DealId = 1,
                                        DueDate = oneMonthFromToday,
                                        Description = " description 2",
                                        IsFinished = false,
                                },
                                new ToDo
                                {
                                        Id = 3,
                                        CreationDate = today,
                                        CreatorId = 1, // Administrator
                                        Title = "Task 3",
                                        DealId = 1,
                                        DueDate = oneMonthFromToday,
                                        Description = " description 3",
                                        IsFinished = false,
                                },
                                new ToDo
                                {
                                        Id = 4,
                                        CreationDate = today,
                                        CreatorId = 1, // Administrator
                                        Title = "Task 4",
                                        DealId = 2,
                                        DueDate = oneMonthFromToday,
                                        Description = " description 4",
                                        IsFinished = false,
                                },
                                new ToDo
                                {
                                        Id = 5,
                                        CreationDate = today,
                                        CreatorId = 1, // Administrator
                                        Title = "Task 5",
                                        DealId = 3,
                                        DueDate = oneMonthFromToday,
                                        Description = " description 5",
                                        IsFinished = false,
                                },
                                new ToDo
                                {
                                        Id = 6,
                                        CreationDate = today,
                                        CreatorId = 1, // Administrator
                                        Title = "Task 6",
                                        DealId = 3,
                                        DueDate = oneMonthFromToday,
                                        Description = " description 6",
                                        IsFinished = false,
                                },
                                new ToDo
                                {
                                        Id = 7,
                                        CreationDate = today,
                                        CreatorId = 1, // Administrator
                                        Title = "Task 7",
                                        DealId = 3,
                                        DueDate = oneMonthFromToday,
                                        Description = " description 7",
                                        IsFinished = false,
                                }
                                );

                        context.SaveChanges();
                }


                /// <summary>
                /// Finalizes an instance of the <see cref="InMemorySqliteConnection"/> class.
                /// </summary>
                ~InMemorySqliteConnection()
                {
                        this.Dispose(disposing: false);
                }

                /// <summary>
                /// Creates context for testing.
                /// </summary>
                /// <returns>ToDoAppStorageContext with in memory options.</returns>
                public LocalMarketerDbContext CreateContext()
                {
                        return new LocalMarketerDbContext(this.contextOptions);
                }

                /// <summary>
                /// Disposing method.
                /// </summary>
                public void Dispose()
                {
                        this.Dispose(disposing: true);
                        GC.SuppressFinalize(this);
                }

                /// <summary>
                /// Disposes connection.
                /// </summary>
                /// <param name="disposing">Is disposing.</param>
                protected virtual void Dispose(bool disposing)
                {
                        if (!this.disposedValue)
                        {
                                if (disposing)
                                {
                                        this.connection.Dispose();
                                }

                                this.disposedValue = true;
                        }
                }
        }
}
