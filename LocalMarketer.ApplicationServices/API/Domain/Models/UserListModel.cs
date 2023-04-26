﻿using static LocalMarketer.DataAccess.Entities.User;

namespace LocalMarketer.ApplicationServices.API.Domain.Models
{
        public class UserListModel
        {
                public int Id { get; set; }
                public DateTime CreationDate { get; set; }
                public string Firstname { get; set; }
                public string Lastname { get; set; }
                public string Email { get; set; }
                public string Phone { get; set; }
                public string Role { get; set; }
                public bool AccesDenied { get; set; }
                public int ProfilesCount { get; set; }
                public int ToDosCount { get; set; }
        }
}