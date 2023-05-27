﻿using LocalMarketer.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace LocalMarketer.ApplicationServices
{
        public class AutomaticToDos
        {
                private readonly Deal newDeal;
                private readonly DateTime threeDaysBeforeDealEndDate;

                private readonly DateTime threeDaysFromNow = DateTime.Today.AddDays(3);
                private readonly DateTime sevenDaysFromNow = DateTime.Today.AddDays(7);
                private readonly DateTime forteenDaysFromNow = DateTime.Today.AddDays(14);

                private readonly DateTime oneMonthFromNow = DateTime.Today.AddMonths(1);
                private readonly DateTime twoMonthsFromNow = DateTime.Today.AddMonths(2);
                private readonly DateTime threeMonthsFromNow = DateTime.Today.AddMonths(3);
                private readonly DateTime fourMonthsFromNow = DateTime.Today.AddMonths(4);
                private readonly DateTime fiveMonthsFromNow = DateTime.Today.AddMonths(5);

                public AutomaticToDos(Deal newDeal)
                {
                        this.newDeal = newDeal;
                        this.threeDaysBeforeDealEndDate = this.newDeal.EndDate.AddDays(-3);
                }

                public List<ToDo> GetTasks()
                {
                        if (newDeal.Name.Contains("Premium", StringComparison.InvariantCultureIgnoreCase))
                        {
                                return PackagePremiumTasks();
                        }

                        if (newDeal.Name.Contains("Exclusive", StringComparison.InvariantCultureIgnoreCase))
                        {
                                return PackageExclusiveTasks();
                        }

                        if (newDeal.Name.Contains("Platinium", StringComparison.InvariantCultureIgnoreCase))
                        {
                                return PackagePlatiniumTasks();
                        }

                        return new List<ToDo>();
                }

                private List<ToDo> PackagePremiumTasks()
                {
                        return new List<ToDo>
                        {
                                new ToDo()
                                {
                                        DealId = newDeal.DealId,
                                        CreationDate = DateTime.Today,
                                        CreatorId = 0,
                                        Title = "Potwierdź pinezkę i widok z mapy",
                                        DueDate = threeDaysFromNow,
                                        Description = "",
                                        IsFinished = false,
                                        Notes = new List<Note>(),
                                        ForRole = User.Roles.LocalMarketer.ToString(),
                                },

                                new ToDo()
                                {
                                        DealId = newDeal.DealId,
                                        CreationDate = DateTime.Today,
                                        CreatorId = 0,
                                        Title = "Aktywuj czat",
                                        DueDate = threeDaysFromNow,
                                        Description = "",
                                        IsFinished = false,
                                        ForRole = User.Roles.LocalMarketer.ToString(),
                                },

                                new ToDo()
                                {
                                        DealId = newDeal.DealId,
                                        CreationDate = DateTime.Today,
                                        CreatorId = 0,
                                        Title = "Opublikuj 2 wpisy",
                                        DueDate = threeDaysFromNow,
                                        Description = "",
                                        IsFinished = false,
                                        Notes = new List<Note>(),
                                        ForRole = User.Roles.LocalMarketer.ToString(),
                                },


                        };
                }

                private List<ToDo> PackageExclusiveTasks()
                {
                        return new List<ToDo>
                        {
                                 new ToDo()
                                {
                                        DealId = newDeal.DealId,
                                        CreationDate = DateTime.Today,
                                        CreatorId = 0,
                                        Title = "Potwierdź pinezkę i widok z mapy",
                                        DueDate = threeDaysFromNow,
                                        Description = "",
                                        IsFinished = false,
                                        Notes = new List<Note>(),
                                        ForRole = User.Roles.LocalMarketer.ToString(),
                                },

                                new ToDo()
                                {
                                        DealId = newDeal.DealId,
                                        CreationDate = DateTime.Today,
                                        CreatorId = 0,
                                        Title = "Aktywuj czat",
                                        DueDate = threeDaysFromNow,
                                        Description = "",
                                        IsFinished = false,
                                        Notes = new List<Note>()
                                        {
                                                new Note()
                                                {
                                                        CreationDate = DateTime.Today,
                                                        Name = "notatka 1",
                                                }
                                        },
                                        ForRole = User.Roles.LocalMarketer.ToString(),
                                },


                                new ToDo()
                                {
                                        DealId = newDeal.DealId,
                                        CreationDate = DateTime.Today,
                                        CreatorId = 0,
                                        Title = "Odpowiedz do 10 ostatnich opini",
                                        DueDate = threeDaysFromNow,
                                        Description = "",
                                        IsFinished = false,
                                        Notes = new List<Note>(),
                                        ForRole = User.Roles.LocalMarketer.ToString(),
                                },

                                new ToDo()
                                {
                                        DealId = newDeal.DealId,
                                        CreationDate = DateTime.Today,
                                        CreatorId = 0,
                                        Title = "Odpowiedz do 10 ostatnich opini",
                                        DueDate = oneMonthFromNow,
                                        Description = "",
                                        IsFinished = false,
                                        Notes = new List<Note>(),
                                        ForRole = User.Roles.LocalMarketer.ToString(),
                                },

                                new ToDo()
                                {
                                        DealId = newDeal.DealId,
                                        CreationDate = DateTime.Today,
                                        CreatorId = 0,
                                        Title = "Odpowiedz do 10 ostatnich opini",
                                        DueDate = twoMonthsFromNow,
                                        Description = "",
                                        IsFinished = false,
                                        Notes = new List<Note>(),
                                        ForRole = User.Roles.LocalMarketer.ToString(),
                                },

                                new ToDo()
                                {
                                        DealId = newDeal.DealId,
                                        CreationDate = DateTime.Today,
                                        CreatorId = 0,
                                        Title = "Odpowiedz do 10 ostatnich opini",
                                        DueDate = this.threeDaysBeforeDealEndDate,
                                        Description = "",
                                        IsFinished = false,
                                        Notes = new List<Note>(),
                                        ForRole = User.Roles.LocalMarketer.ToString(),
                                },

                                new ToDo()
                                {
                                        DealId = newDeal.DealId,
                                        CreationDate = DateTime.Today,
                                        CreatorId = 0,
                                        Title = "Opublikuj 4 wpisy",
                                        DueDate = threeDaysFromNow,
                                        Description = "",
                                        IsFinished = false,
                                        Notes = new List<Note>(),
                                        ForRole = User.Roles.LocalMarketer.ToString(),
                                },

                                new ToDo()
                                {
                                        DealId = newDeal.DealId,
                                        CreationDate = DateTime.Today,
                                        CreatorId = 0,
                                        Title = "Opublikuj 4 wpisy",
                                        DueDate = oneMonthFromNow,
                                        Description = "",
                                        IsFinished = false,
                                        Notes = new List<Note>(),
                                        ForRole = User.Roles.LocalMarketer.ToString(),
                                },

                                new ToDo()
                                {
                                        DealId = newDeal.DealId,
                                        CreationDate = DateTime.Today,
                                        CreatorId = 0,
                                        Title = "Opublikuj 4 wpisy",
                                        DueDate = twoMonthsFromNow,
                                        Description = "",
                                        IsFinished = false,
                                        Notes = new List<Note>(),
                                        ForRole = User.Roles.LocalMarketer.ToString(),
                                },

                                new ToDo()
                                {
                                        DealId = newDeal.DealId,
                                        CreationDate = DateTime.Today,
                                        CreatorId = 0,
                                        Title = "Dodaj 3 wpisy NAP",
                                        DueDate = forteenDaysFromNow,
                                        Description = "http://bitly.pl/7FtAx \n http://bitly.pl/HOlGU \n http://bitly.pl/V2CNu",
                                        IsFinished = false,
                                        Notes = new List<Note>(),
                                        ForRole = User.Roles.LocalMarketer.ToString(),
                                },

                                new ToDo()
                                {
                                        DealId = newDeal.DealId,
                                        CreationDate = DateTime.Today,
                                        CreatorId = 0,
                                        Title = "Dodaj 3 wpisy NAP",
                                        DueDate = oneMonthFromNow,
                                        Description = "",
                                        IsFinished = false,
                                        Notes = new List<Note>(),
                                        ForRole = User.Roles.LocalMarketer.ToString(),
                                },

                                new ToDo()
                                {
                                        DealId = newDeal.DealId,
                                        CreationDate = DateTime.Today,
                                        CreatorId = 0,
                                        Title = "Dodaj 3 wpisy NAP",
                                        DueDate = twoMonthsFromNow,
                                        Description = "",
                                        IsFinished = false,
                                        Notes = new List<Note>(),
                                        ForRole = User.Roles.LocalMarketer.ToString(),
                                },
                        };
                }

                private List<ToDo> PackagePlatiniumTasks()
                {
                        return new List<ToDo>
                        {
                                 new ToDo()
                                {
                                        DealId = newDeal.DealId,
                                        CreationDate = DateTime.Today,
                                        CreatorId = 0,
                                        Title = "Potwierdź pinezkę i widok z mapy",
                                        DueDate = threeDaysFromNow,
                                        Description = "",
                                        IsFinished = false,
                                        Notes = new List<Note>(),
                                        ForRole = User.Roles.LocalMarketer.ToString(),
                                },

                                new ToDo()
                                {
                                        DealId = newDeal.DealId,
                                        CreationDate = DateTime.Today,
                                        CreatorId = 0,
                                        Title = "Aktywuj czat",
                                        DueDate = threeDaysFromNow,
                                        Description = "",
                                        IsFinished = false,
                                        Notes = new List<Note>()
                                        {
                                                new Note()
                                                {
                                                        CreationDate = DateTime.Today,
                                                        Name = "notatka 1",
                                                }
                                        },
                                        ForRole = User.Roles.LocalMarketer.ToString(),
                                },


                                new ToDo()
                                {
                                        DealId = newDeal.DealId,
                                        CreationDate = DateTime.Today,
                                        CreatorId = 0,
                                        Title = "Odpowiedz do 10 ostatnich opini",
                                        DueDate = threeDaysFromNow,
                                        Description = "",
                                        IsFinished = false,
                                        Notes = new List<Note>(),
                                        ForRole = User.Roles.LocalMarketer.ToString(),
                                },

                                new ToDo()
                                {
                                        DealId = newDeal.DealId,
                                        CreationDate = DateTime.Today,
                                        CreatorId = 0,
                                        Title = "Odpowiedz do 10 ostatnich opini",
                                        DueDate = oneMonthFromNow,
                                        Description = "",
                                        IsFinished = false,
                                        Notes = new List<Note>(),
                                        ForRole = User.Roles.LocalMarketer.ToString(),
                                },

                                new ToDo()
                                {
                                        DealId = newDeal.DealId,
                                        CreationDate = DateTime.Today,
                                        CreatorId = 0,
                                        Title = "Odpowiedz do 10 ostatnich opini",
                                        DueDate = twoMonthsFromNow,
                                        Description = "",
                                        IsFinished = false,
                                        Notes = new List<Note>(),
                                        ForRole = User.Roles.LocalMarketer.ToString(),
                                },

                                new ToDo()
                                {
                                        DealId = newDeal.DealId,
                                        CreationDate = DateTime.Today,
                                        CreatorId = 0,
                                        Title = "Odpowiedz do 10 ostatnich opini",
                                        DueDate = threeMonthsFromNow,
                                        Description = "",
                                        IsFinished = false,
                                        Notes = new List<Note>(),
                                        ForRole = User.Roles.LocalMarketer.ToString(),
                                },

                                new ToDo()
                                {
                                        DealId = newDeal.DealId,
                                        CreationDate = DateTime.Today,
                                        CreatorId = 0,
                                        Title = "Odpowiedz do 10 ostatnich opini",
                                        DueDate = fourMonthsFromNow,
                                        Description = "",
                                        IsFinished = false,
                                        Notes = new List<Note>(),
                                        ForRole = User.Roles.LocalMarketer.ToString(),
                                },

                                new ToDo()
                                {
                                        DealId = newDeal.DealId,
                                        CreationDate = DateTime.Today,
                                        CreatorId = 0,
                                        Title = "Odpowiedz do 10 ostatnich opini",
                                        DueDate = fiveMonthsFromNow,
                                        Description = "",
                                        IsFinished = false,
                                        Notes = new List<Note>(),
                                        ForRole = User.Roles.LocalMarketer.ToString(),
                                },

                                new ToDo()
                                {
                                        DealId = newDeal.DealId,
                                        CreationDate = DateTime.Today,
                                        CreatorId = 0,
                                        Title = "Odpowiedz do 10 ostatnich opini",
                                        DueDate = this.threeDaysBeforeDealEndDate,
                                        Description = "",
                                        IsFinished = false,
                                        Notes = new List<Note>(),
                                        ForRole = User.Roles.LocalMarketer.ToString(),
                                },

                                new ToDo()
                                {
                                        DealId = newDeal.DealId,
                                        CreationDate = DateTime.Today,
                                        CreatorId = 0,
                                        Title = "Opublikuj 4 wpisy",
                                        DueDate = threeDaysFromNow,
                                        Description = "",
                                        IsFinished = false,
                                        Notes = new List<Note>(),
                                        ForRole = User.Roles.LocalMarketer.ToString(),
                                },

                                new ToDo()
                                {
                                        DealId = newDeal.DealId,
                                        CreationDate = DateTime.Today,
                                        CreatorId = 0,
                                        Title = "Opublikuj 4 wpisy",
                                        DueDate = oneMonthFromNow,
                                        Description = "",
                                        IsFinished = false,
                                        Notes = new List<Note>(),
                                        ForRole = User.Roles.LocalMarketer.ToString(),
                                },

                                new ToDo()
                                {
                                        DealId = newDeal.DealId,
                                        CreationDate = DateTime.Today,
                                        CreatorId = 0,
                                        Title = "Opublikuj 4 wpisy",
                                        DueDate = twoMonthsFromNow,
                                        Description = "",
                                        IsFinished = false,
                                        Notes = new List<Note>(),
                                        ForRole = User.Roles.LocalMarketer.ToString(),
                                },

                                new ToDo()
                                {
                                        DealId = newDeal.DealId,
                                        CreationDate = DateTime.Today,
                                        CreatorId = 0,
                                        Title = "Opublikuj 4 wpisy",
                                        DueDate = threeMonthsFromNow,
                                        Description = "",
                                        IsFinished = false,
                                        Notes = new List<Note>(),
                                        ForRole = User.Roles.LocalMarketer.ToString(),
                                },

                                new ToDo()
                                {
                                        DealId = newDeal.DealId,
                                        CreationDate = DateTime.Today,
                                        CreatorId = 0,
                                        Title = "Opublikuj 4 wpisy",
                                        DueDate = fourMonthsFromNow,
                                        Description = "",
                                        IsFinished = false,
                                        Notes = new List<Note>(),
                                        ForRole = User.Roles.LocalMarketer.ToString(),
                                },

                                new ToDo()
                                {
                                        DealId = newDeal.DealId,
                                        CreationDate = DateTime.Today,
                                        CreatorId = 0,
                                        Title = "Opublikuj 4 wpisy",
                                        DueDate = fiveMonthsFromNow,
                                        Description = "",
                                        IsFinished = false,
                                        Notes = new List<Note>(),
                                        ForRole = User.Roles.LocalMarketer.ToString(),
                                },

                                new ToDo()
                                {
                                        DealId = newDeal.DealId,
                                        CreationDate = DateTime.Today,
                                        CreatorId = 0,
                                        Title = "Dodaj 3 wpisy NAP",
                                        DueDate = forteenDaysFromNow,
                                        Description = "",
                                        IsFinished = false,
                                        Notes = new List<Note>(),
                                        Link1 = "http://bitly.pl/7FtAx",
                                        Link2 = "http://bitly.pl/HOlGU",
                                        Link3 = "http://bitly.pl/V2CNu",
                                        ForRole = User.Roles.LocalMarketer.ToString(),
                                },

                                new ToDo()
                                {
                                        DealId = newDeal.DealId,
                                        CreationDate = DateTime.Today,
                                        CreatorId = 0,
                                        Title = "Dodaj 3 wpisy NAP",
                                        DueDate = oneMonthFromNow,
                                        Description = "",
                                        IsFinished = false,
                                        Notes = new List<Note>(),
                                        ForRole = User.Roles.LocalMarketer.ToString(),
                                },

                                new ToDo()
                                {
                                        DealId = newDeal.DealId,
                                        CreationDate = DateTime.Today,
                                        CreatorId = 0,
                                        Title = "Dodaj 3 wpisy NAP",
                                        DueDate = twoMonthsFromNow,
                                        Description = "",
                                        IsFinished = false,
                                        Notes = new List<Note>(),
                                        ForRole = User.Roles.LocalMarketer.ToString(),
                                },

                                new ToDo()
                                {
                                        DealId = newDeal.DealId,
                                        CreationDate = DateTime.Today,
                                        CreatorId = 0,
                                        Title = "Dodaj 3 wpisy NAP",
                                        DueDate = threeMonthsFromNow,
                                        Description = "",
                                        IsFinished = false,
                                        Notes = new List<Note>(),
                                        ForRole = User.Roles.LocalMarketer.ToString(),
                                },

                                new ToDo()
                                {
                                        DealId = newDeal.DealId,
                                        CreationDate = DateTime.Today,
                                        CreatorId = 0,
                                        Title = "Dodaj 3 wpisy NAP",
                                        DueDate = fourMonthsFromNow,
                                        Description = "",
                                        IsFinished = false,
                                        Notes = new List<Note>(),
                                        ForRole = User.Roles.LocalMarketer.ToString(),
                                },

                                new ToDo()
                                {
                                        DealId = newDeal.DealId,
                                        CreationDate = DateTime.Today,
                                        CreatorId = 0,
                                        Title = "Dodaj 3 wpisy NAP",
                                        DueDate = fiveMonthsFromNow,
                                        Description = "",
                                        IsFinished = false,
                                        Notes = new List<Note>(),
                                        ForRole = User.Roles.LocalMarketer.ToString(),
                                },
                        };
                }
        }
}
