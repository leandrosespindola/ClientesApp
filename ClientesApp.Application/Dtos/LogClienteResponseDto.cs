﻿using ClientesApp.Application.Models;

namespace ClientesApp.Application.Dtos
{
    public class LogClienteResponseDto
    {
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public List<LogClienteModel> Logs { get; set; } = new List<LogClienteModel>();
    }
}
