﻿namespace TrainerCalender.Models.Dto
{
    public class UserDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Emailid { get; set; }

        public string Password { get; set; }

        public byte? IsAdmin { get; set; }
    }
}
