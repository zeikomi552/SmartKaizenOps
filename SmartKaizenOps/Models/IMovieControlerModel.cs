using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartKaizenOps.Models
{
    public interface IMovieControlerModel
    {
        public DelegateCommand? ExecuteFileOpenCommand { get; set; }

        public string MoviePath { get; set; }

        public MovieSliceCollectionModel MovieSliceItems { get; set; }

        public double MoviePositionValue { get; set; }

        public double MovieLength { get; set; }
    }
}
