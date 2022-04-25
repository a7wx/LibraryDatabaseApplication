using System;
using System.Collections.Generic;
using LibraryApplication.Database;
namespace LibraryApplication.Repository
#nullable disable
{
    public class BookDTO : BaseDTO
    {
        private long _Id;
        private string _Title;
        private string _Subtitle;
        private long _Length;
        private string _Publisher;
        private long _SeriesId;
        private long _SeriesPos;
        private string _SeriesName;
        private string _Author;
        private string _Genre;

        public long Id
        {
            get { return _Id; }
            set { SetField<long>(ref _Id, value); }
        }

        public string Title
        {
            get { return _Title; }
            set { SetField<string>(ref _Title, value); }
        }

        public string Subtitle
        {
            get { return _Subtitle; }
            set { SetField<string>(ref _Subtitle, value); }
        }

        public long Length
        {
            get { return _Length; } 
            set {  SetField<long>(ref _Length, value); }
        }

        public string Publisher
        {
            get { return _Publisher; }
            set { SetField<string>(ref _Publisher, value);  }
        }

        public long SeriesId
        {
            get { return _SeriesId; }
            set { SetField<long>(ref _SeriesId, value); }
        }

        public long SeriesPos
        {
            get { return _SeriesPos; }
            set { SetField<long>(ref _SeriesPos, value); }
        }

        public string SeriesName
        {
            get { return _SeriesName; }
            set { SetField<string>(ref _SeriesName, value); }
        }

        public string Author
        {
            get { return _Author; }
            set { SetField<string>(ref _Author, value); }
        }
        public string Genre
        {
            get { return _Genre; }
            set { SetField<string>(ref _Genre, value); }
        }
        // public virtual ICollection<Author> Authors { get; set; }

        public override string ToString()
        {
            return _Title;
        }
    }
}
