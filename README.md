# Albumer

Тестовый проект на вакансию разработчика.

## Задача:

Написать консольное приложение поиска музыкальных альбомов исполнителя. При вводе пользователем названия группы, программа должна запрашивать сервер в поисках списка её альбомов. При отсутствии соединения с сервером, список (если он был загружен ранее) должен подгружаться из локального кэша.

Допускается использование любого сервера с любым API (рекомендуется сервис iTunes как не требующий авторизации). 
Для хранения кэша допускается использование любого носителя (файл, любая база данных).
Допускается использование любых сторонних библиотек.

### Задача. Дополнительный функционал (от себя):

Результат запроса проходит дополнительную фильтрацию: Из списка возвращаемого ITunes исключаются синглы, Deluxe версии и альбомы других исполнителей, где запрашиваемый исполнитель учавствует.

## Реализация:

Консольное приложение циклично запрашивает у пользователя название автора, информацию об альбомах которого он хотел бы получить. После приложение производит запрос на ITunes Search API для получения соответствующей информации. Если в ходе запроса возникает ошибка запрашиваетя локальный кэш. При удачном запросе если был получен хоть один альбом он записывает/обновляет записи в кеше и выводит список альбомов. 

## P.S.:

Проект использует конструкции из C#6 и C#7 поэтому рекомендуется запускать из Visual Studio 2017.
