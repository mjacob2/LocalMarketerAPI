﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalMarketer.DataAccess.Entities
{
        public class Profile : EntityBase
        {
                [Required]
                [MaxLength(50)]
                public string Name { get; set; }

                public int UserId { get; set; }

                public User User { get; set; }

                public int ClientId { get; set; }

                public Client Client { get; set; }

                [MaxLength(50)]
                public string Source { get; set; }

                [MaxLength(50)]
                public string WebsiteUrl { get; set; }

                [MaxLength(500)]
                public string ProfileUrl { get; set; }

                [MaxLength(500)]
                public string Description { get; set; }

                [MaxLength(50)]
                public string Voivodeship { get; set; }

                [MaxLength(50)]
                public string City { get; set; }

                [MaxLength(50)]
                public string Street { get; set; }

                [MaxLength(10)]
                public string PostCode { get; set; }

                [Required]
                [MaxLength(10)]
                public string NIP { get; set; }

                [Required]
                [MaxLength(14)]
                public string REGON { get; set; }

                [MaxLength(15)]
                public string Phone { get; set; }

                [MaxLength(50)]
                public string Email { get; set; }

                [MaxLength(50)]
                public string CustomerService { get; set; }

                public List<Activity> Activities { get; set; }

                public List<Deal> Deals { get; set; }
        }
}