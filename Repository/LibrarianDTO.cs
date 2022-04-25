using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable
namespace LibraryApplication.Repository
{
    public class LibrarianDTO : BaseDTO
    {
        private long _Id;
        private string _Name;

        public long Id
        {
            get { return _Id; }
            set { SetField<long>(ref _Id, value); }
        }

        public string Name
        {
            get { return _Name; }
            set { SetField(ref _Name, value); }
        }
    }
}
