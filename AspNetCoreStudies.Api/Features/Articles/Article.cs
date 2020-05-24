using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreStudies.Api.Features.Articles
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }

        public DateTimeOffset? DeletedAt { get; set; }
    }
}
