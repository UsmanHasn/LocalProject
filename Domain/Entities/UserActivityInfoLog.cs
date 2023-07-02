﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class UserActivityInfoLog : BaseEntity
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Users User { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        [MaxLength(100)]
        public string PageName { get; set; }
        [MaxLength(200)]
        public string Message { get; set; }
        [Required]
        public DateTime TimeLoggedIn { get; set; }

        public DateTime? TimeLoggedOut { get; set; }
    }
}
