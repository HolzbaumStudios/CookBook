using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.recipes
{
    class Step
    {
        private int id;
        private String description;
        private int timer;
        private String imagePath;

        public int Id { get; set; }
        public String Description { get; set; }
        public int Timer { get; }
        public string ImagePath { get; set; }
    }
}
