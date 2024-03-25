using Module15.Models;
using System.Linq;
using System.Text;

namespace Module15;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        var classes = new[]
        {
            new Classroom(new List<string> {"Олег", "Алена", "Виктория"}),
            new Classroom(new List<string> {"Анна", "Виктор", "Владимир"}),
            new Classroom(new List<string> {"Булат", "Алекс", "Галина"})
        };

        var allStudents = GetAllStudents(classes);

        Console.WriteLine(string.Join(' ', allStudents));
    }

    static string[] GetAllStudents(IEnumerable<Classroom> classes)
    {
        var result = classes.SelectMany(c => c.Students).OrderBy(s => s).ToArray();

        return result;
    }
}