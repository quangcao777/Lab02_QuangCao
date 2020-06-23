using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Book
    {
        private int id;
        private string title;
        private string author;
        private string image;
        public Book()
        {

        }
        public Book(int id,string title,string author,string image)
        {
            this.id = id;
            this.title = title;
            this.author = author;
            this.image = image;
        }
        public int Id
        {
            get { return id; }
        }
        [Required (ErrorMessage ="Tiêu đề không được trống")]
        [StringLength(250, ErrorMessage ="Tiêu đề không được vượt quá 20 ký tự")]
        [Display(Name ="Tiêu đề")]
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        public string Image
        {
            get { return image; }
            set { image = value; }
        }
    }
    
}