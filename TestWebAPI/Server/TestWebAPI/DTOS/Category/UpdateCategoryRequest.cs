﻿namespace TestWebAPI.DTOS.Book
{
    public class UpdateCategoryRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
