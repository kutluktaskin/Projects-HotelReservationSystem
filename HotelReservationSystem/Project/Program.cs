using System;
//Temel işlevleri sağlayan bir kütüphanedir.
using System.Collections.Generic;
//Temel koleksiyon sınıflarını içerir (List, Dictionary, vb.).
using System.Diagnostics;
//Uygulamalarınızın çalışma süreci ve performansıyla ilgili bilgileri toplamanıza ve işlemenize olanak tanır.


class Hotel
{
    // odalar adında oda nesne listesini get,set ile okuma ve yazma işlemi ayarlanıyor.
    public string Name { get; set; }
    public List<Room> Rooms { get; set; }

    // Otel sınıfının yapıcı metodu
    public Hotel(string Room)
    {
        //Odaların listesi oluşturulup oda çeşit nesneleri ekleniyor.

        Rooms = new List<Room>();
        Rooms.Add(new normalRoom(1));
        Rooms.Add(new largeNormalRoom(2));
        Rooms.Add(new premiumRoom(3));
        Rooms.Add(new largePremiumRoom(4));
        Rooms.Add(new kingSuite(5));
        Rooms.Add(new largeKingSuite(6));

    }

    // Odayı otel listesine ekleyen metot
    public void addRoom(Room room)
    {
        Rooms.Add(room);
    }
}

abstract class Room
{
    //abstract(soyut) oda sınıfı içinde kullanılacak olan sınıfları get,set ile okuma ve yazma işlemi ayarlanıyor.
    public int roomNumber { get; set; }
    public string customerName { get; set; }
    public string customerSurname { get; set; }
    public int numberOfDaysToStay { get; set; }
    public int numberOfPeople { get; set; }
    public int numberOfHoursToStay { get; set; }






    // Oda sınıfının yapıcı metodu
    public Room(int RoomNumber, int RoomPersonCapacity)
    {
        //Gerekli olan bilgiler tanımlanıyor.
        roomNumber = RoomNumber;
        customerName = "";
        customerSurname = "";
        numberOfDaysToStay = 0;
        numberOfPeople = 0;
        numberOfHoursToStay = 0;



    }
    // Oda fiyatını hesaplamak için soyut metot
    public abstract decimal calculatePrice();
    // decimal burda ikili bir tam sayı değerini tutuyor.

}

class normalRoom : Room
{
    public normalRoom(int roomNumber) : base(roomNumber, 1) { }

    public override decimal calculatePrice()
    {
        if (numberOfHoursToStay > 0)
        {
            // Saatlik ücret girildi.
            return numberOfHoursToStay * 8;
        }
        else
        {
            // Günlük ücret girildi.
            return numberOfDaysToStay * 100;
        }
    }
}
// Diğer alt sınıflar için de benzer değerlendirmeler yapılabilir.


//NormalOdaGenis adında alt sınıf oluşturuldu.
class largeNormalRoom : Room

{
    public largeNormalRoom(int roomNumber) : base(roomNumber, 2) { }

    public override decimal calculatePrice()
    {
        if (numberOfHoursToStay > 0)
        {
            // Saatlik ücret girildi.
            return numberOfHoursToStay * 10;
        }
        else
        {
            // Günlük ücret girildi.
            return numberOfDaysToStay * 150;
        }
    }
}

//PremiumOda adında alt sınıf oluşturuldu.
class premiumRoom : Room

{
    public premiumRoom(int roomNumber) : base(roomNumber, 3) { }

    public override decimal calculatePrice()
    {
        if (numberOfHoursToStay > 0)
        {
            // Saatlik ücret girildi.
            return numberOfHoursToStay * 15;
        }
        else
        {
            // Günlük ücret girildi.
            return numberOfDaysToStay * 200;
        }
    }
}


class largePremiumRoom : Room
//PremiumOdaGenis adında alt sınıf oluşturuldu.
{
    public largePremiumRoom(int roomNumber) : base(roomNumber, 4) { }

    public override decimal calculatePrice()
    {
        if (numberOfHoursToStay > 0)
        {
            // Saatlik ücret girildi.
            return numberOfHoursToStay * 20;
        }
        else
        {
            // Günlük ücret girildi.
            return numberOfDaysToStay * 250;
        }
    }
}

//KralDairesi adında alt sınıf oluşturuldu.
class kingSuite : Room

{
    public kingSuite(int roomNumber) : base(roomNumber, 5) { }

    public override decimal calculatePrice()
    {
        if (numberOfHoursToStay > 0)
        {
            // Saatlik ücret girildi.
            return numberOfHoursToStay * 30;
        }
        else
        {
            // Günlük ücret girildi.
            return numberOfDaysToStay * 350;
        }
    }
}

