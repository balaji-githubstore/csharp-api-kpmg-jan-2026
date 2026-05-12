using System;
using System.Collections.Generic;
using System.Text;

namespace KPMG.APIAutomation.Support
{
    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
    public class Tag
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

    public class Pet
    {
        public long Id { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public List<string> PhotoUrls { get; set; }
        public List<Tag> Tags {  get; set; }
        public string Status { get; set; }

    }
}
