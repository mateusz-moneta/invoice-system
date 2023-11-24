# Invoice System

## Opis
Platforma umożliwia ogólny dostęp do danych, które wcześniej trzeba było wyszukiwać w różnych miejscach lub wpisywać ręcznie.

## Funkcje i cechy

* Rejestracja i logowanie użytkownika
* Sesja użytkownika
* Wylogowanie użytkownika
* Haszowanie hasła oparte na algorytmie bcrypt
* Tworzenie nowych faktur, w tym możliwość dodawania loga oraz wzoru faktury przez użytkowników
* System przypomnień o braku płatności w terminie
* Integracja z GUS w celu pobierania danych kontrahenta przez NIP oraz z VIES w celu pobierania danych o zagranicznych podmiotach po numerach VATUE
* Dodawanie nowych użytkowników do bazy przez administratora
* Responsywny projekt i tryb mobilny

## Użyte technologie

* ASP.NET MVC

* Postgres SQL

* HTML 5
* SCSS
* Bootstrap 3
* React
* Next.js
  
* Docker

## Przygotowanie środowiska lokalnego do części Backend

* Zainstaluj pgAdmin. Tu znajdziesz dla Windows -> https://www.pgadmin.org/download/pgadmin-4-windows/
* Utwórz Server, ustal hasło, swórz baze dnaych invoice-system-db i zmodyfikuj ConnectionString w appsettings.json.
* Mając otwartą solucję w VisualStudio w PackageManagerConsole wykonaj komendę "update-database". To sprawi, że EntityFramework utworzy tabele w bazie na podstawie zdefiniowanych Models.



