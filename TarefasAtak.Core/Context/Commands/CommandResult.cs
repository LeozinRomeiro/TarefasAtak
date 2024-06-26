﻿

namespace TarefasAtak.Core.Context.Commands
{
    public class CommandResult<T>
    {
        public CommandResult(bool success, string message, T? data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get; set; } = false;
        public string Message { get; set; }
        public T? Data { get; set; }
    }
}
