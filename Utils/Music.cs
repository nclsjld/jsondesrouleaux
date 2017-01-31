using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    class Music
    {
        private String id;
        private String artist;
        private String title;
        private String album;
        private int bitrate;

        public String Artist
        {
            get { return artist; }
            set { artist = value; }
        }
        public String Id
        {
            get { return id; }
            set { id = value; }
        }
        public String Title
        {
            get { return title; }
            set { title = value; }
        }
        public String Album
        {
            get { return album; }
            set { album = value; }
        }
        public int Bitrate
        {
            get { return bitrate; }
            set { bitrate = value; }
        }
    }
}
