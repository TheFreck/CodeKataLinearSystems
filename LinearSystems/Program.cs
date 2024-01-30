//static void Main(string[] args)
//{
//    Console.WriteLine("Here I am");
//    //var equations = new List<string>();
//    //var done = false;
//    //do
//    //{
//    //    if(!string.IsNullOrEmpty(Console.ReadLine())) done = true;
//    //    Console.WriteLine("Enter the first equation in the form: ax+by+cz=d");
//    //    equations.Add(Console.ReadLine());
//    //    Console.WriteLine("Press ENTER to solve if you are done adding equations. Otherwise enter a new equation.");
//    //} while (done);
//    //foreach(var line in equations)
//    //{
//    //    Console.WriteLine(line);
//    //}
//}
using LinearSystems;

var variableSybols = new Dictionary<int, string[]>
{
    { 2,new string[]{"x","y","answer"} },
    { 3,new string[]{"x","y","z","answer"}},
    { 4,new string[]{"w","x","y","z","answer"}},
    { 5,new string[]{"v","w","x","y","z","answer"}},
    { 6,new string[]{"u","v","w","x","y","z","answer"}},
    { 7,new string[]{"t","u","v","w","x","y","z","answer"}},
    { 8,new string[]{"s","t","u","v","w","x","y","z","answer"}},
    { 9,new string[]{"r","s","t","u","v","w","x","y","z","answer"}},
    { 10,new string[]{"q","r","s","t","u","v","w","x","y","z","answer"}},
    { 11,new string[]{"p","q","r","s","t","u","v","w","x","y","z","answer"}}
};
var keepGoing = false;
do
{
    var equations = new List<string>();
    var done = true;
    Console.WriteLine("How many variables/equations in the system?");
    var varInput = Console.ReadLine();
    var varCount = Int32.Parse(varInput);
    var count = 0;
    var eqStringArray = new string[varCount];
    for(var i = 0; i < varCount; i++)
    {
        for(var j = 0; j < varCount+1; j++)
        {
            Console.WriteLine($"Enter the coefficient for {variableSybols[varCount][j]}");
            var eq = Console.ReadLine();
            eqStringArray[i] += eq + " ";
        }
        eqStringArray[i] = eqStringArray[i].Trim(' ');
    }
    var eqString = String.Join("\r\n",eqStringArray);
    var ls = new LinearSystemClass();
    Console.WriteLine(eqString);
    Console.WriteLine(ls.Solve(eqString));
    Console.WriteLine("Would you like to solve another system of equations?");
    var answer = Console.ReadLine();
    if (answer.ToLowerInvariant() == "y" || answer.ToLowerInvariant() == "yes") keepGoing = true;
} while (keepGoing);

Console.WriteLine("So long sukkas!!!");
