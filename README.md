# MouseMovement

## Описание проекта
MouseMove — это веб-приложение, разработанное с использованием ASP.NET Core Razor Pages и базы данных PostgreSQL. Оно позволяет отслеживать перемещения мыши пользователя и сохранять их координаты в базе данных.

Данное приложение демонстрирует аспекты **Clean Architecture**, при этом:

- **MouseMovement** представляет уровень **Presentation**.
- **MouseMovementContext** представляет уровень **Infrastructure**.
- **MouseMovementApp** соответствует уровню **Application**.
- **MouseMovementDomain** соответствует уровню **Domain**.

Эти слои также отражены в названиях соответствующих проектов.

## Структура проекта
<pre>
MouseMovement
├── MouseMovementDomain/              
│   ├── MouseDataDto/
│   └── ICoordinateRepository/
├── MouseMovementApp/          
│   └── MouseMovementService/
├── MouseMovementContext/      
│   ├── CoordinateRepositories/
│   ├── mousemovementContext/
│   └── Coordinates/
└── MouseMovement/         
    ├── Controllers/
    └── Pages/   
</pre>

### **1. MouseMovementContext**
**MouseMovementContext** содержит контекст базы данных, созданный подходом *Database First* с использованием PostgreSQL. 

- Использует Entity Framework Core для взаимодействия с БД.
- Включает модель `Coordinate`, в которой хранятся координаты движений мыши.

### **2. MouseMovement**
**MouseMovement** — это веб-приложение, построенное на Razor Pages, содержащее:

- **Контроллер** `MouseMoveController`, принимающий данные о перемещениях мыши через API.
- **Страницу Index.cshtml**, которая включает кнопку для отправки собранных координат.
  
### **3. MouseMovementApp**
**MouseMovementApp** — это проект с сервисным классом, который инкапсулирует логику работы с данными о движении мыши. Предоставляет метод для сохранения данных о движении мыши, поступающих в виде объекта MouseDataDTO.

### **3. MouseMovementDomain**
**MouseMovementDomain** занимается представлением и обработкой объектов, связанных с движением мыши.

- **MouseDataDto** является объектом передачи данных, который используется для передачи информации о движении мыши между слоями приложения.
- **ICoordinateRepository** интерфейс описывает контракт для репозитория, который будет работать с данными о координатах. Содержит асинхронный метод AddAsynс.
- 
### **5. MouseMovementTest**
**MouseMovementTest** содержит набор юнит-тестов для контроллера `MouseDataController`. Тесты написаны с использованием библиотеки xUnit.
