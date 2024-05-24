﻿namespace ECommerce.backend.Utils.Responses
{
    public class ActionResponse<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Result { get; set; }
    }
}
