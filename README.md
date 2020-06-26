# .NET_Projekt
Projekt z przedmiotu platf. program. .NET i Java, z zakresu .NET. 

## Spis Treści
* [Wprowadzenie](#wprowadzenie)
* [Podział zadań](#podział-zadań)
* [Technologie](#technologie)
* [Dokumnetacja projetktu](#dokumentacja-projektu)

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

### Dokumentacja projektu:
### Realizacja projektu - login oraz rejestracja: 
1. Rejestracja użytkownika: <br/>
![Rejestracja użytkownika](Images/rejestracja.png) <br/>
Rejestracja wymaga pdoania takich danych jak: 
- pierwsze imię
- nazwisko
- e-mail
- hasło <br/>
Email oraz hasło są wymagane oraz sprawdzane. Email musi mieć odpowiednią formę, tzn. posiadać "@". Hasło musi mieć odpowiednią trudność, m.in. liczby, duża i mała litera, odpowiednia długość. 

2. Login użytkownika: <br/>
![Login użytkownika](Images/login.png)<br/>
Login wymaga podania takich danych, jak:
- e-mail
- hasło <br/>
Email oraz hasło są obowiązkowe.

3. Użytkownik: <br/>
![Użytkownik](Images/uzytkownik.png)<br/>

4. Baza danych: <br/>
![Baza danych](Images/db.png)<br/>
  
5. Wylogowanie: <br/>
![Wylogowanie](Images/wyloguj.png)<br/>
Po uruchomieniu logujemy się pomyślnie. Następnie klikamy, by się wylogować, a plik cookiezostanie usunięty.

### Realizacja projektu - API:
1. Konfiguracja:<br/>
Inicjalizacja klienta oraz przypisanie adresu bazowego odbywa się w pliku Startup.cs <br/>
![Inicjalizacja](Images/klient.PNG)<br/>
Utworzenie klienta odbywa się w kontrolerze (ApiController.cs).<br/>

