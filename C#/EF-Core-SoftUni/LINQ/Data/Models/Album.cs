using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MusicHub.Data.Models
{
    public class Album
    {
        public Album()
        {
            Songs = new HashSet<Song>();
        }
        /*
         Price – calculated property (the sum of all song prices in the album)
         ProducerId – integer, Foreign key
         Producer – the album’s producer
         Songs – collection of all Songs in the Album*/

        public int Id { get; set; }

        [MaxLength(40)]
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        public decimal Price => Songs.Sum(x => x.Price);
        //{
        //    get
        //    {
        //        var sum = 0m;

        //        foreach (var song in Songs)
        //        {
        //            sum += song.Price;
        //        }

        //        return sum;
        //    }
        //}

        public int? ProducerId { get; set; }

        public Producer Producer { get; set; }

        public ICollection<Song> Songs { get; set; }
    }
}
