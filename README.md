# WeatherAggregatorSln
## Постановка задачи (3 тестовое задание)
Реализовать RESTful сервис, который возвращает информацию из нескольких погодных сервисов.

## Использованные технологии
Язык: .NET C#;

DB: Нет необходимости создавать базу данных. Вся информация о погоде хранится в базе данных подключеных сервисов;

Документация: Swagger;

Frameworks: Newtonsoft.Json

Архитектура: ASP.NET MVC;

## Реализация
Реализованный Веб сервис принимает HTTP запросы и генерируют ответы, содержащие данные. REST сервер идентифицирует ресурс с помощью URL. URL указывает путь к ресурсу.
RESTFul сервис принимает Get HTTP запросы.

Все NuGet пакеты добавлялись в проект с использованием PowerShell команд.

Были разработанны модели OpenWeather, Services, TomorrowWeather, Weather. Унифицированная информация хранится в моделях Weather. Модель Services хранит в себе статус сервиса(isActive).

Основная часть веб сервиса была реализована в контроллере WeatherController. Actions или методы контроллера обрабатывают HTTP-запросы и возвращают JSON или XML в ответ.

Логи реализованы в файле Logger. Логи выводятся в PowerShell(или cmd). В логах можно посмотреть, какие действия совершал клиент, и с какой скоростью выполнялись запросы к сервисам. 

Идентификация к запросам производилась при помощи ключа(ключи расположены в secret json документе, расположенного вне репозитория). Идентификация реализована в Authentication.
Ключ вводится в интерфейсе Swagger при помощи кнопки Authentication. Если ключ введен неверно, то выведется на экран "Invalid Api Key", если ключ не введен, то "Api Key was not provided".

В данном проекте документация разработана при помощи Swagger.

В планах создание Docker файла для развертывания сервиса, разработка юнит тестов и добавление Front-End части.
