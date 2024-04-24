using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProgrammingLanguages
{
  class Program
  {
    static void Main()
    {
      List<Language> languages = File.ReadAllLines("./languages.tsv")
        .Skip(1)
        .Select(line => Language.FromTsv(line))
        .ToList();

        foreach (Language lang in languages)
        {
          //Console.WriteLine(lang.Prettify());
        }

        var basicInfos = languages.Select(x => $"{x.Year}, {x.Name}, {x.ChiefDeveloper}");

        foreach (var lang in basicInfos)
        {
          //Console.WriteLine(lang);
        }

        var csharpLangs = languages.Where(x => x.Name == "C#");

        foreach (var lang in csharpLangs)
        {
          //Console.WriteLine(lang.Prettify());
        }

        var microsofts = languages.Where(x => x.ChiefDeveloper == "Microsoft");

        foreach (var lang in microsofts)
        {
          //Console.WriteLine(lang.Prettify());
        }

        var lispDescendants = languages.Where(x => x.Predecessors.Contains("Lisp"));

        foreach (var lang in lispDescendants)
        {
          //Console.WriteLine(lang.Prettify());
        }

        var containsScript = languages
        .Where(x => x.Name.Contains("Script"))
        .Select(x => x.Name);

        foreach (var lang in containsScript)
        {
          //Console.WriteLine(lang);
        }

        //Console.WriteLine($"Number of languages: {languages.Count}");

        var nearMilleniumLangs = languages
        .Where(x => x.Year >= 1995 && x.Year <= 2005)
        .Select(x => $"{x.Name} was invented in {x.Year}");
        
        foreach (var lang in nearMilleniumLangs)
        {
          //Console.WriteLine(lang);
        }

        //PrettyPrintAll(lispDescendants);
        //PrintAll(nearMilleniumLangs);


    }

    public static void PrettyPrintAll(IEnumerable<Language> langs)
    {
        foreach (Language lang in langs) {
            Console.WriteLine(lang.Prettify());
        }
      

    }

    public static void PrintAll(IEnumerable<Object> langs) {
        foreach (Object lang in langs) {
            Console.WriteLine(lang);
        }
    }
  }
}