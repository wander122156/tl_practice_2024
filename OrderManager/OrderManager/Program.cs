static class Program
{
    public static void Main( string[] args )
    {
        AddNewProduct();

        string product = ReadInput( "Название товара: " );
        int count = ReadProductQuantity();
        string name = ReadInput( "Имя пользователя: " );
        string address = ReadInput( "Адрес доставки: " );

        ConfirmNewProduct( product, count, name, address );
    }

    static void AddNewProduct()
    {
        Console.WriteLine( "Добавление нового товара " );
    }

    private static string ReadInput( string param )
    {
        Console.Write( param );
        string inputName = Console.ReadLine();
        while ( string.IsNullOrWhiteSpace( inputName ) )
        {
            inputName = Console.ReadLine();
        }

        return inputName;
    }
    static int ReadProductQuantity()
    {
        Console.Write( "Количество товара: " );
        int productQuantity;
        while ( !int.TryParse( Console.ReadLine(), out productQuantity ) )
        {
            Console.WriteLine( "неверный ввод" );
        }

        return productQuantity;
    }
    static void ConfirmNewProduct( string product, int count, string name, string address )
    {
        Console.WriteLine( $"Здравствуйте, {name}, вы заказали {count} {product} на адрес {address}, все верно? (да/нет)" );

        while ( true )
        {
            string confirmation = Console.ReadLine().ToLower();
            if ( confirmation == "да" )
            {
                Console.WriteLine( $"{name}! Ваш заказ {product} в количестве {count} оформлен! Ожидайте доставку по адресу {address} к завтрашнему дню" );
                break;
            }
            else if ( confirmation == "нет" )
            {
                Console.WriteLine( "Ваш заказ отменен" );
                break;
            }
            else
            {
                Console.WriteLine( "неверный ответ" );
            }
        }
    }
}