//KralDairesiGenis adında alt sınıf oluşturuldu.
class largeKingSuite : Room

{
    public largeKingSuite(int roomNumber) : base(roomNumber, 6) { }

    public override decimal calculatePrice()
    {
        if (numberOfHoursToStay > 0)
        {
            // Saatlik ücret girildi.
            return numberOfHoursToStay * 40;
        }
        else
        {
            // Günlük ücret girildi.
            return numberOfDaysToStay * 450;
        }
    }
}



class Program
{
    static Dictionary<string, string> userCredentials = new Dictionary<string, string>
    {
        {"gurkan", "123"},
        {"kutluk", "456"}

    };
    //userCredentials adlı bir sözlük kullanıcı adlarına karşılık gelen şifreleri içerir.

    static void Main()
    {
        Console.WriteLine("Welcome to the Hotel Reservation System");
        Console.Write("Username: ");
        string username = Console.ReadLine();

        Console.Write("Password: ");
        string password = ReadPassword();

        if (AuthenticateUser(username, password))
        {
            Console.WriteLine("Login successful!");
            StartHotelReservationSystem();
        }
        else
        {
            Console.WriteLine("Invalid username or password. Exiting...");
        }
    }

    static bool AuthenticateUser(string username, string password)
    //AuthenticateUser fonksiyonu kullanıcının doğruluğunu kontrol eder.
    {
        if (userCredentials.ContainsKey(username) && userCredentials[username] == password)
        {
            return true;
        }
        return false;
    }
    
    //Girişte girilen şifrenin yıldız olarak gösterilmesi.
    static string ReadPassword()
    {
        string password = "";
        ConsoleKeyInfo key;

        do
        {
            key = Console.ReadKey(true);

            //backspace tuşunun çalışmaması sağlandı.
            if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
            {
                password += key.KeyChar;
                Console.Write("*");
            }
            else
            {
                if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Substring(0, (password.Length - 1));
                    Console.Write("\b \b");
                }
            }
        }
        while (key.Key != ConsoleKey.Enter);

