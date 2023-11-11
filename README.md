# WeatherAggregatorSln
## Постановка задачи (3 тестовое задание)
Реализовать RESTful сервис, который возвращает информацию из нескольких погодных сервисов.

## Использованные технологии
Язык: .NET C#;
DB: Нет необходимости создавать базу данных. Вся информация о погоде хранится в базе данных подключеных сервисов;
Документация: Swagger;
Архитектура: ASP.NET MVC;

## Реализация

Реализованный Веб сервис принимает HTTP запросы и генерируют ответы, содержащие данные. REST сервер идентифицирует ресурс с помощью URL. URL указывает путь к ресурсу.
RESTFul сервис принимает Get HTTP запросы.

Все NuGet пакеты добавлялись в проект с использованием PowerShell команд.

Были разработанны модели OpenWeather, Services, TomorrowWeather, Weather. Унифицировання информация хранится в моделях Weather. Модель Services хранит в себе статус сервиса(isActive).

Основная часть веб сервиса была реализована в Контроллерах (Controllers). Actions или методы контроллера обрабатывают HTTP-запросы и возвращают JSON или XML в ответ.

В данном проекте документация разработана при помощи Swagger.
