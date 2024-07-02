AddNewProduct();

string product = ReadProductName();
int count = ReadProductQuantity();
string name = ReadUserName();
string address = ReadAddress();
ConfirmNewProduct( product, count, name, address );

static void AddNewProduct()
{
    Console.WriteLine( "Добавление нового товара " );
}
static string ReadProductName()
{
    Console.Write( "Название товара: " );
    string productName = Console.ReadLine();
    while ( string.IsNullOrWhiteSpace( productName ) )
    {
        productName = Console.ReadLine();
    }

    return productName;
}
static int ReadProductQuantity()
{
    Console.Write( "Количество товара: " );
    int productQuantity;
    while ( !int.TryParse( Console.ReadLine(), out productQuantity ) )
    {
        Console.WriteLine( "Quantity invalid" );
    }

    return productQuantity;
}

static string ReadUserName()
{
    Console.Write( "Имя пользователя: " );
    string userName = Console.ReadLine();
    while ( string.IsNullOrWhiteSpace( userName ) )
    {
        userName = Console.ReadLine();
    }

    return userName;
}

static string ReadAddress()
{
    Console.Write( "Адрес доставки: " );
    string address = Console.ReadLine();
    while ( string.IsNullOrWhiteSpace( address ) )
    {
        address = Console.ReadLine();
    }

    return address;
}
static void ConfirmNewProduct( string product, int count, string name, string address )
{
    Console.WriteLine( $"Здравствуйте, {name}, вы заказали {count} {product} на адрес {address}, все верно? (yes/no)" );

    while ( true )
    {
        string confirmation = Console.ReadLine();
        if ( confirmation == "yes" )
        {
            Console.WriteLine( $"{name}! Ваш заказ {product} в количестве {count} оформлен! Ожидайте доставку по адресу {address} к завтрашнему дню" );
            break;
        }
        else if ( confirmation == "no" )
        {
            Console.WriteLine( "Ваш заказ отменен" );
            break;
        }
        else
        {
            Console.WriteLine( "invalid answer" );
        }
    }
}