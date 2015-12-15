using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2part4
{
    class Tester
    { 
        public static void Main()
        {
            Library lib = new Library
            {
                new Card(
                    Title: "Professional C# 6.0",
                    Author: new List<string> {"Christian Nagel, Morgan Skinner" },
                    CatNum: new LoCnum(1234567890),
                    Subject: new List<string> { "Programming", "C#", "Microsoft" },
                    Publisher: "WROX",
                    WhenPublished: 2016,
                    Circulation: true
                    ),
                new Card(
                    Title: "Beginning Visual C# \n2015 Programming",
                    Author: new List<string> {"Benjamin Perkins, Jacob Vibe \n\t\t\t\t\tHammer, Jon D. Reid\t" },
                    CatNum: new LoCnum(1345678902),
                    Subject: new List<string> {"Programming", "C#", "Microsoft", "Visual Studio" },
                    Publisher: "WROX",
                    WhenPublished: 2015,
                    Circulation: true
                    ),
                new Card(
                    Title: "Beginning ASP .NET 6: \nWeb Forms and MVC",
                    Author: new List<string> {"William Penberthy" },
                    CatNum: new LoCnum(1456789023),
                    Subject: new List<string> {"Programming", "ASP", ".NET", "Microsoft", "MVC", "Web Forms" },
                    Publisher: "WROX",
                    WhenPublished: 2015,
                    Circulation: true
                    ),
                new Card(
                    Title: "C# 24-Hour Trainer",
                    Author: new List<string> {"Rod Stephens\t\t" },
                    CatNum: new LoCnum(1567890234),
                    Subject: new List<string> {"Programming", "C#", "Microsoft" },
                    Publisher: "WROX",
                    WhenPublished: 2015,
                    Circulation: false
                    ),
                new Card(
                    Title: "Professional Visual Studio",
                    Author: new List<string> {"Bruce Johnson" },
                    CatNum: new LoCnum(1678902345),
                    Subject: new List<string> {"Programming", "Microsoft", "Visual Studio" },
                    Publisher: "WROX",
                    WhenPublished: 2015,
                    Circulation: true
                    ),
            };

            Console.WriteLine("\tNow searching subject headings for 'C#'...\n");

            Console.Write(lib.SubjectSearch("C#"));

            Console.ReadKey();
        }
    }
}

/* Program Output:

        Now searching subject headings for 'C#'...

Title                                   Author                                  LoCnum
Professional C# 6.0                     Christian Nagel, Morgan Skinner         12-34567
Beginning Visual C#
2015 Programming                        Benjamin Perkins, Jacob Vibe
                                        Hammer, Jon D. Reid                     13-45678
C# 24-Hour Trainer                      Rod Stephens                            15-67890

*/
