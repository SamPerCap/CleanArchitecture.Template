﻿namespace Application.Common.Models
{
    public class Result<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public string? Message { get; set; }

        public static Result<T> Ok(T data) => new()
        {
            Success = true,
            Data = data
        };

        public static Result<T> Fail(string message) =>
            new()
            {
                Success = false,
                Message = message
            };
    }

}
