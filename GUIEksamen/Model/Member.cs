using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Day> Days { get; set; }
    }
}
