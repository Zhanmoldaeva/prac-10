using System;

public class RoomBookingSystem
{
    public void BookRoom(int roomId)
    {
        Console.WriteLine($"Бөлме {roomId} броньдалды.");
    }

    public void CancelRoomBooking(int roomId)
    {
        Console.WriteLine($"Бөлме {roomId} броньдау тоқтатылды.");
    }

    public bool IsRoomAvailable(int roomId)
    {
        return true;
    }
}

public class RestaurantSystem
{
    public void BookTable(int tableId)
    {
        Console.WriteLine($"Үстел {tableId} броньдалды.");
    }

    public void OrderFood(string food)
    {
        Console.WriteLine($"'{food}' тағамы тапсырыс берілді.");
    }

    public void OrderTaxi()
    {
        Console.WriteLine($"Такси шақырылды.");
    }
}

public class EventManagementSystem
{
    public void BookConferenceRoom(int roomId)
    {
        Console.WriteLine($"Конференц-зал {roomId} броньдалды.");
    }

    public void OrderEquipment(string equipment)
    {
        Console.WriteLine($"'{equipment}' жабдығы тапсырыс берілді.");
    }
}

public class CleaningService
{
    public void ScheduleCleaning(int roomId)
    {
        Console.WriteLine($"Бөлме {roomId} үшін тазалау кестеге енгізілді.");
    }

    public void RequestCleaning(int roomId)
    {
        Console.WriteLine($"Бөлме {roomId} үшін тазалау сұралды.");
    }
}

public class HotelFacade
{
    private RoomBookingSystem _roomBookingSystem;
    private RestaurantSystem _restaurantSystem;
    private EventManagementSystem _eventManagementSystem;
    private CleaningService _cleaningService;

    public HotelFacade()
    {
        _roomBookingSystem = new RoomBookingSystem();
        _restaurantSystem = new RestaurantSystem();
        _eventManagementSystem = new EventManagementSystem();
        _cleaningService = new CleaningService();
    }

    public void BookRoomWithServices(int roomId, string food)
    {
        if (_roomBookingSystem.IsRoomAvailable(roomId))
        {
            _roomBookingSystem.BookRoom(roomId);
            _restaurantSystem.OrderFood(food);
            _cleaningService.ScheduleCleaning(roomId);
        }
    }

    public void OrganizeEvent(int conferenceRoomId, int[] roomIds, string equipment)
    {
        _eventManagementSystem.BookConferenceRoom(conferenceRoomId);
        _eventManagementSystem.OrderEquipment(equipment);
        foreach (var roomId in roomIds)
        {
            _roomBookingSystem.BookRoom(roomId);
        }
    }
    public void BookTableWithTaxi(int tableId)
    {
        _restaurantSystem.BookTable(tableId);
        _restaurantSystem.OrderTaxi();
    }

    public void CancelRoomBooking(int roomId)
    {
        _roomBookingSystem.CancelRoomBooking(roomId);
    }

    public void RequestCleaning(int roomId)
    {
        _cleaningService.RequestCleaning(roomId);
    }
}

class Program
{
    static void Main(string[] args)
    {
        HotelFacade hotel = new HotelFacade();

        hotel.BookRoomWithServices(11, "Пицца");

        hotel.OrganizeEvent(1, new int[] { 11, 12 }, "Проектор");

        hotel.BookTableWithTaxi(5);

        hotel.CancelRoomBooking(11);

        hotel.RequestCleaning(12);
    }
}

/*2 тапсырма
public abstract class OrganizationComponent
{
    protected string name;

    public OrganizationComponent(string name)
    {
        this.name = name;
    }

    public abstract void DisplayStructure(int indent = 0);
    public abstract double GetBudget();
    public abstract int GetEmployeeCount();
}
public class Employee : OrganizationComponent
{
    private string position;
    private double salary;

    public Employee(string name, string position, double salary) : base(name)
    {
        this.position = position;
        this.salary = salary;
    }

    public override void DisplayStructure(int indent = 0)
    {
        Console.WriteLine(new String(' ', indent) + $"{name} - {position} (${salary})");
    }

    public override double GetBudget()
    {
        return salary;
    }

    public override int GetEmployeeCount()
    {
        return 1;
    }
}
public class Department : OrganizationComponent
{
    private List<OrganizationComponent> components = new List<OrganizationComponent>();

    public Department(string name) : base(name) { }

    public void Add(OrganizationComponent component)
    {
        components.Add(component);
    }

    public void Remove(OrganizationComponent component)
    {
        components.Remove(component);
    }

    public override void DisplayStructure(int indent = 0)
    {
        Console.WriteLine(new String(' ', indent) + $"Бөлім: {name}");
        foreach (var component in components)
        {
            component.DisplayStructure(indent + 2);
        }
    }

    public override double GetBudget()
    {
        return components.Sum(c => c.GetBudget());
    }

    public override int GetEmployeeCount()
    {
        return components.Sum(c => c.GetEmployeeCount());
    }
}
class Program
{
    static void Main(string[] args)
    {
        var employee1 = new Employee("раушан", "Бөлім", 54552);
        var employee2 = new Employee("нурлы", "менеджер", 45786);
        var employee3 = new Employee("айкын", "аналитик", +9415);

        var developmentDept = new Department("Бөлім");
        var hrDept = new Department("HR");

        developmentDept.Add(employee1);
        developmentDept.Add(employee3);
        hrDept.Add(employee2);

        var headOffice = new Department("Бас Кеңсе");
        headOffice.Add(developmentDept);
        headOffice.Add(hrDept);

        headOffice.DisplayStructure();

        Console.WriteLine($"Жалпы бюджет: ${headOffice.GetBudget()}");
        Console.WriteLine($"қызметкерлердің Жалпы Саны {headOffice.GetEmployeeCount()}");
    }
}*/