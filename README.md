# .NET_Projekt
Projekt z przedmiotu platf. program. .NET i Java, z zakresu .NET. 

## Spis Treści
* [Wprowadzenie](#wprowadzenie)
* [Podział zadań](#podział-zadań)
* [Technologie](#technologie)

### Wprowadzenie: 
- Wybrana technologia: <br/>
Aplikacja webowa - ASP.NET Core
- Wybrana tematyka: <br/>
Tematem pracy jest aplikacja pozwalająca na wyszukiwanie żartów na podstawie dowolnego słowa. Bazą żartów jest strona https://icanhazdadjoke.com/. Aplikacja pozwala użytkownikowi na rejestację oraz logowanie. W tym celu wykorzystuje bazę danych (komunikacja za pomocą Entity Framework). Po poprawnym zalogowaniu (tzn. zweryfikowaniu poprawności danych z tymi znajdującymi się w bazie) użytkownik może wpisać interesujący go tag, a przefiltrowane żarty zostają wyświetlane na stronie. Dodatkowo, na stronie głównej wyszukiwarki żartów generuje się losowy żart.

### Podział zadań: 
- Jagoda Kubacka (242055): <br/>
stworzenie rejestracji użytkowników oraz logowania. Sprawdzanie poprawności danych z loginu z tymi z rejestracji. Stworzenie pól wymaganych. Dodanie dziennika obsługi zdarzeń.
- Aleksandra Stawarz (241535): <br/>
znalezienie oraz podłączenie API do projektu. Generowanie losowego żartu oraz przeszukiwanie żartów ze względu na przekazane słowo. Dodanie LINQ.
- Agata Mazur (241518): <br/>
realizacja konta użytkownika. Dodanie opcji "dodaj do ulubionych" oraz przekazywanie tego do widoku danego konta. Poprawa wizualnego wyglądu strony.

### Technologie: 
* Komunikacja z bazą danych (Entity Framework)
* LINQ (zadawanie pytań na kolekcjach obiektów o składni podobnej do SQL)
* Komunikacja z zewnętrznym API (wykorzystanie formatu JSON)
* Obsługa wielowątkowości (asynchroniczność)
* Log (obsługa dziennika zdarzeń)
* User Interface (komunikacja z użytkownikiem)
* Wykorzystanie zewnętrznych bibliotek (korzystając z pakietu NuGet)


