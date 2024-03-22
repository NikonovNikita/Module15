using Module15.Models;
using System.Text;

namespace Module15;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
    }

    static void DelayedExecuting(List<Student> students)
    {
        var youngStudents = from s in students where s.Age < 25 select s;

        //Выполнится, когда мы обратимся к переменной youngStudents для получения результата
    }

    static void InstantExecuting(List<Student> students)
    {
        var youngStudents = (from s in students
                            where s.Age < 25
                            select s).ToList();

    }
}