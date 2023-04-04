﻿using System.ComponentModel.DataAnnotations;

namespace LocalMarketer.DataAccess.Entities
{
        public class User : EntityBase
        {
                public enum Roles
                {
                        Administrator = 0,
                        Manager = 1,
                        LocalMarketer = 2,
                        Seller = 3,
                }

                [Required]
                [MaxLength(20)]
                public string Firstname { get; set; }

                [Required]
                [MaxLength(20)]
                public string Lastname { get; set; }

                [Required]
                [MaxLength(50)]
                public string Email { get; set; }

                [Required]
                [MaxLength(15)]
                public string Phone { get; set; }

                [Required]
                [MaxLength(100)]
                public string Password { get; set; }

                [MaxLength(20)]
                public string Salt { get; set; }

                [Required]
                public Roles Role { get; set; }

                [Required]
                public bool AccesDenied { get; set; }

                public List<Profile> Profiles { get; set; } = new List<Profile> { };

                public List<ToDo> ToDos { get; set; } = new List<ToDo> { };
        }
}