        Console.WriteLine(); 
        return password;
    }

    

    //menü 
    static void StartHotelReservationSystem()
    {
        Hotel hotel = new Hotel("Lüx Hotel");

        while (true)
        {
            Console.WriteLine("\n--- Hotel Reservation System ---");
            Console.WriteLine("1. View Hotel Status");
            Console.WriteLine("2. Make a Reservation");
            Console.WriteLine("3. Delete Reservation");
            Console.WriteLine("4. Change Customer Information");
            Console.WriteLine("5. View Total Amount");
            Console.WriteLine("6. Exit");
            //Konsolda küçük bir menü yapıldı.

            Console.WriteLine("What is your choise?: ");
            string choice = Console.ReadLine();
            //swich-case ile istenen fonskiyona gidildi.
            switch (choice)
            {
                case "1":
                    viewHotelStatus(hotel);
                    break;
                case "2":
                    makeAReservation(hotel);
                    break;
                case "3":
                    deleteReservation(hotel);
                    break;
                case "4":
                    changeCustomerInformation(hotel);
                    break;
                case "5":
                    viewTotalAmount(hotel);
                    break;
                case "6":
                    Exit(hotel);
                    break;
                default:
                    Console.WriteLine("Invalid selection. Please try again.");
                    break;
            }
            //Switch komutu ile kullanıcının seçtiği seçeneğe göre case komutu kullanılarak istenen şeyi kullanıcıya gösterildi.
        }
    }
    
    //otel bilgilerini gösterecek bir fonksiyon oluşturuldu.
    static void viewHotelStatus(Hotel hotel)
    {
        Console.WriteLine($"{hotel.Name} Hotel Status:\n");
        // bilgiler tablo şekline konuldu
        Console.WriteLine("{0,-10} {1,-20} {2,-20} {3,-15} {4,-15} {5,-15}",
                          "Room", "Customer Name", "Customer Surname", "Stay Type", "Stay Duration", "Number of People");
        Console.WriteLine(new string('-', 100));
        //odanın billeri öğrenildi
        foreach (Room room in hotel.Rooms)
        {
            string stayType = "";
            string stayDuration = "";

            if (room.numberOfHoursToStay > 0)
            {
                stayType = "Hourly";
                stayDuration = $"{room.numberOfHoursToStay} hours";
            }
            else if (room.numberOfDaysToStay > 0)
            {
                stayType = "Daily";
                stayDuration = $"{room.numberOfDaysToStay} days";
            }
            //son olarak da tabloya yerleştirildi.
            Console.WriteLine("{0,-10} {1,-20} {2,-20} {3,-15} {4,-15} {5,-15}",
                              room.roomNumber, room.customerName, room.customerSurname, stayType, stayDuration, room.numberOfPeople);
        }
    }
    //rezervasyon oluşturma fonksiyonu oluşturuldu.
    static void makeAReservation(Hotel hotel)
    {
        //temel bilgiler kullanıcıya soruldu.
        Console.Write("Customer name: ");
        string Name = Console.ReadLine();

        Console.Write("Customer Surname: ");
        string Surname = Console.ReadLine();

        Console.Write("How many people?: ");
        int numberOfPeople;
        while (!int.TryParse(Console.ReadLine(), out numberOfPeople) || numberOfPeople <= 0)
        {
            Console.WriteLine("Invalid number of people. Please enter a positive integer.");
            Console.Write("How many people?: ");
        }
        //kullanıcıya otelde günlük mü yoksa saatlik mi kalındığı soruldu.
        Console.Write("Stay hourly (1) or daily (2)? Enter 1 or 2: ");
        int stayOption;
        while (!int.TryParse(Console.ReadLine(), out stayOption) || (stayOption != 1 && stayOption != 2))
        {
            Console.WriteLine("Invalid option. Please enter 1 for hourly or 2 for daily.");
            Console.Write("Stay hourly (1) or daily (2)? Enter 1 or 2: ");
        }
        //eğer saatlik kalacaksa ona göre kullanıcıya sorular yöneltildi.
        if (stayOption == 1)
        {
            Console.Write("Number of Hours to Stay: ");
            int numberOfHoursToStay;
            while (!int.TryParse(Console.ReadLine(), out numberOfHoursToStay) || numberOfHoursToStay <= 0 || numberOfHoursToStay > 24)
            {
                Console.WriteLine("Invalid number of hours. Please enter a value between 1 and 24.");
                Console.Write("Number of Hours to Stay: ");
            }

            Console.Write("\nWhich room ?\n 1-Normal (for 1 people---> 1 single bed.),\n 2-Normal Large (for 2 people---> 2 single bed.),\n 3-Premium (for 3 people---> 1 single bed and 1 double bed.),\n 4-Premium Large (for 4 people--->2 single bed and 1 double bed.),\n 5-King Suite (for 5 people--->1 single bed and 2 double bed.),\n 6-King Suite Large ( for 6 people--->4 single bed and 1 double bed.): "); //Kullanıcıya hangi odayı istediğini sorduk.            
            int RoomNumber;
            while (!int.TryParse(Console.ReadLine(), out RoomNumber) || RoomNumber < 1 || RoomNumber > 6)
            {
                Console.WriteLine("Invalid room number. Please enter again.");
                Console.Write("\nWhich room ?\n 1-Normal (for 1 people---> 1 single bed.),\n 2-Normal Large (for 2 people---> 2 single bed.),\n 3-Premium (for 3 people---> 1 single bed and 1 double bed.),\n 4-Premium Large (for 4 people--->2 single bed and 1 double bed.),\n 5-King Suite (for 5 people--->1 single bed and 2 double bed.),\n 6-King Suite Large ( for 6 people--->4 single bed and 1 double bed.): "); //Kullanıcıya hangi odayı istediğini sorduk.            

            }
            Room targetRoom = hotel.Rooms.Find(room => room.roomNumber == RoomNumber);
            //oda yazılan özelliklere göre dolduruldu.
            if (targetRoom != null && targetRoom.customerName == "")
            {
                targetRoom.customerName = Name;
                targetRoom.customerSurname = Surname;
                targetRoom.numberOfHoursToStay = numberOfHoursToStay;
                targetRoom.numberOfPeople = numberOfPeople;

                Console.WriteLine($"{Name} {Surname}, room no:{RoomNumber}, For {numberOfPeople} person, Made a reservation for {numberOfHoursToStay} hours.");
            }
            //eğer oda hali hazırda dolu ise hata mesajı dönülür.
            else
            {
                Console.WriteLine($"Room {RoomNumber} is full.");
            }
        }
        //eğer günlük kalacaksa ona göre kullanıcıya sorular yöneltildi.
        else if (stayOption == 2)
        {
            //yukarda da olduğu gibi burda da aynı şeyleri yapıyoruz.
            Console.Write("Number of Days to Stay: ");
            int numberOfDaysToStay;
            while (!int.TryParse(Console.ReadLine(), out numberOfDaysToStay) || numberOfDaysToStay <= 0)
            {
                Console.WriteLine("Invalid number of days. Please enter a positive integer.");
                Console.Write("Number of Days to Stay: ");
            }

            Console.Write("\nWhich room ?\n 1-Normal (for 1 people---> 1 single bed.),\n 2-Normal Large (for 2 people---> 2 single bed.),\n 3-Premium (for 3 people---> 1 single bed and 1 double bed.),\n 4-Premium Large (for 4 people--->2 single bed and 1 double bed.),\n 5-King Suite (for 5 people--->1 single bed and 2 double bed.),\n 6-King Suite Large ( for 6 people--->4 single bed and 1 double bed.): "); //Kullanıcıya hangi odayı istediğini sorduk.            
            int RoomNumber;
            while (!int.TryParse(Console.ReadLine(), out RoomNumber) || RoomNumber < 1 || RoomNumber > 6)
            {
                Console.WriteLine("Invalid room number. Please enter again.");
                Console.Write("\nWhich room ?\n 1-Normal (for 1 people---> 1 single bed.),\n 2-Normal Large (for 2 people---> 2 single bed.),\n 3-Premium (for 3 people---> 1 single bed and 1 double bed.),\n 4-Premium Large (for 4 people--->2 single bed and 1 double bed.),\n 5-King Suite (for 5 people--->1 single bed and 2 double bed.),\n 6-King Suite Large ( for 6 people--->4 single bed and 1 double bed.): "); //Kullanıcıya hangi odayı istediğini sorduk.            
            }

            Room targetRoom = hotel.Rooms.Find(room => room.roomNumber == RoomNumber);

            if (targetRoom != null && targetRoom.customerName == "")
            {
                targetRoom.customerName = Name;
                targetRoom.customerSurname = Surname;
                targetRoom.numberOfDaysToStay = numberOfDaysToStay;
                targetRoom.numberOfPeople = numberOfPeople;

                Console.WriteLine($"{Name} {Surname}, room no:{RoomNumber}, For {numberOfPeople} person, Made a reservation for {numberOfDaysToStay} days.");
            }
            else
            {
                Console.WriteLine($"Room {RoomNumber} is full or invalid or has too many people.");
            }
        }
        else
        {
            Console.WriteLine("Invalid option. Please enter 1 for hourly or 2 for daily.");
        }
    }
    //Rezervasyon silinmesi fonskiyonu oluşturuldu.
    static void deleteReservation(Hotel hotel)
    {
        Console.Write("\nWhich room? \n1-Normal ,\n 2-Normal Large ,\n 3-Premium ,\n 4-Premium Large ,\n 5-King Suite ,\n 6-King Suite Large\n: ");

        int roomNumber;
        while (!int.TryParse(Console.ReadLine(), out roomNumber) || roomNumber < 1 || roomNumber > 6)
        {
            Console.WriteLine("Invalid room number. Please enter again.");
            Console.Write("\nWhich room? \n1-Normal ,\n 2-Normal Large ,\n 3-Premium ,\n 4-Premium Large ,\n 5-King Suite ,\n 6-King Suite Large\n: ");
        }

        // oda bulunur
        Room targetRoom = hotel.Rooms.Find(room => room.roomNumber == roomNumber);

        // odanın dolu olup olmadığı kontrol ederiz.
        if (targetRoom != null && targetRoom.customerName != "")
        {
            Console.WriteLine($"Reservation for room {roomNumber}:");
            Console.WriteLine($"Customer Name: {targetRoom.customerName}");
            Console.WriteLine($"Customer Surname: {targetRoom.customerSurname}");
            Console.WriteLine($"Number of Days to Stay: {targetRoom.numberOfDaysToStay}");
            Console.WriteLine($"Number of People: {targetRoom.numberOfPeople}");

            //Kullanıcıya  emin misin sorusu sorduk
            Console.Write("Are you sure you want to delete this reservation? (1-Yes, 2-No): ");
            string confirmation = Console.ReadLine();

            //Eğer cevap evet ise oda silinir
            if (confirmation == "1")
            {
                Console.WriteLine($"Reservation for room {roomNumber} was deleted. {targetRoom.customerName} {targetRoom.customerSurname}, {targetRoom.numberOfDaysToStay} day, {targetRoom.numberOfPeople} person");
                targetRoom.customerName = "";
                targetRoom.customerSurname = "";
                targetRoom.numberOfDaysToStay = 0;
                targetRoom.numberOfPeople = 0;
            }
            //eğer cevap hayır ise rezervasyon silme iptal edildi mesajı verdik
            else if (confirmation == "2")
            {
                Console.WriteLine("Reservation deletion canceled.");
            }
            //farklı numaraların girilmesi durumunda kullanıcıya hata mesajı verdik.
            else
            {
                Console.WriteLine("Invalid input. Reservation deletion canceled.");
            }
        }
        //oda boş ise kullanıcıya hata mesajı verdik.
        else
        {
            Console.WriteLine($"Room {roomNumber} is either empty or has no reservation.");
        }
    }

    //müşterilerin bilgilerini değiştirebiliceğimiz fonksiyon oluşturuldu.
    static void changeCustomerInformation(Hotel hotel)
    {
        //kullanıcıya hangi odanın bilgilerini değiştireceği sorduk
        Console.Write("Enter the room number for which you want to change customer information:\n1-Normal ,\n 2-Normal Large ,\n 3-Premium ,\n 4-Premium Large ,\n 5-King Suite ,\n 6-King Suite Large\n: ");
        int roomNumber;
        //Kullanıcının 1 ila 6 arası numara girildiği kontrol edildi.
        while (!int.TryParse(Console.ReadLine(), out roomNumber) || roomNumber < 1 || roomNumber > 6)
        {
            Console.WriteLine("Invalid room number. Please enter again.");
            Console.Write("Enter the room number for which you want to change customer information:\n1-Normal ,\n 2-Normal Large ,\n 3-Premium ,\n 4-Premium Large ,\n 5-King Suite ,\n 6-King Suite Large\n: ");
        }

        //aranan oda bulundu
        Room targetRoom = hotel.Rooms.Find(room => room.roomNumber == roomNumber);

        //odanın boş olup olmadığı kontrol edildi
        if (targetRoom != null && targetRoom.customerName != "")
        {
            Console.WriteLine($"Current Information for room {roomNumber}:");
            Console.WriteLine($"Customer Name: {targetRoom.customerName}");
            Console.WriteLine($"Customer Surname: {targetRoom.customerSurname}");
            Console.WriteLine($"Number of Days to Stay: {targetRoom.numberOfDaysToStay}");
            Console.WriteLine($"Number of People: {targetRoom.numberOfPeople}");

            //yeni temel bilgiler soruldu.
            Console.WriteLine("Enter the new information:");

            Console.Write("New Customer Name: ");
            targetRoom.customerName = Console.ReadLine();

            Console.Write("New Customer Surname: ");
            targetRoom.customerSurname = Console.ReadLine();

            Console.Write("New Number of Days to Stay: ");
            int newNumberOfDays;
            //kalanıcak günün 0 dan küçük olup olmadığı kontrol edildi.
            while (!int.TryParse(Console.ReadLine(), out newNumberOfDays) || newNumberOfDays <= 0)
            {
                Console.WriteLine("Invalid number of days. Please enter a positive integer.");
                Console.Write("New Number of Days to Stay: ");
            }
            targetRoom.numberOfDaysToStay = newNumberOfDays;

            Console.Write("New Number of People: ");
            int newNumberOfPeople;
            while (!int.TryParse(Console.ReadLine(), out newNumberOfPeople) || newNumberOfPeople <= 0)
            {

                Console.Write("New Number of People: ");
            }
            targetRoom.numberOfPeople = newNumberOfPeople;
            // yeni bilgilerin girildiği kullanıcıya mesaj olarak verildi.
            Console.WriteLine($"Customer information for room {roomNumber} has been updated.");
        }
        // oda hali hazırda boş ise kullanıcıya hata mesajı verildi.
        else
        {
            Console.WriteLine($"Room {roomNumber} is either empty or has no reservation.");
        }
    }

    //toplam tutarı gösteren fonksiyon oluşturuldu.
    static void viewTotalAmount(Hotel hotel)
    {
        decimal totalAmount = 0;
        decimal customerPrice = 0;

        //foreach ile odaları gezerek dolu odaların ne kadar fiyat ödeceğini gösterdik ve en sonunda toplam ödenecek fiyat kullanıcıya gösterildi.
        foreach (Room room in hotel.Rooms)
        {
            if (room.customerName != "")
            {
                customerPrice = room.calculatePrice();
                totalAmount += customerPrice;


                Console.WriteLine($"{room.roomNumber}. Room: {room.customerName} {room.customerSurname}, {room.numberOfDaysToStay} day,{room.numberOfHoursToStay} hours, for {room.numberOfPeople} people {customerPrice} $");
            }



        }

        Console.WriteLine($"\nTotal Amount: {totalAmount} $");
    }
    //çıkış fonksiyonu oluşturuldu
    static void Exit(Hotel hotel)
    {
        Console.WriteLine("Exit...");
        Environment.Exit(0);


    }
}
