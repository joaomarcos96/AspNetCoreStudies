using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreStudies.Api.Entities
{
    public class Post
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public Blog Blog { get; set; }
    }
}
