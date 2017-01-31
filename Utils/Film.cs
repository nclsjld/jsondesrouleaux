using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    class Film
    {
        private int id;
        private String title;
        private String writer;
        private String actors;
        private int date;
        private String language;
        private String type;        

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public String Title
        {
            get { return title; }
            set { title = value; }
        }
        public String Writer
        {
            get { return writer; }
            set { writer = value; }
        }
        public String Actors
        {
            get { return actors; }
            set { actors = value; }
        }
        public int Date
        {
            get { return date; }
            set { date = value; }
        }
        public String Language
        {
            get { return language; }
            set { language = value; }
        }
        public String Type
        {
            get { return type; }
            set { type = value; }
        }
        
    }
}
