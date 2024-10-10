using System;
using System.Collections.Generic;

class MedicalService
{
    protected string serviceName;
    protected double cost;
    protected int duration;

    public string ServiceName
    {
        get { return serviceName; }
        set { serviceName = value; }
    }

    public double Cost
    {
        get { return cost; }
        set { cost = value; }
    }

    public int Duration
    {
        get { return duration; }
        set { duration = value; }
    }

    public MedicalService()
    {
        serviceName = "Untitled Service";
        cost = 100;
        duration = 60;
    }

    public MedicalService(string serviceName, double cost, int duration)
    {
        this.serviceName = serviceName;
        this.cost = cost;
        this.duration = duration;
    }

    public virtual void ProvideService()
    {
        Console.WriteLine($"Послуга {serviceName} надана. Тривалість: {duration} хвилин, Вартість: {cost} грн.");
    }

    public virtual void GetServiceDetails()
    {
        Console.WriteLine($"Назва послуги: {serviceName}, Вартість: {cost} грн, Тривалість: {duration} хвилин.");
    }

    // Метод для розрахунку загальної вартості з додатковими витратами
    public double CalculateTotalCost(double additionalExpenses)
    {
        return cost + additionalExpenses;
    }

    // Метод ToString() для виведення інформації про послугу
    public override string ToString()
    {
        return $"Назва: {serviceName}, Тривалість: {duration} хвилин, Вартість: {cost} грн.";
    }
}

class SurgeryService : MedicalService
{
    private string surgeryType;

    public SurgeryService(string serviceName, double cost, int duration, string surgeryType)
        : base(serviceName, cost, duration)
    {
        this.surgeryType = surgeryType;
    }

    public void SetSurgeryType(string type)
    {
        surgeryType = type;
        Console.WriteLine($"Тип хірургії встановлено як {surgeryType}.");
    }

    public override void ProvideService()
    {
        Console.WriteLine($"Хірургічне втручання {surgeryType} проведено. Тривалість: {duration} хвилин, Вартість: {cost} грн.");
    }

    public override void GetServiceDetails()
    {
        base.GetServiceDetails();
        Console.WriteLine($"Тип хірургії: {surgeryType}");
    }

    // Перевизначення методу ToString() для SurgeryService
    public override string ToString()
    {
        return $"Назва: {serviceName}, Тип хірургії: {surgeryType}, Тривалість: {duration} хвилин, Вартість: {cost} грн.";
    }
}

class ConsultationService : MedicalService
{
    private string doctorName;

    public string DoctorName
    {
        get { return doctorName; }
        set { doctorName = value; }
    }

    public ConsultationService(string serviceName, double cost, int duration, string doctorName)
        : base(serviceName, cost, duration)
    {
        this.doctorName = doctorName;
    }

    public void SetDoctorName(string name)
    {
        doctorName = name;
        Console.WriteLine($"Консультацію проведе лікар {doctorName}.");
    }

    public override void ProvideService()
    {
        Console.WriteLine($"Консультація проведена лікарем {doctorName}. Тривалість: {duration} хвилин, Вартість: {cost} грн.");
    }

    public override void GetServiceDetails()
    {
        base.GetServiceDetails();
        Console.WriteLine($"Лікар: {doctorName}");
    }
}


