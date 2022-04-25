namespace LibraryApplication.Repository
#nullable disable
{
    public class GenreDTO : BaseDTO
    {
        private long _Id;
        private string _Genre;

        public long Id
        {
            get { return _Id; }
            set { SetField<long>(ref _Id, value); }
        }

        public string Genre
        {
            get { return _Genre; }
            set { SetField<string>(ref _Genre, value); }
        }

        public override string ToString()
        {
            return _Genre;
        }
    }
}
