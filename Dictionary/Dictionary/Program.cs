using System.Net;
using System.Text;
using System.Xml.Linq;
class Program
{
    private static Dictionary<string, string> myDictionary = new Dictionary<string, string>();
    private static string filePath = "C:\\Users\\Admin\\source\\tl_practice_2024\\Dictionary\\Dictionary\\RusEngDictionary.txt";

    static void Main( string[] args )
    {
        LoadDictionary();
        ShowMenu();
    }

    static void ShowMenu()
    {
        while ( true )
        {
            Console.WriteLine();//пустая строка для красоты
            Console.WriteLine( "Выберите опцию:" );
            Console.WriteLine( "[1] Перевести слово" );
            Console.WriteLine( "[2] Добавить новое слово" );
            Console.WriteLine( "[3] Выйти" );
            string choice = Console.ReadLine();

            switch ( choice )
            {
                case "1":
                    TranslateWord();
                    break;
                case "2":
                    AddNewWord();
                    break;
                case "3":
                    SaveDictionary();
                    return;
                default:
                    Console.WriteLine( "Неверный ввод, попробуйте снова" );
                    break;
            }
        }
    }

    static void LoadDictionary()
    {
        using ( StreamReader sr = new StreamReader( filePath, Encoding.Default ) )
        {
            while ( File.Exists( filePath ) )
            {
                string line = sr.ReadLine();
                if ( line != null )
                {
                    line = line.ToLower();
                    string[] parts = line.Split( ':' );
                    if ( parts.Length == 2 )
                    {
                        string EngWord = parts[ 0 ].Trim();
                        string RusWord = parts[ 1 ].Trim();
                        myDictionary[ EngWord ] = RusWord;
                    }
                }
                else
                {
                    break;
                }

            }
        }
    }
    static void TranslateWord()
    {
        Console.Write( "Введите слово для перевода: " );
        string word = Console.ReadLine().ToLower().Trim();

        if ( myDictionary.ContainsKey( word ) )//значение по ключу
        {
            Console.WriteLine( $"Перевод: {myDictionary[ word ]}" );
        }
        else if ( myDictionary.ContainsValue( word ) )//ключ по значению
        {
            foreach ( var wordvalue in myDictionary )
            {
                if ( wordvalue.Value == word )
                {
                    Console.WriteLine( $"Перевод: {wordvalue.Key}" );
                }
            }
        }
        else
        {
            ConfirmWordAdd( word );
        }
    }

    static void ConfirmWordAdd( string word )
    {
        Console.WriteLine( "Слово отсутствует в словаре." );
        Console.Write( "Хотите добавить его? (да/нет): " );
        while ( true )
        {
            string confirmation = Console.ReadLine().ToLower().Trim();
            if ( confirmation == "да" )
            {
                AddNewWord();
                break;
            }
            else if ( confirmation == "нет" )
            {
                Console.WriteLine( "Слово не будет добавлено в словарь" );
                break;
            }
            else
            {
                Console.WriteLine( "неверный ответ" );
            }
        }
    }
    static void AddNewWord()
    {
        Console.Write( "Введите слово на английском: " );
        string englishWord = Console.ReadLine();
        Console.Write( "Введите перевод на русском: " );
        string russianWord = Console.ReadLine();

        if ( !myDictionary.ContainsKey( englishWord ) )
        {
            myDictionary[ englishWord ] = russianWord;
            Console.WriteLine( "Слово успешно добавлено." );
        }
        else
        {
            Console.WriteLine( "Слово уже существует в словаре." );
        }
    }
    static void SaveDictionary()
    {
        var lines = new List<string>();
        foreach ( var kvp in myDictionary )
        {
            lines.Add( $"{kvp.Key}:{kvp.Value}" );
        }
        File.WriteAllLines( filePath, lines );
    }
}