class Program
{
    static List<MedicalService> selectedServices = new List<MedicalService>();

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        while (true)
        {
            Console.WriteLine("\nОберіть тип медичної послуги:");
            Console.WriteLine("1. Хірургічна послуга");
            Console.WriteLine("2. Консультаційна послуга");
            Console.WriteLine("3. Переглянути та редагувати вибрані послуги");
            Console.WriteLine("4. Розрахувати загальну вартість з додатковими витратами");
            Console.WriteLine("5. Порахувати загальну вартість");
            Console.WriteLine("6. Вийти");
            Console.Write("Ваш вибір: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                // Вибір типу хірургії
                Console.WriteLine("\nОберіть тип хірургії:");
                Console.WriteLine("1. Апендектомія");
                Console.WriteLine("2. Холецистектомія");
                Console.WriteLine("3. Гінекологічна операція");
                Console.WriteLine("4. Пластична хірургія");
                Console.Write("Ваш вибір: ");
                string surgeryChoice = Console.ReadLine();
                string selectedSurgeryType = "";

                switch (surgeryChoice)
                {
                    case "1":
                        selectedSurgeryType = "Апендектомія";
                        break;
                    case "2":
                        selectedSurgeryType = "Холецистектомія";
                        break;
                    case "3":
                        selectedSurgeryType = "Гінекологічна операція";
                        break;
                    case "4":
                        selectedSurgeryType = "Пластична хірургія";
                        break;
                    default:
                        Console.WriteLine("Невірний вибір, операція не створена.");
                        continue; // Повертаємося до початку циклу
                }

                // Створюємо хірургічну послугу з вибраним типом
                SurgeryService surgery = new SurgeryService("Хірургія", 5000, 120, selectedSurgeryType);
                selectedServices.Add(surgery);

                // Виводимо інформацію про хірургічну послугу
                Console.WriteLine($"Операція: {surgery.ServiceName}, Тривалість: {surgery.Duration} хвилин, Вартість: {surgery.Cost} грн, Тип хірургії: {selectedSurgeryType}");
            }
            else if (choice == "2")
            {
                // Вибір лікаря
                Console.WriteLine("\nОберіть лікаря:");
                Console.WriteLine("1. Лікар Іваненко И.М.");
                Console.WriteLine("2. Лікар Петренко Ф.З.");
                Console.WriteLine("3. Лікар Сидоренко Н.С.");
                Console.WriteLine("4. Лікар Коваленко Р.Н.");
                Console.Write("Ваш вибір: ");
                string doctorChoice = Console.ReadLine();
                string selectedDoctor = "";

                switch (doctorChoice)
                {
                    case "1":
                        selectedDoctor = "Лікар Іваненко И.М.";
                        break;
                    case "2":
                        selectedDoctor = "Лікар Петренко Ф.З.";
                        break;
                    case "3":
                        selectedDoctor = "Лікар Сидоренко Н.С.";
                        break;
                    case "4":
                        selectedDoctor = "Лікар Коваленко Р.Н.";
                        break;
                    default:
                        Console.WriteLine("Невірний вибір, лікар залишено без змін.");
                        break;
                }

                if (!string.IsNullOrEmpty(selectedDoctor))
                {
                    // Створюємо консультаційну послугу
                    ConsultationService consultation = new ConsultationService("Консультація", 300, 45, selectedDoctor);
                    selectedServices.Add(consultation);

                    // Виводимо інформацію про консультацію
                    Console.WriteLine($"Консультація проведена лікарем: {consultation.DoctorName}, Тривалість: {consultation.Duration} хвилин, Вартість: {consultation.Cost} грн.");
                }
            }
            else if (choice == "3")
            {
                if (selectedServices.Count == 0)
                {
                    Console.WriteLine("Вибраних послуг немає.");
                    continue;
                }

                Console.WriteLine("\nВаші вибрані послуги:");
                for (int i = 0; i < selectedServices.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {selectedServices[i].ToString()}");
                }

                Console.WriteLine("\nОберіть номер послуги для редагування або видалення (0 для виходу): ");
                string editChoice = Console.ReadLine();

                if (editChoice == "0")
                {
                    continue;
                }

                if (int.TryParse(editChoice, out int serviceIndex) && serviceIndex > 0 && serviceIndex <= selectedServices.Count)
                {
                    var selectedService = selectedServices[serviceIndex - 1];

                    Console.WriteLine("\nОберіть дію:");
                    Console.WriteLine("1. Редагувати послугу");
                    Console.WriteLine("2. Видалити послугу");
                    Console.WriteLine("0. Повернутися до меню");
                    Console.Write("Ваш вибір: ");
                    string actionChoice = Console.ReadLine();

                    if (actionChoice == "1")
                    {
                        // Редагування послуги
                        if (selectedService is SurgeryService surgeryService)
                        {
                            Console.WriteLine("\nОберіть новий тип хірургії:");
                            Console.WriteLine("1. Апендектомія");
                            Console.WriteLine("2. Холецистектомія");
                            Console.WriteLine("3. Гінекологічна операція");
                            Console.WriteLine("4. Пластична хірургія");
                            Console.Write("Ваш вибір: ");
                            string newSurgeryChoice = Console.ReadLine();
                            switch (newSurgeryChoice)
                            {
                                case "1":
                                    surgeryService.SetSurgeryType("Апендектомія");
                                    break;
                                case "2":
                                    surgeryService.SetSurgeryType("Холецистектомія");
                                    break;
                                case "3":
                                    surgeryService.SetSurgeryType("Гінекологічна операція");
                                    break;
                                case "4":
                                    surgeryService.SetSurgeryType("Пластична хірургія");
                                    break;
                                default:
                                    Console.WriteLine("Невірний вибір, зміни не внесено.");
                                    break;
                            }
                        }
                        else if (selectedService is ConsultationService consultationService)
                        {
                            Console.WriteLine("\nОберіть нового лікаря:");
                            Console.WriteLine("1. Лікар Іваненко И.М.");
                            Console.WriteLine("2. Лікар Петренко Ф.З.");
                            Console.WriteLine("3. Лікар Сидоренко Н.С.");
                            Console.WriteLine("4. Лікар Коваленко Р.Н.");
                            Console.Write("Ваш вибір: ");
                            string newDoctorChoice = Console.ReadLine();
                            switch (newDoctorChoice)
                            {
                                case "1":
                                    consultationService.SetDoctorName("Лікар Іваненко И.М.");
                                    break;
                                case "2":
                                    consultationService.SetDoctorName("Лікар Петренко Ф.З.");
                                    break;
                                case "3":
                                    consultationService.SetDoctorName("Лікар Сидоренко Н.С.");
                                    break;
                                case "4":
                                    consultationService.SetDoctorName("Лікар Коваленко Р.Н.");
                                    break;
                                default:
                                    Console.WriteLine("Невірний вибір, зміни не внесено.");
                                    break;
                            }
                        }
                    }
                    else if (actionChoice == "2")
                    {
                        // Видалення послуги
                        selectedServices.RemoveAt(serviceIndex - 1);
                        Console.WriteLine("Послугу видалено.");
                    }
                    else if (actionChoice == "0")
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Невірний вибір, повернення до меню.");
                    }
                }
                else
                {
                    Console.WriteLine("Невірний номер послуги.");
                }
            }

            else if (choice == "4")
            {
                CalculateTotalCostWithExtras();
            }
            else if (choice == "5")
            {
                CalculateTotalCost();
            }
            else if (choice == "6")
            {
                Console.WriteLine("Дякуємо за використання програми!");
                break;
            }
            else
            {
                Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
            }
        }
    }

    static void CalculateTotalCostWithExtras()
    {
        double totalCost = 0;
        foreach (var service in selectedServices)
        {
            totalCost += service.Cost; // Додаємо базову вартість послуг
        }

        Console.Write("Введіть додаткові витрати (ліки, процедури тощо): ");
        double additionalCosts = double.Parse(Console.ReadLine());

        totalCost += additionalCosts; // Додаємо додаткові витрати

        Console.WriteLine($"Загальна вартість з додатковими витратами: {totalCost} грн.");
    }

    static void CalculateTotalCost()
    {
        double totalCost = 0;
        foreach (var service in selectedServices)
        {
            totalCost += service.Cost; // Додаємо базову вартість послуг
        }

        Console.WriteLine($"Загальна вартість послуг: {totalCost} грн.");
    }
}
