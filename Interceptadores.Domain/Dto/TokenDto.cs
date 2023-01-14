﻿using System.ComponentModel;

namespace Interceptadores.Domain.Dto
{
    [DisplayName("Token")]
    public class TokenDto
    {
        public TokenDto(string token)
            => Token = token;

        public string Token { get; set; }
    }
}