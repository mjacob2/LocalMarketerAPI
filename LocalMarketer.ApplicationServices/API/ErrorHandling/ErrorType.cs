﻿namespace LocalMarketer.ApplicationServices.API.ErrorHandling
{
        public class ErrorType
        {
                public const string InternalServerError = "INTERNAL_SERVER_ERROR";
                public const string ValidationError = "VALIDATION_ERROR";
                public const string NotAuthenticated = "Nieprawidłowe dane";
                public const string Unauthorized = "UNAUTHORIZED";
                public const string NotFound = "NOT_FOUND";
                public const string UnsupportedMediaType = "UNSUPPORTED_MEDIA_TYPE";
                public const string UnsupportedMethod = "UNSUPPORTED_METHOD";
                public const string RequestTooLarge = "REQUEST_TOO_LARGE";
                public const string TooManyRequests = "TOO_MANY_REQUESTS";
                public const string UsernameNotAvailable = "Username already taken";
                public const string ItemAlreadyExists = "Item with this data already exists in database";
                public const string AdministratorRoleNoMore = "Nie mozna stworzyc nowego Administratora";
                public const string GoogleIdAlreadyExists = "Profil o takim identyfikatorze Google juz istnieje w bazie";
                public const string ClientAlreadyExists = "Klient z takim e-mail już istnieje w bazie";
                public const string UserAlreadyExists = "Użytkownik z takim e-mail już istnieje w bazie";
                public const string AutomaticToDosError = "Wystapił problem z utworzeniem automatycznych zadań do umowy";
                public const string AutomaticEmailError = "AutomaticEmailErrorNewDeal";
        }
}
