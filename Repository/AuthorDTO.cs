namespace LibraryApplication.Repository
#nullable disable
{
    public class AuthorDTO : BaseDTO
    {
        private long _Id;
        private string _Name;

        public long Id
        {
            get { return _Id; }
            set {  SetField(ref _Id, value); }
        }

        public string Name
        {
            get { return _Name; }
            set { SetField(ref _Name, value); }
        }

        public override string ToString()
        {
            return _Name;
        }
    }
}
