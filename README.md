# WebAppEventLog
Задание:
1.Реализовать на asp.net web api  (.net 4.7) сервис
Сервис имеет 1 метод, который получает кол-во событий из EventLog-а windows в группировке по типу события (Предупреждение, Ошибка, Инфо).
Название журнала  и период, за который посчитать  кол-во события, метод получает на вход от клиента в качестве параметров.
(Аутентификация  и проч. инфраструктура не нужны).

                 

2. Реализовать c использованием vue.js  клиент (web-страничка),
который  позволяет указать название журнала и период событий и вызывает метод сервиса из пункта 1.
Ответ от сервиса визуализирует  в произвольной форме. (Находится в index.html)
